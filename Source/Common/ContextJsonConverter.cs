namespace Schema.NET;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Converts a <see cref="JsonLdContext"/> object to and from JSON.
/// </summary>
/// <seealso cref="JsonConverter" />
public class ContextJsonConverter : JsonConverter<JsonLdContext>
{
    /// <inheritdoc />
    public override JsonLdContext Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(typeToConvert);
        ArgumentNullException.ThrowIfNull(options);

        var context = new JsonLdContext();

        string? name = null;
        string? language = null;
        if (reader.TokenType == JsonTokenType.String)
        {
            name = reader.GetString();
        }
        else if (reader.TokenType == JsonTokenType.StartObject)
        {
            var document = JsonDocument.ParseValue(ref reader);

            if (document.RootElement.TryGetProperty("name", out var nameElement))
            {
                name = nameElement.GetString() ?? Constants.HttpsSchemaOrgUrl;
            }

            if (document.RootElement.TryGetProperty("@language", out var languageElement))
            {
                language = languageElement.GetString();
            }
        }
        else
        {
            var array = JsonDocument.ParseValue(ref reader).RootElement.EnumerateArray();

            foreach (var entry in array)
            {
                if (entry.ValueKind == JsonValueKind.String)
                {
                    name ??= entry.GetString();
                }
                else if (entry.ValueKind == JsonValueKind.Object)
                {
                    if (entry.TryGetProperty("name", out var nameElement))
                    {
                        name ??= nameElement.GetString() ?? Constants.HttpsSchemaOrgUrl;
                    }

                    if (entry.TryGetProperty("@language", out var languageElement))
                    {
                        language ??= languageElement.GetString();
                    }
                }
            }
        }

        context.Name = name;
        context.Language = language;
        return context;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, JsonLdContext value, JsonSerializerOptions options)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(options);

        if (string.IsNullOrWhiteSpace(value.Language))
        {
            writer.WriteStringValue(value.Name);
        }
        else
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            writer.WriteStringValue(value.Name);
            writer.WritePropertyName("@language");
            writer.WriteStringValue(value.Language);
            writer.WriteEndObject();
        }
    }
}

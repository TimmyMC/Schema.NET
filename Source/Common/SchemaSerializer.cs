namespace Schema.NET;

using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Schema JSON Serializer
/// </summary>
public static class SchemaSerializer
{
    private const string ContextPropertyJson = "\"@context\":\"https://schema.org\",";

    /// <summary>
    /// Default serializer settings used when HTML escaping is not required.
    /// </summary>
    private static readonly JsonSerializerOptions DefaultSerializationSettings = new()
    {
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    /// <summary>
    /// Serializer settings used when trying to avoid XSS vulnerabilities where user-supplied data is used
    /// and the output of the serialization is embedded into a web page raw.
    /// </summary>
    private static readonly JsonSerializerOptions HtmlEscapedSerializationSettings = new()
    {
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    /// <summary>
    /// Deserializes the JSON to the specified type.
    /// </summary>
    /// <typeparam name="T">Deserialization target type</typeparam>
    /// <param name="value">JSON to deserialize</param>
    /// <returns>An instance of <typeparamref name="T"/> deserialized from JSON</returns>
    public static T? DeserializeObject<T>(string value) =>
        JsonSerializer.Deserialize<T>(value, DefaultSerializationSettings);

    /// <summary>
    /// Serializes the value to JSON with default serialization settings.
    /// </summary>
    /// <param name="value">Serialization target value</param>
    /// <returns>The serialized JSON string</returns>
    public static string SerializeObject(object value) =>
        SerializeObject(value, DefaultSerializationSettings);

    /// <summary>
    /// Serializes the value to JSON with HTML escaping serialization settings.
    /// </summary>
    /// <param name="value">Serialization target value</param>
    /// <returns>The serialized JSON string</returns>
    public static string HtmlEscapedSerializeObject(object value) =>
        SerializeObject(value, HtmlEscapedSerializationSettings);

    /// <summary>
    /// Serializes the value to JSON with custom serialization settings.
    /// </summary>
    /// <param name="value">Serialization target value</param>
    /// <param name="options">JSON serialization settings</param>
    /// <returns>The serialized JSON string</returns>
    public static string SerializeObject(object value, JsonSerializerOptions options) =>
        RemoveAllButFirstContext(JsonSerializer.Serialize(value, options));

    private static string RemoveAllButFirstContext(string json)
    {
        if (!HasDuplicateContexts(json.AsSpan(), out var secondContextIndex))
        {
            return json;
        }

        var duplicateOccurrences = json.AsSpan()[secondContextIndex..].Count(ContextPropertyJson);
        var resultLength = json.Length - (duplicateOccurrences * ContextPropertyJson.Length);

        return string.Create(resultLength, (json, secondContextStart: secondContextIndex), BuildResultString);
    }

    private static bool HasDuplicateContexts(ReadOnlySpan<char> json, out int secondContextIndex)
    {
        var firstContextIndex = json.IndexOf(ContextPropertyJson, StringComparison.Ordinal);

        if (firstContextIndex < 0)
        {
            secondContextIndex = 0;
            return false;
        }

        secondContextIndex = json[(firstContextIndex + ContextPropertyJson.Length)..].IndexOf(ContextPropertyJson, StringComparison.Ordinal);

        return secondContextIndex >= 0;
    }

    private static void BuildResultString(Span<char> destination, (string json, int prefixLength) state)
    {
        var (json, prefixLength) = state;

        json.AsSpan(0, prefixLength).CopyTo(destination);

        var source = json.AsSpan(prefixLength);
        var writePosition = prefixLength;
        var readPosition = 0;

        while (readPosition < source.Length)
        {
            var nextContextIndex = source[readPosition..].IndexOf(ContextPropertyJson);

            if (nextContextIndex < 0)
            {
                source[readPosition..].CopyTo(destination[writePosition..]);
                break;
            }

            source.Slice(readPosition, nextContextIndex).CopyTo(destination[writePosition..]);
            writePosition += nextContextIndex;
            readPosition += nextContextIndex + ContextPropertyJson.Length;
        }
    }
}

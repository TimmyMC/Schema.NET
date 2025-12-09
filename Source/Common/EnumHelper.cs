namespace Schema.NET;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Helper for parsing strings into Enum values.
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// Converts the string representation of the name or numeric value of one or more
    /// enumerated constants to an equivalent enumerated object.
    /// </summary>
    /// <param name="enumType">The enum type to use for parsing.</param>
    /// <param name="value">The string representation of the name or numeric value of one or more enumerated constants.</param>
    /// <param name="result">When this method returns true, an object containing an enumeration constant representing the parsed value.</param>
    /// <returns><see langword="true"/> if the conversion succeeded; <see langword="false"/> otherwise.</returns>
    public static bool TryParse(
        Type enumType,
        [NotNullWhen(true)] string? value,
        out object? result) => Enum.TryParse(enumType, value, out result);

    /// <summary>
    /// Converts the Schema URI representation of the enum type to an equivalent enumerated object.
    /// </summary>
    /// <param name="enumType">The enum type to use for parsing.</param>
    /// <param name="value">The string representation of the name or numeric value of one or more enumerated constants.</param>
    /// <param name="result">When this method returns true, an object containing an enumeration constant representing the parsed value.</param>
    /// <returns><see langword="true"/> if the conversion succeeded; <see langword="false"/> otherwise.</returns>
    public static bool TryParseEnumFromSchemaUri(
        Type enumType,
        [NotNullWhen(true)] string? value,
        out object? result)
    {
        ArgumentNullException.ThrowIfNull(enumType);

        string? enumString;
        if (value is not null && value.Length > Constants.HttpSchemaOrgUrl.Length && value.StartsWith(Constants.HttpSchemaOrgUrl, StringComparison.OrdinalIgnoreCase))
        {
            enumString = value[(Constants.HttpSchemaOrgUrl.Length + 1)..];
        }
        else if (value is not null && value.Length > Constants.HttpsSchemaOrgUrl.Length && value.StartsWith(Constants.HttpsSchemaOrgUrl, StringComparison.OrdinalIgnoreCase))
        {
            enumString = value[(Constants.HttpsSchemaOrgUrl.Length + 1)..];
        }
        else
        {
            enumString = value;
        }

        if (TryParse(enumType, enumString, out result))
        {
            return true;
        }
        else
        {
            Debug.WriteLine($"Unable to parse enumeration of type {enumType.FullName} with value {enumString}.");
            return false;
        }
    }
}

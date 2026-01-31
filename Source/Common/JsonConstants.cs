namespace Schema.NET;

/// <summary>
/// Internal JSON constants copied from <c>System.Text.Json.JsonConstants</c>
/// </summary>
internal static class JsonConstants
{
    internal const int MaximumFormatDoubleLength = 128;  // default (i.e. 'G'), using 128 (rather than say 32) to be future-proof.
    internal const int MaximumFormatDecimalLength = 31; // default (i.e. 'G')
}

namespace Schema.NET.Benchmarks.Core;

using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class BookBenchmarkPoco
{
    public static readonly JsonSerializerOptions DefaultSerializationSettings = new()
    {
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static PocoBook BookPoco => new PocoBook
    {

        Id = new Uri("https://example.com/book/1"),
        Name = "The Catcher in the Rye",
        Author = new PocoPerson
        {
            Name = "J.D. Salinger",
        },
        Url = new Uri("https://www.barnesandnoble.com/store/info/offer/JDSalinger"),
        WorkExample = new List<PocoBook>
        {
            new PocoBook
            {
                Isbn = "031676948",
                BookEdition = "2nd Edition",
                BookFormat = "Hardcover",
                PotentialAction = new PocoReadAction
                {
                    Target = new PocoEntryPoint
                    {
                        UrlTemplate = "https://www.barnesandnoble.com/store/info/offer/0316769487?purchase=true",
                        ActionPlatform = new List<Uri>
                        {
                            new Uri("https://schema.org/DesktopWebPlatform"),
                            new Uri("https://schema.org/IOSPlatform"),
                            new Uri("https://schema.org/AndroidPlatform"),
                        },
                    },
                    ExpectsAcceptanceOf = new PocoOffer
                    {
                        Price = 6.99M,
                        PriceCurrency = "USD",
                        EligibleRegion = new PocoCountry
                        {
                            Name = "US",
                        },
                        Availability = "InStock",
                    },
                },
            },
            new PocoBook
            {
                Isbn = "031676947",
                BookEdition = "1st Edition",
                BookFormat = "EBook",
                PotentialAction = new PocoReadAction
                {
                    Target = new PocoEntryPoint
                    {
                        UrlTemplate = "https://www.barnesandnoble.com/store/info/offer/031676947?purchase=true",
                        ActionPlatform = new List<Uri>
                        {
                            new Uri("https://schema.org/DesktopWebPlatform"),
                            new Uri("https://schema.org/IOSPlatform"),
                            new Uri("https://schema.org/AndroidPlatform"),
                        },
                    },
                    ExpectsAcceptanceOf = new PocoOffer
                    {
                        Price = 1.99M,
                        PriceCurrency = "USD",
                        EligibleRegion = new PocoCountry
                        {
                            Name = "UK",
                        },
                        Availability = "InStock",
                    },
                },
            },
        },
    };
}

public class PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public virtual string Type => "Thing";
    public Uri? Id { get; init; }
    public string? Name { get; init; }
    public Uri? Url { get; init; }
}

public class PocoPerson : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "Person";
}

public class PocoCreativeWork : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "CreativeWork";
}

public class PocoBook : PocoCreativeWork
{
    [JsonPropertyName("@context")]
    [JsonPropertyOrder(0)]
    public string Context => "https://schema.org";

    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "Book";
    public string? Isbn { get; init; }
    public string? BookEdition { get; init; }
    public string? BookFormat { get; init; }
    public PocoReadAction? PotentialAction { get; init; }
#pragma warning disable CA1002
    public List<PocoBook>? WorkExample { get; init; }
#pragma warning restore CA1002
    public PocoPerson? Author { get; init; }
}

public class PocoReadAction : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "ReadAction";
    public PocoEntryPoint? Target { get; init; }
    public PocoOffer? ExpectsAcceptanceOf { get; init; }
}

public class PocoEntryPoint : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "EntryPoint";
#pragma warning disable CA1056
    public string? UrlTemplate { get; init; }
#pragma warning restore CA1056
#pragma warning disable CA1002
    public List<Uri>? ActionPlatform { get; init; }
#pragma warning restore CA1002
}

public class PocoOffer : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "Offer";
    public decimal Price { get; init; }
    public string? PriceCurrency { get; init; }
    public PocoCountry? EligibleRegion { get; init; }
    public string? Availability { get; init; }
}

public class PocoCountry : PocoThing
{
    [JsonPropertyName("@type")]
    [JsonPropertyOrder(1)]
    public override string Type => "Country";
}

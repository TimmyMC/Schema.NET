[![Schema.NET NuGet Package](https://img.shields.io/nuget/v/Schema.NET.svg)](https://www.nuget.org/packages/Schema.NET)

[//]: # ([![Schema.NET NuGet Package Downloads]&#40;https://img.shields.io/nuget/dt/Schema.NET&#41;]&#40;https://www.nuget.org/packages/Schema.NET&#41;)

Schema.org objects turned into strongly typed C# POCO classes for use in .NET. All classes can be serialized into JSON/JSON-LD and XML, typically used to represent structured data in the `head` section of `html` page.

## Simple Example

```C#
var website = new WebSite()
{
    AlternateName = "An Alternative Name",
    Name = "Your Site Name",
    Url = new Uri("https://example.com")
};
var jsonLd = website.ToString();
```

The code above outputs the following JSON-LD:

```JSON
{
    "@context":"https://schema.org",
    "@type":"WebSite",
    "alternateName":"An Alternative Name",
    "name":"Your Site Name",
    "url":"https://example.com"
}
```

If writing the result into a `<script>` element, be sure to use the `.ToHtmlEscapedString()` method instead to avoid exposing your website to a Cross-Site Scripting attack. See the [example below](#important-security-notice).

## What is Schema.org?

[schema.org](https://schema.org) defines a set of standard classes and their properties for objects and services in the real world. This machine readable format is a common standard used across the web for describing things.

## Where is Schema.org Used?

#### Websites

Websites can define Structured Data in the `head` section of their `html` to enable search engines to show richer information in their search results. Here is an example of how [Google](https://developers.google.com/search/docs/guides/intro-structured-data) can display extended metadata about your site in it's search results.

Using structured data in `html` requires the use of a `script` tag with a MIME type of `application/ld+json` like so:

```HTML
<script type="application/ld+json">
{
  "@context": "https://schema.org",
  "@type": "Organization",
  "url": "https://www.example.com",
  "name": "Unlimited Ball Bearings Corp.",
  "contactPoint": {
    "@type": "ContactPoint",
    "telephone": "+1-401-555-1212",
    "contactType": "Customer service"
  }
}
</script>
```

##### Important Security Notice
When serializing the result for a website's `<script>` tag, you should use the alternate `.ToHtmlEscapedString()` to avoid exposing yourself to a Cross-Site Scripting (XSS) vulnerability if some of the properties in your schema have been set from untrusted sources.
Usage in an ASP.NET MVC project might look like this:

```HTML
<script type="application/ld+json">
    @Html.Raw(Model.Schema.ToHtmlEscapedString())
</script>
```

#### Windows UWP Sharing

Windows UWP apps let you share data using schema.org classes. [Here](https://docs.microsoft.com/en-us/uwp/schemas/appxpackage/appxmanifestschema/element-sharetarget) is an example showing how to share metadata about a book.

## Classes & Properties

schema.org defines classes and properties, where each property can have a single value or an array of multiple values. Additionally, properties can have multiple types e.g. an `Address` property could have a type of `string` or a type of `PostalAddress` which has it's own properties such as `StreetAddress` or `PostalCode` which breaks up an address into it's constituent parts.

To facilitate this Schema.NET uses some clever C# generics and implicit type conversions so that setting a single or multiple values is possible and that setting a `string` or `PostalAddress` is also possible:

```C#
// Single string address
var organization = new Organization()
{
    Address = "123 Old Kent Road E10 6RL"
};

// Multiple string addresses
var organization = new Organization()
{
    Address = new List<string>()
    { 
        "123 Old Kent Road E10 6RL",
        "456 Finsbury Park Road SW1 2JS"
    }
};

// Single PostalAddress address
var organization = new Organization()
{
    Address = new PostalAddress()
    {
        StreetAddress = "123 Old Kent Road",
        PostalCode = "E10 6RL"
    }
};

// Multiple PostalAddress addresses
var organization = new Organization()
{
    Address = new List<PostalAddress>()
    {
        new PostalAddress()
        {
            StreetAddress = "123 Old Kent Road",
            PostalCode = "E10 6RL"
        },
        new PostalAddress()
        {
            StreetAddress = "456 Finsbury Park Road",
            PostalCode = "SW1 2JS"
        }
    }
};

// Mixed Author types
var book = new Book()
{
    Author = new List<object>()
    {
        new Organization() { Name = "Penguin" },
        new Person() { Name = "J.D. Salinger" }
    }
};

// Deconstruct a property containing mixed types
if (book.Author.HasValue)
{
    var (organisations, people) = book.Author.Value;
}
```

This magic is all carried out using [implicit conversion operators](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/implicit) in the `OneOrMany<T>`, `Values<T1, T2>`, `Values<T1, T2, T3>` and `Values<T1, T2, T3, T4>` types. These types are all `structs` for best performance too.

## More Examples

For more examples and actual running code samples, take a look at the unit tests in the project source code.

## Schema.NET.Pending

There are many pending types on [schema.org](https://schema.org) which are not yet fully formed and ready for production. If you need to use these, you can install the [Schema.NET.Pending](https://www.nuget.org/packages/Schema.NET.Pending) NuGet package instead of [Schema.NET](https://www.nuget.org/packages/Schema.NET). This package contains all released schema types as well as all pending types.

[![Schema.NET.Pending NuGet Package](https://img.shields.io/nuget/v/Schema.NET.Pending.svg)](https://www.nuget.org/packages/Schema.NET.Pending) 

[//]: # ([![Schema.NET.Pending NuGet Package Downloads]&#40;https://img.shields.io/nuget/dt/Schema.NET.Pending&#41;]&#40;https://www.nuget.org/packages/Schema.NET.Pending&#41;)

## Continuous Integration

| Name            | Operating System      | Status | History                                                                                                                                                                                  |
| :---            | :---                  | :---   |:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| GitHub Actions  | Ubuntu, Mac & Windows | [![GitHub Actions Status](https://github.com/TimmyMC/Schema.NET/workflows/Build/badge.svg?branch=main)](https://github.com/TimmyMC/Schema.NET/actions) | [![GitHub Actions Build History](https://buildstats.info/github/chart/TimmyMC/Schema.NET?branch=main&includeBuildsFromPullRequest=false)](https://github.com/TimmyMC/Schema.NET/actions) |

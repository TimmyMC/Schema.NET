using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Schema.NET.Benchmarks.Core;

var thing = BookBenchmark.BookThing;
//var poco = BookBenchmarkPoco.BookPoco;


await Task.Delay(2000).ConfigureAwait(true);

for (var i = 0; i < 1000; i++)
{
    Use(thing.ToString());
    //Use(JsonSerializer.Serialize(thing, BookBenchmarkPoco.DefaultSerializationSettings));
    //Use(JsonSerializer.Serialize(poco, BookBenchmarkPoco.DefaultSerializationSettings));
}


#pragma warning disable IDE0060 // Remove unused parameter
[MethodImpl(MethodImplOptions.NoInlining)]
static void Use<T>(T input)
{ }
#pragma warning restore IDE0060 // Remove unused parameter

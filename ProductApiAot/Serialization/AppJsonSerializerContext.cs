using System.Text.Json.Serialization;
using ProductApiAot.Models;

namespace ProductApiAot.Serialization;

[JsonSerializable(typeof(Product))]
[JsonSerializable(typeof(IEnumerable<Product>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
    
}
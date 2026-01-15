using System.Text.Json;
using System.Text.Json.Nodes;

string json = """{ "Value": 1, "Value": -1 }""";
Console.WriteLine(JsonSerializer.Deserialize<MyRecord>(json)!.Value); // -1

JsonSerializerOptions options = new() { AllowDuplicateProperties = false };
JsonSerializer.Deserialize<MyRecord>(json, options);                // throws JsonException
JsonSerializer.Deserialize<JsonObject>(json, options);              // throws JsonException
JsonSerializer.Deserialize<Dictionary<string, int>>(json, options); // throws JsonException

JsonDocumentOptions docOptions = new() { AllowDuplicateProperties = false };
JsonDocument.Parse(json, docOptions);   // throws JsonException

record MyRecord(int Value);
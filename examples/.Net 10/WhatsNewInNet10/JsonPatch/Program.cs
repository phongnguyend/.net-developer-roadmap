using Microsoft.AspNetCore.JsonPatch.SystemTextJson;
using System.Text.Json;
using System.Text.Json.Serialization;

var person = new Person
{
    FirstName = "John",
    LastName = "Doe",
    Email = "johndoe@gmail.com",
    PhoneNumbers = [new PhoneNumber() { Number = "123-456-7890", Type = PhoneNumberType.Mobile }],
    Address = new Address
    {
        Street = "123 Main St",
        City = "Anytown",
        State = "TX"
    }
};

// Raw JSON Patch document
var jsonPatch = """
[
  { "op": "replace", "path": "/FirstName", "value": "Jane" },
  { "op": "remove", "path": "/Email"},
  { "op": "add", "path": "/Address/ZipCode", "value": "90210" },
  {
    "op": "add",
    "path": "/PhoneNumbers/-",
    "value": { "Number": "987-654-3210", "Type": "Work" }
  }
]
""";

// Configure JSON serializer options to handle string enums
var options = new JsonSerializerOptions
{
    Converters = { new JsonStringEnumConverter() },
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
};

// Deserialize the JSON Patch document
var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Person>>(jsonPatch, options);

// Apply the JSON Patch document
patchDoc!.ApplyTo(person);

// Output updated object
Console.WriteLine(JsonSerializer.Serialize(person, options));

// Output:
// {
//   "firstName": "Jane",
//   "lastName": "Doe",
//   "address": {
//     "street": "123 Main St",
//     "city": "Anytown",
//     "state": "TX",
//     "zipCode": "90210"
//   },
//   "phoneNumbers": [
//     {
//       "number": "123-456-7890",
//       "type": "Mobile"
//     },
//     {
//       "number": "987-654-3210",
//       "type": "Work"
//     }
//   ]
// }
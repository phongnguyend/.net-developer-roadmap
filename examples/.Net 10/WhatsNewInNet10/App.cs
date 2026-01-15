#:package CryptographyHelper@3.1.0

using System;
using CryptographyHelper;
using CryptographyHelper.HashAlgorithms;

Console.WriteLine("Hello, World!");

const string originalMessage = "Original Message to hash";

var hashed = originalMessage.UseSha512().ComputeHash().ToHexString();

Console.WriteLine(hashed);

// dotnet run App.cs
// Output:
// Hello, World!
// 4BC7C892C45B94157C58D07F40B52CC2325505A560C7EB30472B43A15717E32307BF1B7A2CAD08446A9EF220F5255A9763FACA8632CFBC35D2C1E3131A250986
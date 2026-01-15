using System.IO.Compression;

string outputPath = "logs.zip";

using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
{
    await ZipFile.CreateFromDirectoryAsync("../../../logs", fileStream);
    Console.WriteLine($"Successfully created {outputPath}");
}

Console.WriteLine("\nZip file structure:");
using var archive = await ZipFile.OpenReadAsync(outputPath);
foreach (var entry in archive.Entries)
{
    Console.WriteLine($"  {entry.FullName}");
}

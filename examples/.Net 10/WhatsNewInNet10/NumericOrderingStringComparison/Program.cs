using System.Globalization;

StringComparer numericStringComparer = StringComparer.Create(CultureInfo.CurrentCulture, CompareOptions.NumericOrdering);

Console.WriteLine(numericStringComparer.Equals("02", "2"));
// Output: True

foreach (string os in new[] { "Windows 8", "Windows 10", "Windows 11" }.Order(numericStringComparer))
{
    Console.WriteLine(os);
}

// Output:
// Windows 8
// Windows 10
// Windows 11

HashSet<string> set = new HashSet<string>(numericStringComparer) { "007" };
Console.WriteLine(set.Contains("7"));
// Output: True

IDictionary<string,string> dic = new Dictionary<string, string>(numericStringComparer);

dic["7"] = "Seven";

Console.WriteLine(dic["7"]);
// Output: Seven

Console.WriteLine(dic["007"]);
// Output: Seven

dic["07"] = "Bảy";

Console.WriteLine(dic["7"]);
// Output: Bảy

Console.WriteLine(dic["007"]);
// Output: Bảy


namespace ExtensionMembers;

public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

public static class PersonExtensions
{
    public static string GetFullName(this Person person)
    {
        return $"{person.FirstName} {person.LastName}";
    }

    extension(Person person)
    {
        public string FullName => $"{person.FirstName} {person.LastName}";
    }

    extension(Person)
    {
        public static int Count() => 0;
    }
}
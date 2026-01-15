using ExtensionMembers;

var person = new Person
{
    FirstName = "John",
    LastName = "Doe"
};

Console.WriteLine(person.GetFullName());
Console.WriteLine(person.FullName);
Console.WriteLine(Person.Count());
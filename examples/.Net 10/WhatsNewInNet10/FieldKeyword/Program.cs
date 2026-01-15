using FieldKeyword;

var person = new Person
{
    FirstName = "   John   ",
    LastName = "   Doe   "
};

Console.WriteLine(person.FirstName);
Console.WriteLine(person.LastName);
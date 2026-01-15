using NullConditionalAssignment;

var person = new Person
{
    FirstName = "   John   ",
    LastName = "   Doe   "
};

// person = null;

TrimPersonNames1(person);
// TrimPersonNames2(person);

Console.WriteLine(person?.FirstName);
Console.WriteLine(person?.LastName);

void TrimPersonNames1(Person? person)
{
    if (person != null)
    {
        person.FirstName = person.FirstName?.Trim();
        person.LastName = person.LastName?.Trim();
    }
}

void TrimPersonNames2(Person? person)
{
    person?.FirstName = person?.FirstName?.Trim();
    person?.LastName = person?.LastName?.Trim();
}
namespace FieldKeyword;

public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

public class Person1
{
    private string? firstName;
    public string? FirstName
    {
        get => firstName;
        set => firstName = value?.Trim();
    }

    private string? lastName;
    public string? LastName
    {
        get => lastName;
        set => lastName = value?.Trim();
    }
}

public class Person2
{
    public string? FirstName
    {
        get => field;
        set => field = value?.Trim();
    }

    public string? LastName
    {
        get => field;
        set => field = value?.Trim();
    }
}

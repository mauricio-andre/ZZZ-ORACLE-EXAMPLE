namespace ZZZOracleExample.Core.Examples.Entities;

public static class ExampleConstrains {
    public const int NameMaxLength = 2000;
}

public class Example
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

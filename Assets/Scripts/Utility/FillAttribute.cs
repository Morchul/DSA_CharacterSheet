using System;

[AttributeUsage(AttributeTargets.Field)]
public class FillAttribute : System.Attribute
{
    public readonly string Name;

    public FillAttribute(string name)
    {
        this.Name = name;
    }
}

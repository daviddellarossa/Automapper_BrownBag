namespace Automapper_UnitTests.Construction.Types;

internal class DestinationWithNonEmptyConstructor
{
    public string OtherValue { get; }
    public DestinationWithNonEmptyConstructor(string otherValue)
    {
        OtherValue = otherValue;
    }
}

internal class DestinationWithEmptyConstructor
{
    public string OtherValue { get; set; }
    public DestinationWithEmptyConstructor(string otherValue)
    {
        OtherValue = otherValue;
    }
    public DestinationWithEmptyConstructor()
    {
        
    }
}

internal class Destination
{
    public string Id { get; }
    public string OtherValue { get; set; }

    public Destination(string id)
    {
        Id = id;
    }
}
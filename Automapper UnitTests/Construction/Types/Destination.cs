namespace Automapper_UnitTests.Construction.Types;

internal class DestinationWithNonDefaultConstructor
{
    public string OtherValue { get; }
    public DestinationWithNonDefaultConstructor(string otherValue)
    {
        OtherValue = otherValue;
    }
}

internal class DestinationWithDefaultConstructor
{
    public string OtherValue { get; set; }
    public DestinationWithDefaultConstructor(string otherValue)
    {
        OtherValue = otherValue;
    }
    public DestinationWithDefaultConstructor()
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
public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string type { get; set; }
    public Feature[] features { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public Geometry geometry { get; set; }
}

public class Properties
{
    public double? mag { get; set; }
    public string place { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public double[] coordinates { get; set; }
}
using System;
using System.Collections.Generic;

[Serializable]
public class Plant {
    
    public string name;
    public string scientificName;
    public string description;
    public string sprite;
    public string image;
    public float width;
    public float height;
    public Dictionary<Attributes, AttributeRange> specs = new Dictionary<Attributes, AttributeRange>();
    public string[] rawSpecs;

    public override string ToString() {
        return "{name: " + name + ", description: " + description + ", image: " + image + "}";
    }
}
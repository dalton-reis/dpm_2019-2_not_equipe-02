using System;
using System.Collections.Generic;

[Serializable]
public class Bioma {

    public string name;
    public string image;
    public Dictionary<Attributes, AttributeRange> specs = new Dictionary<Attributes, AttributeRange>();
    public string[] rawSpecs;

    public override string ToString() {
        return "{name: " + name + ", image: " + image + "]}";
    }

}

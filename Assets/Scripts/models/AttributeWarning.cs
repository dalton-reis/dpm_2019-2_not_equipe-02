using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeWarning
{
    public Attributes attribute;
    public float distance;

    public AttributeWarning(Attributes attribute, float distance)
    {
        this.attribute = attribute;
        this.distance = distance;
    }
    
    public override bool Equals(object obj)
    {
        var warning = obj as AttributeWarning;
        return warning != null &&
               attribute == warning.attribute;
    }

    public override int GetHashCode()
    {
        return -1961618617 + attribute.GetHashCode();
    }

    public override string ToString()
    {
        return attribute.ToString();
    }
}

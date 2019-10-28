using System;
using UnityEngine;

[Serializable]
public class AttributeRange
{

    public float minValue;
    public float maxValue;

    public AttributeRange(float minValue, float maxValue)
    {
        this.minValue = minValue;
        this.maxValue = maxValue;
    }

    public float getDistance(float value)
    {
        if (value >= minValue && value <= maxValue)
        {
            return 0;
        }
        if (value < minValue)
        {
            return minValue - value;
        }
        return value - maxValue;
    }

}

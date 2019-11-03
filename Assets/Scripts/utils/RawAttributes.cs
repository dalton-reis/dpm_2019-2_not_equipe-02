using System;
using System.Collections.Generic;
using UnityEngine;

public class RawAttributes
{
    private static readonly int FIELD_COUNT = 3;

    public static void AddAttribute(Dictionary<Attributes, AttributeRange> attributes, string[] rawAttributes)
    {
        if (rawAttributes == null)
        {
            return;
        }
        for (int i = 0; i < rawAttributes.Length / FIELD_COUNT; i++)
        {
            int rowIndex = i * FIELD_COUNT;
            var attribute = (Attributes) Enum.Parse(typeof(Attributes), rawAttributes[rowIndex]);
            var minValue = float.Parse(rawAttributes[rowIndex + 1], System.Globalization.CultureInfo.InvariantCulture);
            var maxValue = float.Parse(rawAttributes[rowIndex + 2], System.Globalization.CultureInfo.InvariantCulture);
            var attributeRange = new AttributeRange(minValue, maxValue);
            attributes.Add(attribute, attributeRange);
        }
    }
}

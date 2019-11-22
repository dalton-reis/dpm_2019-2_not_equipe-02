using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlantAttributsEventLogger
{

    public static string toJson(Plant plant, params Dictionary<Attributes, float>[] attributesData)
    {
        Dictionary<Attributes, float> distances = new Dictionary<Attributes, float>();
        foreach (var attributes in attributesData)
        {
            foreach (var attribute in attributes)
            {
                float distance = plant.specs[attribute.Key].getDistance(attribute.Value);
                distances[attribute.Key] = distance;
            }
        }
        string data = "";
        foreach (var distance in distances)
        {
            data += "\"" + distance.Key + "\": " + distance.Value.ToString(CultureInfo.InvariantCulture) + ",";
        }
        if (data.EndsWith(",")) data = data.Substring(0, data.Length - 1);
        return "{" + data + "}";
    }
}

using System;
using UnityEngine;

[Serializable]
public class Bioma {

    public string name;
    public string image;
    public float temperature;
    public Plant[] plants;

    public override string ToString() {
        string content = "{name: " + name + ", image: " + image + ", plants: [";

        foreach (Plant plant in plants)
            content += plant;

        return content + "]}";
    }

}

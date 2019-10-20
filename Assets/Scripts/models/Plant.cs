using System;
using UnityEngine;

[Serializable]
public class Plant {
    
    public string name;
    public string description;
    public string image;
    public float width;
    public float height;

    public override string ToString() {
        return "{name: " + name + ", description: " + description + ", image: " + image + "}";
    }
}
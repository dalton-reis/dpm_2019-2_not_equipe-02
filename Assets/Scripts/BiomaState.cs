using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomaState : MonoBehaviour
{
    public Bioma bioma;
    public Dictionary<Attributes, float> biomaAttributes = new Dictionary<Attributes, float>();
    public SimpleHealthBar temperatureBar;

    void Start()
    {
        biomaAttributes.Add(Attributes.TEMPERATURE, 100);
        biomaAttributes.Add(Attributes.AIR_HUMIDITY, 100);
    }
    
    void Update()
    {
        if (temperatureBar == null)
        {
            temperatureBar = GameObject.Find("TemperatureBar").GetComponent<SimpleHealthBar>();
        }
        temperatureBar.UpdateBar(biomaAttributes[Attributes.TEMPERATURE], 100);
    }
    
}

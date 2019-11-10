using System.Collections.Generic;
using UnityEngine;

public class BiomaState : MonoBehaviour
{
    private float TEMPERATURE_FACTOR = 15;

    public Bioma bioma;
    public Dictionary<Attributes, float> biomaAttributes = new Dictionary<Attributes, float>();
    public SimpleHealthBar temperatureBar;

    void Start()
    {
        biomaAttributes.Add(Attributes.TEMPERATURE, bioma.specs[Attributes.TEMPERATURE].GetAverage());
        biomaAttributes.Add(Attributes.AIR_HUMIDITY, bioma.specs[Attributes.AIR_HUMIDITY].GetAverage());
    }

    void Update()
    {
        if (temperatureBar == null)
        {
            temperatureBar = GameObject.Find("TemperatureBar").GetComponent<SimpleHealthBar>();
        }
        temperatureBar.UpdateBar(biomaAttributes[Attributes.TEMPERATURE], 100);
    }

    public void IncreaseTemperature()
    {
        float temperature = biomaAttributes[Attributes.TEMPERATURE];
        temperature += (TEMPERATURE_FACTOR * Time.deltaTime);
        float maxTemperature = bioma.specs[Attributes.TEMPERATURE].maxValue;
        temperature = temperature > maxTemperature ? maxTemperature : temperature;
        biomaAttributes[Attributes.TEMPERATURE] = temperature;
    }

    public void DecreaseTemperature()
    {
        float temperature = biomaAttributes[Attributes.TEMPERATURE];
        temperature -= (TEMPERATURE_FACTOR * Time.deltaTime);
        float minTemperature = bioma.specs[Attributes.TEMPERATURE].minValue;
        temperature = temperature < minTemperature ? minTemperature : temperature;
        biomaAttributes[Attributes.TEMPERATURE] = temperature;
    }

}
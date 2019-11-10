using System.Collections.Generic;
using UnityEngine;

public class BiomaState : MonoBehaviour
{
    private float BIOMA_ATTRIBUTE_CHANGE_FACTOR = 15;

    public Bioma bioma;
    public Dictionary<Attributes, float> biomaAttributes = new Dictionary<Attributes, float>();
    public SimpleHealthBar temperatureBar;
    public SimpleHealthBar airHumidityBar;

    void Start()
    {
        biomaAttributes.Add(Attributes.TEMPERATURE, bioma.specs[Attributes.TEMPERATURE].GetAverage());
        biomaAttributes.Add(Attributes.AIR_HUMIDITY, bioma.specs[Attributes.AIR_HUMIDITY].GetAverage());
    }

    void Update()
    {
        loadBiomaBars();
        temperatureBar.UpdateBar(biomaAttributes[Attributes.TEMPERATURE], 100);
        airHumidityBar.UpdateBar(biomaAttributes[Attributes.AIR_HUMIDITY], 100);
    }

    public void IncreaseTemperature()
    {
        float temperature = biomaAttributes[Attributes.TEMPERATURE];
        temperature += (BIOMA_ATTRIBUTE_CHANGE_FACTOR * Time.deltaTime);
        float maxTemperature = bioma.specs[Attributes.TEMPERATURE].maxValue;
        temperature = temperature > maxTemperature ? maxTemperature : temperature;
        biomaAttributes[Attributes.TEMPERATURE] = temperature;
    }

    public void DecreaseTemperature()
    {
        float temperature = biomaAttributes[Attributes.TEMPERATURE];
        temperature -= (BIOMA_ATTRIBUTE_CHANGE_FACTOR * Time.deltaTime);
        float minTemperature = bioma.specs[Attributes.TEMPERATURE].minValue;
        temperature = temperature < minTemperature ? minTemperature : temperature;
        biomaAttributes[Attributes.TEMPERATURE] = temperature;
    }

    public void IncreaseAirHumidity()
    {
        float airHumidity = biomaAttributes[Attributes.AIR_HUMIDITY];
        airHumidity += (BIOMA_ATTRIBUTE_CHANGE_FACTOR * Time.deltaTime);
        float maxAirHumidity = bioma.specs[Attributes.AIR_HUMIDITY].maxValue;
        airHumidity = airHumidity > maxAirHumidity ? maxAirHumidity : airHumidity;
        biomaAttributes[Attributes.AIR_HUMIDITY] = airHumidity;
    }

    public void DecreaseAirHumidity()
    {
        float airHumidity = biomaAttributes[Attributes.AIR_HUMIDITY];
        airHumidity -= (BIOMA_ATTRIBUTE_CHANGE_FACTOR * Time.deltaTime);
        float minAirHumidity = bioma.specs[Attributes.AIR_HUMIDITY].minValue;
        airHumidity = airHumidity < minAirHumidity ? minAirHumidity : airHumidity;
        biomaAttributes[Attributes.AIR_HUMIDITY] = airHumidity;
    }

    private void loadBiomaBars()
    {
        if (temperatureBar == null)
        {
            temperatureBar = GameObject.Find("TemperatureBar").GetComponent<SimpleHealthBar>();
        }
        if (airHumidityBar == null)
        {
            airHumidityBar = GameObject.Find("AirHumidityBar").GetComponent<SimpleHealthBar>();
        }
    }

}
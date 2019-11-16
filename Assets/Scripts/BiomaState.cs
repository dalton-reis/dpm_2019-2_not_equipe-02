using System.Collections.Generic;
using UnityEngine;

public class BiomaState : MonoBehaviour
{
    private float BIOMA_ATTRIBUTE_CHANGE_FACTOR = 15;

    public Bioma bioma;
    public Dictionary<Attributes, float> biomaAttributes = new Dictionary<Attributes, float>();
    private Dictionary<Attributes, AleatoryEventConsumer> aleatoryConsumers = new Dictionary<Attributes, AleatoryEventConsumer>();
    public SimpleHealthBar temperatureBar;
    public SimpleHealthBar airHumidityBar;

    void Start()
    {
        biomaAttributes.Add(Attributes.TEMPERATURE, bioma.specs[Attributes.TEMPERATURE].GetAverage());
        biomaAttributes.Add(Attributes.AIR_HUMIDITY, bioma.specs[Attributes.AIR_HUMIDITY].GetAverage());

        aleatoryConsumers[Attributes.TEMPERATURE] = new AleatoryEventConsumer(25, 25000);
        aleatoryConsumers[Attributes.AIR_HUMIDITY] = new AleatoryEventConsumer(30, 19000);
    }

    void Update()
    {
        LoadBiomaBars();
        UpdateOnAleatoryEventsValues();
        temperatureBar.UpdateBar(biomaAttributes[Attributes.TEMPERATURE], 100);
        airHumidityBar.UpdateBar(biomaAttributes[Attributes.AIR_HUMIDITY], 100);
    }

    private void UpdateOnAleatoryEventsValues()
    {
        foreach (var aleatoryConsumer in aleatoryConsumers)
        {
            var attribute = aleatoryConsumer.Key;
            var value = aleatoryConsumer.Value.ConsumeValue();
            UpdateAttributeTimeInvariant(attribute, value);
        }
    }

    public void IncreaseTemperature()
    {
        UpdateAttribute(Attributes.TEMPERATURE, BIOMA_ATTRIBUTE_CHANGE_FACTOR);
    }

    public void DecreaseTemperature()
    {
        UpdateAttribute(Attributes.TEMPERATURE, -BIOMA_ATTRIBUTE_CHANGE_FACTOR);
    }

    private void UpdateAttribute(Attributes attribute, float value)
    {
        UpdateAttributeTimeInvariant(attribute, value * Time.deltaTime);
    }

    private void UpdateAttributeTimeInvariant(Attributes attribute, float value)
    {
        float attributeValue = biomaAttributes[attribute];
        attributeValue += value;
        float maxAttributeValue = bioma.specs[attribute].maxValue;
        float minAttributeValue = bioma.specs[attribute].minValue;
        attributeValue = attributeValue > maxAttributeValue ? maxAttributeValue : attributeValue;
        attributeValue = attributeValue < minAttributeValue ? minAttributeValue : attributeValue;
        biomaAttributes[attribute] = attributeValue;
    }

    private void LoadBiomaBars()
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

    private void OnDestroy()
    {
        foreach (var aleatoryConsumer in aleatoryConsumers)
        {
            aleatoryConsumer.Value.Kill();
        }
    }

}
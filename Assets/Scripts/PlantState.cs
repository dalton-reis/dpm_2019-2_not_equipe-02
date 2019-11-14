using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantState : MonoBehaviour
{

    private static readonly float LIFE_RECOVERY_FACTOR = 5;
    private static readonly float ATTRIBUTE_PROPORTION = 10;
    private static readonly float DEFAULT_PLANT_ATTRIBUTE_CHANGE_FACTOR = 10;

    private static readonly float DECREASE_WEIGHT = 500;

    public Plant plant;
    public Dictionary<Attributes, float> plantAttributes = new Dictionary<Attributes, float>();

    public float maxLife;
    public float life;
    private float lifeProportion;

    void Start()
    {
        plantAttributes.Add(Attributes.SOIL_HUMIDITY, plant.specs[Attributes.SOIL_HUMIDITY].GetAverage());
        plantAttributes.Add(Attributes.SOIL_NUTRIENTS, plant.specs[Attributes.SOIL_NUTRIENTS].GetAverage());

        var attributesCount = Enum.GetNames(typeof(Attributes)).Length;
        maxLife = 100 * attributesCount * ATTRIBUTE_PROPORTION;
        life = maxLife;
    }
    
    void Update()
    {
        float lifeToUpdate = life + GetLifeUpdateValue();
        if (lifeToUpdate > maxLife)
        {
            SetLife(maxLife);
        } else if (lifeToUpdate < 0)
        {
            SetLife(0);
        } else
        {
            SetLife(lifeToUpdate);
        }
        DecreasePlantAttributes();

        Debug.Log(plant.name + ": " + life);
    }

    private float GetLifeUpdateValue()
    {
        BiomaState biomaState = getBiomaState();

        float distanceCount = 0;
        distanceCount += GetDistance(biomaState.biomaAttributes);
        distanceCount += GetDistance(plantAttributes);
        Debug.Log("Distance: " + distanceCount);
        distanceCount = distanceCount * Time.deltaTime;

        bool hasDamage = distanceCount > 0;
        if (hasDamage)
        {
            return -distanceCount;
        }
        else
        {
            var attributesCount = Enum.GetNames(typeof(Attributes)).Length;
            float recoveryLife = attributesCount * LIFE_RECOVERY_FACTOR;
            return recoveryLife * Time.deltaTime;
        }
    }

    private float GetDistance(Dictionary<Attributes, float> specs)
    {
        float distanceCount = 0;
        foreach (var attribute in specs)
        {
            float distance = plant.specs[attribute.Key].getDistance(attribute.Value);
            Debug.Log(attribute.Key + ": " + plant.specs[attribute.Key] + ": value " + attribute.Value + " -> distance " + distance);
            distanceCount += distance;

            if(distance != 0)
                GetComponent<PlantController>().AddAttributeNeeded(attribute.Key);
            else
                GetComponent<PlantController>().RemoveAttributeNeeded(attribute.Key);
        }
        return distanceCount;
    }

    private void SetLife(float life)
    {
        this.life = life;
        this.lifeProportion = (life / this.maxLife) * 100;
    }

    public void IncreaseSoilHumidity() {
        IncreaseAttribute(Attributes.SOIL_HUMIDITY);
    }

    public void IncreaseSoilNutrients() {
        IncreaseAttribute(Attributes.SOIL_NUTRIENTS);
    }

    private void DecreasePlantAttributes()
    {
        float soilNutrients = 100f;
        float soilHumidity = 25f;
        DecreaseAttribute(Attributes.SOIL_NUTRIENTS, soilNutrients / DECREASE_WEIGHT);

        BiomaState biomaState = getBiomaState();
        float temperature = biomaState.biomaAttributes[Attributes.TEMPERATURE];
        DecreaseAttribute(Attributes.SOIL_HUMIDITY, (soilHumidity + temperature) / DECREASE_WEIGHT);
    }

    private void IncreaseAttribute(Attributes attribute)
    {
        float value = plantAttributes[attribute];
        value += DEFAULT_PLANT_ATTRIBUTE_CHANGE_FACTOR;
        float maxAttributeValue = 100;
        value = value > maxAttributeValue ? maxAttributeValue : value;
        plantAttributes[attribute] = value;
    }

    private void DecreaseAttribute(Attributes attribute, float changeAttributeFactor)
    {
        float value = plantAttributes[attribute];
        value -= (changeAttributeFactor * Time.deltaTime);
        float minAttributeValue = 0;
        value = value < minAttributeValue ? minAttributeValue : value;
        plantAttributes[attribute] = value;
    }

    private BiomaState getBiomaState()
    {
        return GameObject.Find("Bioma").GetComponent<BiomaState>();
    }

}

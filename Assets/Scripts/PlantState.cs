using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantState : MonoBehaviour
{

    private static readonly int ATTRIBUTE_PROPORTION = 10;

    public Plant plant;
    public Dictionary<Attributes, float> plantAttributes = new Dictionary<Attributes, float>();

    private float maxLife;
    private float life;
    private float lifeProportion;
    
    void Start()
    {
        plantAttributes.Add(Attributes.SOIL_HUMIDITY, 100);
        plantAttributes.Add(Attributes.SOIL_NUTRIENTS, 100);

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
        Debug.Log(plant.name + ": " + life);
    }

    private float GetLifeUpdateValue()
    {
        BiomaState biomaState = GameObject.Find("Bioma").GetComponent<BiomaState>();

        float distanceCount = 0;
        distanceCount += GetDistance(biomaState.biomaAttributes);
        distanceCount += GetDistance(plantAttributes);
        Debug.Log("Before delta time: " + distanceCount);
        distanceCount = distanceCount * Time.deltaTime;
        Debug.Log("After delta time: " + distanceCount);

        bool hasDamage = distanceCount > 0;
        if (hasDamage)
        {
            return -distanceCount;
        }
        else
        {
            var attributesCount = Enum.GetNames(typeof(Attributes)).Length;
            return attributesCount * 100;
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
        }
        return distanceCount;
    }

    private void SetLife(float life)
    {
        this.life = life;
        this.lifeProportion = (life / this.maxLife) * 100;
        
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;

public class PlantState : MonoBehaviour
{

    private int ATTRIBUTE_PROPORTION = 10;

    public Dictionary<Attributes, AttributeRange> plantSpecs = new Dictionary<Attributes, AttributeRange>();
    public Dictionary<Attributes, float> plantAttributes = new Dictionary<Attributes, float>();

    public float maxLife;
    public float life;
    public float lifeProportion;
    
    void Start()
    {
        // TODO Substituir pela leitura do JSON da espécie
        plantSpecs.Add(Attributes.TEMPERATURE, new AttributeRange(0, 100));
        plantSpecs.Add(Attributes.AIR_HUMIDITY, new AttributeRange(0, 100));
        plantSpecs.Add(Attributes.SOIL_HUMIDITY, new AttributeRange(0, 100));
        plantSpecs.Add(Attributes.SOIL_NUTRIENTS, new AttributeRange(0, 100));

        plantAttributes.Add(Attributes.SOIL_HUMIDITY, 100);
        plantAttributes.Add(Attributes.SOIL_NUTRIENTS, 100);

        var attributesCount = Enum.GetNames(typeof(Attributes)).Length;
        float maxLife = 100 * attributesCount * ATTRIBUTE_PROPORTION;
        float life = maxLife;
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
        
    }

    private float GetLifeUpdateValue()
    {
        // TODO Obter o estado do bioma
        BiomaState biomaState = new BiomaState();

        float distanceCount = 0;
        foreach (var biomaAttribute in biomaState.biomaAttributes)
        {
            distanceCount += plantSpecs[biomaAttribute.Key].getDistance(biomaAttribute.Value);
        }
        foreach (var plantAttribute in plantAttributes)
        {
            distanceCount += plantSpecs[plantAttribute.Key].getDistance(plantAttribute.Value);
        }
        distanceCount = distanceCount * Time.deltaTime;

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

    private void SetLife(float life)
    {
        this.life = life;
        this.lifeProportion = (life / this.maxLife) * 100;
        
    }

}

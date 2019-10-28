using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomaState : MonoBehaviour
{

    public Dictionary<Attributes, AttributeRange> biomaSpecs = new Dictionary<Attributes, AttributeRange>();
    public Dictionary<Attributes, float> biomaAttributes = new Dictionary<Attributes, float>();

    void Start()
    {
        // TODO Substituir pela leitura do JSON do bioma
        biomaSpecs.Add(Attributes.TEMPERATURE, new AttributeRange(30, 60));
        biomaSpecs.Add(Attributes.AIR_HUMIDITY, new AttributeRange(80, 100));

        biomaAttributes.Add(Attributes.TEMPERATURE, 100);
        biomaAttributes.Add(Attributes.AIR_HUMIDITY, 100);
    }
    
    void Update()
    {
    }
}

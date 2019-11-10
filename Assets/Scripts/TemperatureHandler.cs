using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureHandler : MonoBehaviour
{

    public BiomaState biomaState;
    private bool increaseTemperature = false;
    private bool decreaseTemperature = false;

    public void IncreaseTemperature(bool pointerDown)
    {
        increaseTemperature = pointerDown;
    }

    public void DecreaseTemperature(bool pointerDown)
    {
        decreaseTemperature = pointerDown;
    }

    void Update()
    {
        LoadBiomaState();
        if (increaseTemperature)
        {
            biomaState.IncreaseTemperature();
        } else if (decreaseTemperature)
        {
            biomaState.DecreaseTemperature();
        }
    }

    public void LoadBiomaState()
    {
        if (biomaState == null)
        {
            this.biomaState = GameObject.Find("Bioma").GetComponent<BiomaState>();
        }
    }

}

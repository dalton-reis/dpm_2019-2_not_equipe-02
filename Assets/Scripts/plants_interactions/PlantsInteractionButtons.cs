using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsInteractionButtons : MonoBehaviour {

    [SerializeField] private GameObject removePlantHandlerPrefab;
    [SerializeField] private GameObject waterPlantHandlerPrefab;
    [SerializeField] private GameObject nutrientsPlantHandlerPrefab;

    public void RemovePlantButton() {
        GameObject removeObject = Instantiate(removePlantHandlerPrefab);
        SetParent(removeObject);
    }

    public void WaterPlantButton() {
        GameObject waterObject = Instantiate(waterPlantHandlerPrefab);
        SetParent(waterObject);
    }

    public void NutrientsPlantButton() {
        GameObject nutrientsObject = Instantiate(nutrientsPlantHandlerPrefab);
        SetParent(nutrientsObject);
    }

    private void SetParent(GameObject obj) {
        obj.transform.SetParent(GameObject.Find("Canvas").transform);
    }

}

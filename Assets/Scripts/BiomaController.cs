using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomaController : MonoBehaviour {

    [HideInInspector] public Bioma bioma;

    private List<PlantController> plants = new List<PlantController>();

    public string Name { get => bioma.name; }
    public Sprite Image { get => Resources.Load<Sprite>(bioma.image); }
    public Plant[] Plants { get => bioma.plants; }

    private GameObject plantPrefab;
    private string plantToBeInstantiated;

    void Start() {
        plantPrefab = Resources.Load<GameObject>("prefabs/plant");
    }

    public void InstantiatePlant(Vector2 position) {
        GameObject newPlant = Instantiate(plantPrefab, position, Quaternion.identity);
        newPlant.transform.SetParent(GameObject.Find("Plants").transform);
        newPlant.name = plantToBeInstantiated;
        newPlant.GetComponent<PlantController>().plant = FindPlantByName(plantToBeInstantiated);
        plants.Add(newPlant.GetComponent<PlantController>());
    }

    public void SetPlantToBeInstantiated(string name) {
        plantToBeInstantiated = name;
    }

    private Plant FindPlantByName(string name) {
        foreach (Plant plant in Plants) {
            if(plant.name == name)
                return plant;
        }
        return null;
    }

}
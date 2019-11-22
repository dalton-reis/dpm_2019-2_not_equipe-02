using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiomaController : MonoBehaviour {

    [HideInInspector] public Bioma bioma;
    [HideInInspector] public Plant[] plantsList;

    private List<PlantController> plants = new List<PlantController>();
    
    public string Name { get => bioma.name; }
    public Sprite Image { get => Resources.Load<Sprite>(bioma.image); }
    public AttributeRange Temperature { get => bioma.specs[Attributes.TEMPERATURE]; }

    private GameObject plantPrefab;
    private string plantToBeInstantiated;

    void Start() {
        plantPrefab = Resources.Load<GameObject>("prefabs/plant");
    }

    public GameObject InstantiatePlant(Vector2 position) {
        GameObject newPlant = Instantiate(plantPrefab, position, Quaternion.identity);
        newPlant.transform.SetParent(GameObject.Find("Plants").transform);
        newPlant.name = plantToBeInstantiated;

        Plant plant = FindPlantByName(plantToBeInstantiated);
        newPlant.GetComponent<PlantController>().plant = plant;
        newPlant.GetComponent<PlantState>().plant = plant;

        plants.Add(newPlant.GetComponent<PlantController>());

        EventLogger.Get().Log(new EventModel(LogEventType.PLANT_PLANTED, plant.name));

        return newPlant;
    }

    public void SetPlantToBeInstantiated(string name) {
        plantToBeInstantiated = name;
    }

    private Plant FindPlantByName(string name) {
        foreach (Plant plant in plantsList) {
            if(plant.name == name)
                return plant;
        }
        return null;
    }

}
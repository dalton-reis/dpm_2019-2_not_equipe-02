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

    void Start() {
        plantPrefab = Resources.Load<GameObject>("prefabs/plant");
    }

    public void InstantiatePlant(Text name) {
        GameObject newPlant = Instantiate(plantPrefab, new Vector2(0, 0), Quaternion.identity);
        newPlant.transform.SetParent(GameObject.Find("Canvas").transform);
        newPlant.name = name.text;
        newPlant.GetComponent<PlantController>().plant = FindPlantByName(name.text);
        plants.Add(newPlant.GetComponent<PlantController>());
    }

    private Plant FindPlantByName(string name) {
        foreach (Plant plant in Plants) {
            if(plant.name == name)
                return plant;
        }
        return null;
    }

}
using UnityEngine;
using UnityEngine.UI;

public class ItemListDetails : MonoBehaviour {
    
    public Image image;
    public Text text;
    private BiomaController biomaController;
    private GameManager gameManager;

    void Start() {
        biomaController = GameObject.FindObjectOfType<BiomaController>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    public void SelectPlant() {
        biomaController.SetPlantToBeInstantiated(text.text);
        gameManager.ShowPlantSpawns(true);
        InstantiatePlant();
    }

    public void InstantiatePlant() {
        GameObject newPlant = biomaController.InstantiatePlant(new Vector2(transform.position.x, transform.position.y + 50));
        
        Plant plant = newPlant.GetComponent<PlantController>().plant;
        newPlant.transform.position = new Vector2(transform.position.x, transform.position.y + plant.height/2 - 90);
    }

}

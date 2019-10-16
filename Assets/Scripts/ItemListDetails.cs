using UnityEngine;
using UnityEngine.UI;

public class ItemListDetails : MonoBehaviour {
    
    public Image image;
    public Text text;
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        
    }
    
    public void InstantiatePlant() {
        foreach (GameObject plant in gameManager.Plants) {
            if(plant.GetComponent<PlantModel>().PlantName == this.text.text) {
                GameObject newPlant = Instantiate(plant, new Vector2(1000, 1000), Quaternion.identity);
                newPlant.transform.SetParent(gameManager.gameObject.transform);
                newPlant.GetComponent<DragAndDrop>().dragging = true;
                gameManager.ActivePlants.Add(newPlant);
                break;
            }
        }
    }

    public void DropPlant() {
        gameManager.ActivePlants[gameManager.ActivePlants.Count-1]
            .GetComponent<DragAndDrop>().dragging = false;
    }
}

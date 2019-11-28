using UnityEngine;

public class PlantSpawn : MonoBehaviour {

    private BiomaController biomaController;
    private GameManager gameManager;

    void Start() {
        biomaController = GameObject.FindObjectOfType<BiomaController>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void InstantiatePlant() {
        GameObject newPlant = biomaController.InstantiatePlant(new Vector2(transform.position.x, transform.position.y + 50));
        
        Plant plant = newPlant.GetComponent<PlantController>().plant;
        newPlant.transform.position = new Vector2(transform.position.x, transform.position.y + plant.height/2 - 90);

        gameManager.ShowPlantSpawns(false);
        
        newPlant.GetComponent<PlantController>().SpawnPoint = gameObject;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant"))
            LockPlantPosition(other.gameObject);
    }

    private void LockPlantPosition(GameObject obj) {
        Plant plant = obj.GetComponent<PlantController>().plant;
        obj.transform.position = new Vector2(transform.position.x, transform.position.y + plant.height/2 - 90);

        gameManager.ShowPlantSpawns(false);
        
        obj.GetComponent<PlantController>().SpawnPoint = gameObject;
        Destroy(obj.GetComponent<DragAndDrop>());
        gameObject.SetActive(false);
    }
}

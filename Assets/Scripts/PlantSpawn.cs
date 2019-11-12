using UnityEngine;

public class PlantSpawn : MonoBehaviour {

    private BiomaController biomaController;
    private GameManager gameManager;

    void Start() {
        biomaController = GameObject.FindObjectOfType<BiomaController>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    public void InstantiatePlant() {
        biomaController.InstantiatePlant(new Vector2(transform.position.x, transform.position.y+50));
        gameManager.ShowPlantSpawns(false);
        Destroy(gameObject);
    }
}

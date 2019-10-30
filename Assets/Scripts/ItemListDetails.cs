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
    }

}

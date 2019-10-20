using UnityEngine;
using UnityEngine.UI;

public class ItemListDetails : MonoBehaviour {
    
    public Image image;
    public Text text;
    private BiomaController biomaController;

    void Start() {
        biomaController = GameObject.FindObjectOfType<BiomaController>();
    }
    
    public void InstantiatePlant() {
        biomaController.InstantiatePlant(text);
    }

}

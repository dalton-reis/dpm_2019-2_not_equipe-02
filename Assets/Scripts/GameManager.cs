using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Image background;
    [SerializeField] private Text title;

    void Start() {
        BiomaController bioma = FindObjectOfType<BiomaController>();
        background.sprite = bioma.Image;
        title.text = bioma.Name;
    }

}

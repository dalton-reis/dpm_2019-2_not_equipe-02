using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Image background;
    [SerializeField] private Text title;
    [SerializeField] private GameObject plantSpawns;
    [SerializeField] private GameObject plantsList;
    
    private int instantiatedPlantsCount;
    private int maxInstantiatedPlantsCount = 4;

    [SerializeField] private Text plantNameText;
    [SerializeField] private Text plantDescriptionText;
    [SerializeField] private Image plantImageSprite;
    [SerializeField] private GameObject plantInfoPanel;

    public int InstantiatedPlantsCount { 
        get => instantiatedPlantsCount; 
        set {
            if(value < maxInstantiatedPlantsCount) {
                instantiatedPlantsCount = value;
                plantsList.SetActive(true);
            } else {
               instantiatedPlantsCount = maxInstantiatedPlantsCount;
               plantsList.SetActive(false);
            }
        }
    }

    void Start() {
        BiomaController bioma = FindObjectOfType<BiomaController>();
        background.sprite = bioma.Image;
        title.text = bioma.Name;
    }

    public void ShowPlantSpawns(bool show) {
        plantSpawns.SetActive(show);
    }

    public void ShowPlantInfoPanel(Plant plant) {
        plantNameText.text = plant.name;
        plantDescriptionText.text = plant.description;
        plantImageSprite.sprite = Resources.Load<Sprite>(plant.image);
        plantInfoPanel.SetActive(true);
    }

    public void HidePlantInfoPanel() {
        plantInfoPanel.SetActive(false);
    }

}

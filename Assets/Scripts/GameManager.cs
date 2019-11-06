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

    [SerializeField] private SimpleHealthBar healthBar;

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
        BiomaController biomaController = FindObjectOfType<BiomaController>();
        background.sprite = biomaController.Image;
        title.text = biomaController.Name;

        healthBar.UpdateBar(biomaController.Temperature.minValue, biomaController.Temperature.maxValue);
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

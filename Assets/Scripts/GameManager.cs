using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private Image background;
    [SerializeField] private Text title;
    [SerializeField] private GameObject plantSpawns;
    [SerializeField] private GameObject plantsList;
    
    private int instantiatedPlantsCount;
    private int maxInstantiatedPlantsCount = 4;

    [SerializeField] private Text plantNameText;
    [SerializeField] private Text scientificNameText;
    [SerializeField] private Text plantDescriptionText;
    [SerializeField] private Image plantImageSprite;
    [SerializeField] private GameObject plantInfoPanel;

    [SerializeField] private Text biomaNameText;
    [SerializeField] private Text biomaDescriptionText;
    [SerializeField] private GameObject biomaInfoPanel;

    [SerializeField] private GameObject logEventPanel;
    [SerializeField] private Text logEventText;

    [SerializeField] private SimpleHealthBar healthBar;

    private BiomaController biomaController;

    public int InstantiatedPlantsCount { 
        get => instantiatedPlantsCount; 
        set {
            if(value < maxInstantiatedPlantsCount) {
                instantiatedPlantsCount = value;
                if(!plantsList.activeSelf)
                    plantsList.SetActive(true);
            } else {
               instantiatedPlantsCount = maxInstantiatedPlantsCount;
               plantsList.SetActive(false);
            }
        }
    }

    void Start() {
        biomaController = FindObjectOfType<BiomaController>();
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
        scientificNameText.text = "(" + plant.scientificName + ")";
        plantImageSprite.sprite = Resources.Load<Sprite>(plant.image);
        plantInfoPanel.SetActive(true);
    }

    public void HidePlantInfoPanel() {
        plantInfoPanel.SetActive(false);
    }

    public void ShowBiomaInfoPanel() {
        Bioma bioma = biomaController.bioma;

        biomaNameText.text = bioma.name;
        biomaDescriptionText.text = bioma.description;
        biomaInfoPanel.SetActive(true);
    }

    public void HideBiomaInfoPanel() {
        biomaInfoPanel.SetActive(false);
    }

    public void ShowLogPanel()
    {
        logEventText.text = EventLogger.Get().executionId;
        logEventPanel.SetActive(true);
    }

    public void HideLogPanel()
    {
        logEventPanel.SetActive(false);
    }

    public void BackToMenu() {
        Destroy(GameObject.FindObjectOfType<BiomaController>().gameObject);
        SceneManager.LoadScene("Scenarios");
    }

}

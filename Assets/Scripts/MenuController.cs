using UnityEngine;

public class MenuController : MonoBehaviour {
    
    [SerializeField] private GameObject equipeButton;
    [SerializeField] private GameObject areaProfessorButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject equipePanel;

    public void ShowEquipePanel() {
        equipeButton.SetActive(false);
        areaProfessorButton.SetActive(false);
        quitButton.SetActive(false);
        startPanel.SetActive(false);
        equipePanel.SetActive(true);
    }

    public void ShowMainPanel() {
        equipePanel.SetActive(false);
        equipeButton.SetActive(true);
        areaProfessorButton.SetActive(true);
        quitButton.SetActive(true);
        startPanel.SetActive(true);
    }

    public void OpenAmbienteProfessor() {
        Application.OpenURL("https://terrario-virtual-furb.herokuapp.com/");
    }

}

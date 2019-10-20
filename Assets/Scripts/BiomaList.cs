using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BiomaList : MonoBehaviour {

    private Bioma[] biomas;
    public GameObject[] buttons;

    void Start() {
        biomas = JsonReader.LoadBiomas();

        LoadBiomaButtons();
    }

    private void LoadBiomaButtons() {
        for(int i = 0; i < biomas.Length; i++) {
            buttons[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(biomas[i].image);
            buttons[i].GetComponentInChildren<Text>().text = biomas[i].name;
        }
    }

    public void LoadScene(Text name) {
        GameObject bioma = new GameObject("Bioma");
        BiomaController component = bioma.AddComponent<BiomaController>();
        component.bioma = GetBiomaByName(name.text);
        DontDestroyOnLoad(component);
        SceneManager.LoadScene("Bioma");
    }

    private Bioma GetBiomaByName(string name) {
        foreach(Bioma bioma in biomas) {
            if(bioma.name == name)
                return bioma;
        }
        return null;
    }
}

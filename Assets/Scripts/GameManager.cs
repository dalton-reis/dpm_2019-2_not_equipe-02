using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private GameObject[] plants;

    void Start() {
        foreach(GameObject plant in plants) {
            GameObject newPlant = Instantiate(plant);
            newPlant.transform.parent = this.transform;
        }
    }

    void Update() {
        
    }
    public GameObject[] GetPlants() {
        return plants;
    }
}

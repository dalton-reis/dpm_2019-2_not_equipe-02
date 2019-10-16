using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField] private GameObject[] plants;
    private List<GameObject> activePlants = new List<GameObject>();
    public List<GameObject> ActivePlants { get => activePlants; }

    public GameObject[] Plants { get => plants; }


    void Start() {
        
    }

    void Update() {
        
    }
}

using UnityEngine;

public class WaterPlantHandler : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant")) {
            Debug.Log("Agua a planta.");
            Destroy(gameObject);
        }
    }

}

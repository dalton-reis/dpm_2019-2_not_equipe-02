using UnityEngine;

public class NutrientsPlantHandler : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant")) {
            Debug.Log("Dá nutrientes pra planta");
            Destroy(gameObject);
        }
    }

}

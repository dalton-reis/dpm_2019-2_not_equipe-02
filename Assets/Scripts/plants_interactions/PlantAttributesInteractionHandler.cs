using UnityEngine;

public class PlantAttributesInteractionHandler : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant")) {
            if(gameObject.CompareTag("SOIL_NUTRIENTS")) {
                other.GetComponent<PlantState>().IncreaseSoilNutrients();
            }
            else if(gameObject.CompareTag("SOIL_HUMIDITY")) {
                other.GetComponent<PlantState>().IncreaseSoilHumidity();
            } 
            else if(gameObject.CompareTag("REMOVE")) {
                Destroy(other.gameObject);
            }
            Destroy(gameObject);
        }
    }

}

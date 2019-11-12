using UnityEngine;

public class RemovePlantHandler : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Plant")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}

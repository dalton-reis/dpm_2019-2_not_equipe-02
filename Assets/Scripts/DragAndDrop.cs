using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : EventTrigger {

    private bool dragging;

    private Vector2 screenBounds;
    private float objectWidth = 80;
    private float objectHeight = 100;

    void Start() {
        // Image img = GetComponent<Image>();
        // objectWidth = img.sprite.bounds.extents.x;
        // objectHeight = img.sprite.bounds.extents.y;

        Camera.main.transform.position = new Vector3(Screen.width, Screen.height, -10);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    void Update() {
        if (dragging) {
            Vector3 viewPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            viewPos.x = Mathf.Clamp(viewPos.x, 0+objectWidth, screenBounds.x-objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, 0+objectHeight, screenBounds.y-objectHeight);
            transform.position = viewPos;  
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
    }

}
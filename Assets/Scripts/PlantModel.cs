using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlantModel : MonoBehaviour {
    
    // these attributes' values are defined via Unity interface
    [SerializeField] private string plantName;
    [SerializeField] private string description;
    [SerializeField] private Sprite image;
    [SerializeField] private float width = 215f;
    [SerializeField] private float height = 215f;

    public string PlantName { get => plantName; }
    public string Description { get => description; }
    public Sprite Image { get => image; }
    public float Width { get => width; }
    public float Height { get => height; }

    private const float GRAVITY_SCALE = 100f;

    private void Start() {
        SetVisual();
        SetPhysicAttributes();
        SetName(plantName);
    }

    private void Update() { }

    private void SetVisual() {
        GetComponent<RectTransform>().localPosition = Vector2.zero;
        GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        GetComponent<Image>().sprite = image;
    }

    private void SetPhysicAttributes() {
        GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<BoxCollider2D>().size = new Vector2(width, height);
    }
    
    private void SetName(string name) {
        gameObject.name = name;
    }

}

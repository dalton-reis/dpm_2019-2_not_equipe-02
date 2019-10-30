using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlantController : MonoBehaviour {
    
    [HideInInspector] public Plant plant;

    private GameManager gameManager;

    public string PlantName { get => plant.name; }
    public string Description { get => plant.description; }
    public Sprite Image { get => Resources.Load<Sprite>(plant.image); }
    public float Width { get => plant.width; }
    public float Height { get => plant.height; }

    [SerializeField] private SimpleHealthBar healthBar;

    private const float GRAVITY_SCALE = 100f;
    private float currentHealth;

    private void Start() {
        SetVisual();
        SetPhysicAttributes();
        SetName(name);

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void FixedUpdate() { 
        healthBar.UpdateBar(currentHealth, 100);
        currentHealth += 8f * Time.deltaTime;
        if(currentHealth >= 100)
            currentHealth = 0;
    }

    private void SetVisual() {
        // GetComponent<RectTransform>().localPosition = Vector2.zero;
        GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
        GetComponent<Image>().sprite = Image;
    }

    private void SetPhysicAttributes() {
        GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<BoxCollider2D>().size = new Vector2(Width, Height);
    }
    
    private void SetName(string name) {
        gameObject.name = name;
    }

    public override string ToString() => plant.ToString();

    public void ShowPlantInfos() {
        gameManager.ShowPlantInfoPanel(this.plant);
    }

}

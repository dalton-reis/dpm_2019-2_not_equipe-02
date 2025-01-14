﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlantController : MonoBehaviour {
    
    [HideInInspector] public Plant plant;

    private GameManager gameManager;
    private GameObject spawnPoint;

    public string PlantName { get => plant.name; }
    public string Description { get => plant.description; }
    public Sprite Sprite { get => Resources.Load<Sprite>(plant.sprite); }
    public Sprite Image { get => Resources.Load<Sprite>(plant.image); }
    public float Width { get => plant.width; }
    public float Height { get => plant.height; }
    public GameObject SpawnPoint { get => spawnPoint; set => spawnPoint = value; }

    [SerializeField] private SimpleHealthBar healthBar;
    [SerializeField] private GameObject[] warnings;

    private const float GRAVITY_SCALE = 100f;
    private float currentHealth;

    private PlantState plantState;
    private HashSet<AttributeWarning> attributesNeeded = new HashSet<AttributeWarning>();

    private bool isDead = false;

    [SerializeField] private Sprite deadPlantSprite;


    private void Start() {
        plantState = GetComponent<PlantState>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        SetVisual();
        SetPhysicsAttributes();
        SetName(name);

        gameManager.InstantiatedPlantsCount++;
    }

    private void Update() { 
        healthBar.UpdateBar(plantState.life, plantState.maxLife);

        if(plantState.isDead)
            ChangeSpriteToDeadPlant();

        SetAttributesWarning();
    }

    private void SetVisual() {
        GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Height);
        GetComponent<Image>().sprite = Sprite;
    }

    private void SetPhysicsAttributes() {
        GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<BoxCollider2D>().size = new Vector2(Width, Height);
    }
    
    private void SetName(string name) {
        gameObject.name = name;
    }

    public void ShowPlantInfos() {
        gameManager.ShowPlantInfoPanel(this.plant, plantState.isDead);
    }

    public void SetAttributesWarning() {
        foreach(GameObject warning in warnings)
            warning.SetActive(false);
            
        foreach (AttributeWarning attribute in attributesNeeded) {
            foreach(GameObject warning in warnings) {
                if(warning.name == attribute.ToString())
                {
                    warning.SetActive(true);
                    warning.GetComponent<Image>().color = attribute.distance > 0 ?
                        new Color32(217, 38, 38, 255) :
                        new Color32(255, 255, 255, 255);
                }
            }
        }
    }

    private void ChangeSpriteToDeadPlant() {
        GetComponent<Image>().sprite = deadPlantSprite;
        GetComponent<Image>().color = new Color32(159, 34, 36, 255);
    }

    public void AddAttributeNeeded(Attributes attribute, float distance) {
        attributesNeeded.Add(new AttributeWarning(attribute, distance));
    }

    public void RemoveAttributeNeeded(Attributes attribute) {
        attributesNeeded.Remove(new AttributeWarning(attribute, 0));
    }

    private void OnDestroy() {
        gameManager.InstantiatedPlantsCount--;
        if(spawnPoint != null && !spawnPoint.activeSelf)
            spawnPoint.SetActive(true);
    }

    public override string ToString() => plant.ToString();
}

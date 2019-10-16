using UnityEngine;

public class ListCreator : MonoBehaviour {

    private GameObject[] plants;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject item;
    [SerializeField] private RectTransform content;

    private float itemHeight;

	void Start () {
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        plants = GameObject.FindObjectOfType<GameManager>().Plants;

        content.sizeDelta = new Vector2(0, plants.Length * itemHeight);

        for(int i = 0; i < plants.Length; i++) {
            float spawnY = i * itemHeight;
            
            Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
            GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
            
            spawnedItem.transform.SetParent(spawnPoint, false);
            spawnedItem.transform.position = new Vector3(pos.x, spawnedItem.transform.position.y, spawnedItem.transform.position.z);

            ItemListDetails itemDetails = spawnedItem.GetComponent<ItemListDetails>();
            
            itemDetails.text.text = plants[i].GetComponent<PlantModel>().PlantName;
            itemDetails.image.sprite = plants[i].GetComponent<PlantModel>().Image;
            
            itemDetails.image.GetComponent<RectTransform>().sizeDelta = new Vector2(
                plants[i].GetComponent<PlantModel>().Width / 2,
                plants[i].GetComponent<PlantModel>().Height / 2
            );
        }
	}
}
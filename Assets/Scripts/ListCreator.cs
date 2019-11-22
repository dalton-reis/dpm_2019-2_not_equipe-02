using UnityEngine;

public class ListCreator : MonoBehaviour {

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject item;
    [SerializeField] private RectTransform content;

    private float itemHeight;

	void Start () {
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        Plant[] plants = GameObject.FindObjectOfType<BiomaController>().plantsList;

        content.sizeDelta = new Vector2(0, plants.Length * itemHeight);

        for(int i = 0; i < plants.Length; i++) {
            float spawnY = i * itemHeight;
            
            Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
            GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
            
            spawnedItem.transform.SetParent(spawnPoint, false);
            Vector3 itemPosition = spawnedItem.transform.position;
            spawnedItem.transform.position = new Vector3(pos.x, itemPosition.y, itemPosition.z);

            ItemListDetails itemDetails = spawnedItem.GetComponent<ItemListDetails>();
            
            itemDetails.text.text = plants[i].name;
            itemDetails.image.sprite = Resources.Load<Sprite>(plants[i].sprite);

            itemDetails.image.GetComponent<RectTransform>().sizeDelta = new Vector2(115, 115);
        }
	}
}
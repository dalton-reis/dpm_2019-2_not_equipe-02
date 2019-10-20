using System.Collections.Generic;
using UnityEngine;

public class ListCreator : MonoBehaviour {

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject item;
    [SerializeField] private RectTransform content;

    private float itemHeight;

	void Start () {
        itemHeight = item.GetComponent<RectTransform>().rect.height;
        Plant[] plants = GameObject.FindObjectOfType<BiomaController>().Plants;

        content.sizeDelta = new Vector2(0, plants.Length * itemHeight);

        for(int i = 0; i < plants.Length; i++) {
            float spawnY = i * itemHeight;
            
            Vector3 pos = new Vector3(spawnPoint.position.x, -spawnY, spawnPoint.position.z);
            GameObject spawnedItem = Instantiate(item, pos, spawnPoint.rotation);
            
            spawnedItem.transform.SetParent(spawnPoint, false);
            spawnedItem.transform.position = new Vector3(pos.x, spawnedItem.transform.position.y, spawnedItem.transform.position.z);

            ItemListDetails itemDetails = spawnedItem.GetComponent<ItemListDetails>();
            
            itemDetails.text.text = plants[i].name;
            itemDetails.image.sprite = Resources.Load<Sprite>(plants[i].image);
            
            itemDetails.image.GetComponent<RectTransform>().sizeDelta = new Vector2(
                plants[i].width / 2,
                plants[i].height / 2
            );
        }
	}
}
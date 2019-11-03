using UnityEngine;

public class JsonReader {

    private const string JSON_NAME = "biomas";

    private static TerrariumJsonData json;

    public static Bioma[] LoadBiomas () {
        LoadJson();
        foreach (var bioma in json.biomas)
        {
            RawAttributes.AddAttribute(bioma.specs, bioma.rawSpecs);
        }
        return json.biomas;
    }

    public static Plant[] LoadPlants()
    {
        LoadJson();
        foreach (var plant in json.plants)
        {
            RawAttributes.AddAttribute(plant.specs, plant.rawSpecs);
        }
        return json.plants;
    }

    private static void LoadJson()
    {
        if (json == null)
        {
            json = new TerrariumJsonData();
            TextAsset jsonTextFile = Resources.Load<TextAsset>(JSON_NAME);
            JsonUtility.FromJsonOverwrite(jsonTextFile.ToString(), json);
        }
    }
    
}

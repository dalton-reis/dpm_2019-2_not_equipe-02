using UnityEngine;

public class JsonReader {

    private const string JSON_NAME = "biomas";

    public static Bioma[] LoadBiomas () {
        BiomasFromJson json = new BiomasFromJson();
        
        TextAsset jsonTextFile = Resources.Load<TextAsset>(JSON_NAME);
        JsonUtility.FromJsonOverwrite(jsonTextFile.ToString(), json);

        return json.biomas;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData activeSave;

    public bool hasLoaded;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        instance = this;

        Load();
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        if(System.IO.File.Exists(dataPath + "/" + activeSave + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            hasLoaded = true;
        }    
    }

    public void UpdateDeck(string deck, string action, string cardId) 
    {
        Load();
        // deck1.Add(cardId);
        // var cardToRemove = deck1.Single(card => card == cardId);
        // deck1.Remove(cardToRemove);
    }
}

[System.Serializable]
public class SaveData
{
    public List<string> deck1;
    public List<string> deck2;
    public List<string> deck3;
    public List<string> deck4;
    public List<string> deck5;
    public List<string> deck6;
}

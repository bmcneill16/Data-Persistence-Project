using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
    public string playerName;
    public int bestScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance != null) //Will check to see if an instance of MainManager already exist in a scene, if yes, one instance will be destroyed, referred to as singleton
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
        
    }


    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = SaveManager.instance.playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + " /savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + " /savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(path);

            SaveManager.instance.playerName = data.playerName;
        }

    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;

        string jsonScore = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + " /savefile.json", jsonScore);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + " /savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(path);

            bestScore = data.bestScore;
        }
    }

}

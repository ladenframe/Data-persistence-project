using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    public string input;
    public int score;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }
    public void AssignName(string s)
    {
        input = s;
        Debug.Log(input);
    }
    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string name;
    }
    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.name = name;
        data.highScore = score;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            score = data.highScore;
            name = data.name;
        }
    }
    
   
}

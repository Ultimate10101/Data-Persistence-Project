using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveBestScore: MonoBehaviour 
{
    public static SaveBestScore Instance;

    public string BestScoreText;
    public int BestScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        LoadBestScoreInfo();
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public string BestScoreText;
        public int BestScore;
    }

    private void OnApplicationQuit()
    {
        SaveBestScoreInfo();
    }


    public void SaveBestScoreInfo()
    {
        SaveData data = new SaveData();
        data.BestScoreText = BestScoreText;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScoreInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScoreText = data.BestScoreText;
            BestScore = data.BestScore;
        }
        else
        {
            BestScoreText = "";
            BestScore = 0;
        }
    }
}

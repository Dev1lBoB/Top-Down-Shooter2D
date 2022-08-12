using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreController : SingletonBehaviour<ScoreController>
{
    [SerializeField]
    private Text scoreText;

    private int score = 0;
    private int maxScore = 0;

    private void Start()
    {
        SetScoreText();
        Load();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetMaxScore()
    {
        return maxScore;
    }

    public void AddScore(int amount)
    {
        score += amount;
        SetScoreText(); 
    }

    public void SetNewRecord()
    {
        maxScore = score;
        Save();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void Save()
    {
        // Serializse and saves all the necessary data into the file named "MaxScore.gd"
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MaxScore.gd");
        bf.Serialize(file, maxScore);
        file.Close();
    }

    public void Load()
    {
        // Deseializes file "MaxScore.gd" and extracts all the data
        if (File.Exists(Application.persistentDataPath + "/MaxScore.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MaxScore.gd", FileMode.Open);
            maxScore = (int)bf.Deserialize(file);
            file.Close();
        }
    }
}

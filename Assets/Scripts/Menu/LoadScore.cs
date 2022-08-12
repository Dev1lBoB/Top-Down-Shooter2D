using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadScore : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int maxScore;

    private void Start()
    {
        Load();
        scoreText.text = "Best score: " + maxScore;
    }

    public void Load()
    {
        // Deseialize file "MaxScore.gd" and extract all the data
        if (File.Exists(Application.persistentDataPath + "/MaxScore.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MaxScore.gd", FileMode.Open);
            maxScore = (int)bf.Deserialize(file);
            file.Close();
        }
    }
}

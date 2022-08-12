using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : SingletonBehaviour<GameController>
{
    [SerializeField]
    private SceneChanger    sceneChanger; 
    [SerializeField]
    private GameObject      mainCanvas;
    [SerializeField]
    private GameObject      dialogPanelPrefab;

    private int     score;
    private bool    newRecord = false;

    public void GameFinished()
    {
        // Calls after players death
        Pause();
        score = ScoreController.sharedInstance.GetScore();
        if (score > ScoreController.sharedInstance.GetMaxScore())
        {
            ScoreController.sharedInstance.SetNewRecord();
            newRecord = true;
        }
        ShowDialog();
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
    }

    private void RestartPressed()
    {
        Unpause();
        sceneChanger.ReloadScene();
    }

    private void ToMenuPressed()
    {
        Unpause();
        sceneChanger.ChangeScene(0);
    }

    private void ShowDialog()
    {
        YesNoDialog.ShowDialog
        (
            Instantiate(dialogPanelPrefab, mainCanvas.transform),
            null,
            "Score: " + score + (newRecord == true ? Environment.NewLine +"NEW RECORD!" : ""),

            "Restart",
            () => RestartPressed(),

            "Menu",
            () => ToMenuPressed()
        );
    }
    
}

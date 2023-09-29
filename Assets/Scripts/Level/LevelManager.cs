﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;
    private void Awake()
    {
      if(instance == null)
      {

            instance = this;
            DontDestroyOnLoad(gameObject);

      }
      else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
       if( GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }
    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        /* int nextSceneIndex = currentscene.buildIndex + 1;
         Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
         SetLevelStatus(nextScene.name, LevelStatus.Unlocked);
        */
        int currentSceneIndex = Array.FindIndex(Levels, i => i == currentScene.name);
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
            Debug.Log("Setting Level Unlocked");        
        
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
       LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
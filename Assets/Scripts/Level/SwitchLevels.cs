﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevels : MonoBehaviour
{
    [SerializeField]
    private bool isChecked = false;

    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter2D(Collider2D collision)
    {

       
        if (collision.gameObject.GetComponent<PlayerController>()!=null)
        {
            isChecked = true;
            LevelManager.Instance.MarkCurrentLevelComplete();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            isChecked = false;
           

        }
    }
}
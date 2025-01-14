﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthManager : MonoBehaviour

{
    public ParticleController particleController;
    public GameOverController gameOverController;
    public static int health;

    public Image[] hearts;

    public Sprite fullHeart;

    public Sprite emptyHeart;

    private void Start()
    {
        health = 3;
        foreach (Image img in hearts)
        {
            img.sprite = fullHeart;
        }
    }
    public void TakeDamage()
    {
        PlayerHealthManager.health--;
        if (PlayerHealthManager.health <= 0)
        {
            Debug.Log("Player got killed");
            particleController.PlayerWinEffect();

            gameOverController.playerDied();

            this.enabled = false;
        }
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void PlayerWinEffect()
    {
        gameObject.SetActive(true);
        particleSystem.Play();
    }

}
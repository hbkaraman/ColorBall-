﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoSingleton<ParticleManager>
{
    private GameObject LevelEndEffect;

    private void Start()
    {
        LevelEndEffect = ParticlePooler.SharedInstance.GetPooledObject(0);
    }

    public void LevelEndEffects()
    {
        LevelEndEffect.transform.position = Player.Instance.transform.position;
        LevelEndEffect.SetActive(true);
    }
   
}

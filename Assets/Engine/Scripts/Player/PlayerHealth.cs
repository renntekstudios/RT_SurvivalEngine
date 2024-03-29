﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int curHealth = 100;

    public float healthBarLength;

    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    void Update()
    {
        AddjustCurrentHealth(0);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLength, 20), curHealth + "/" + maxHealth);
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;

        if (curHealth < 1)
            Die();

        if (curHealth > maxHealth)
            curHealth = maxHealth;

        if (maxHealth < 1)
            maxHealth = 1;

        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

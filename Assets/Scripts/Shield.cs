﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynmaically")]
    public int levelShown = 0;

    // This non-public variable will not appear in the Inspector
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Read the current shield level from the Hero Singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        if(levelShown != currLevel)
        {
            levelShown = currLevel;
            // Adjust the texture offset to show the different shield level
            mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }
        // Rotate the shield a bir every frame in a time-based way
        float rZ = -(rotationsPerSecond * Time.time * 360) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")] public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")] public int levelShown = 0;

    // This non-public variable will not appear in the Inspector
    private Material _mat;

    private void Start()
    {
        _mat = GetComponent<Renderer>().material; // b
    }

    private void Update()
    {
        // Read the current shield level from the Player Singleton
        var currLevel = Mathf.FloorToInt(Player.S.ShieldLevel);
        // If this is different from levelShown...
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            // Adjust the texture offset to show different shield level
            _mat.mainTextureOffset = new Vector2(0.2f * levelShown, 0);
        }

        // Rotate the shield a bit every frame in a time-based way
        var rZ = -(rotationsPerSecond * Time.time * 3600) % 360f;
        transform.rotation = Quaternion.Euler(0, 0, rZ);
    }
}
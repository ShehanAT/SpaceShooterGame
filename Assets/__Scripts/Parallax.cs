﻿using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Set in Inspector")] public GameObject poi; // The player ship
    public GameObject[] panels; // The scrolling foregrounds

    public float scrollSpeed = -30f;

    // motionMult controls how much panels react to player movement
    public float motionMult = 0.25f;
    private float _panelHt; // Height of each panel
    private float _depth; // Depth of panels (that is, pos.z)

    private void Start()
    {
        _panelHt = panels[0].transform.localScale.y;
        _depth = panels[0].transform.position.z;
        // Set initial positions of panels
        panels[0].transform.position = new Vector3(0, 0, _depth);
        panels[1].transform.position = new Vector3(0, _panelHt, _depth);
    }

    private void Update()
    {
        float tX = 0;
        var tY = Time.time * scrollSpeed % _panelHt + (_panelHt * 0.5f);
        if (poi != null)
        {
            tX = -poi.transform.position.x * motionMult;
        }

        // Position panels[0]
        panels[0].transform.position = new Vector3(tX, tY, _depth);
        // Then position panels[1] where needed to make a continuous starfield
        panels[1].transform.position =
            tY >= 0 ? new Vector3(tX, tY - _panelHt, _depth) : new Vector3(tX, tY + _panelHt, _depth);
    }
}
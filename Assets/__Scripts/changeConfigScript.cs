﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeConfigScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToAudioScene()
    {
        SceneManager.LoadScene("AudioScene");
    }
    public void goToEnemiesScene() {
        SceneManager.LoadScene("");
    }
    public void goToBackgroundScene()
    {
        SceneManager.LoadScene("BackgroundScene");
    }
}

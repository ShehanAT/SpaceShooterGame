using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeMusicVolume : MonoBehaviour
{

    public Slider SpaceMusicVolume;
    public AudioSource SpaceMusicAudio;
    public Slider LaserVolume;
    public AudioSource LaserAudio;
    public Slider ExplosionVolume;
    public AudioSource ExplosionAudio;
    // Update is called once per frame
    void Update()
    {
        SpaceMusicAudio.volume = SpaceMusicVolume.value;
        LaserAudio.volume = LaserVolume.value;
        ExplosionAudio.volume = ExplosionVolume.value;
    }
    public void goToConfigScene()
    {
        SceneManager.LoadScene("ConfigScene");
    }

}

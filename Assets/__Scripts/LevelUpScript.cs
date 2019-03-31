using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToGameMain()
    {
        SceneManager.LoadScene("mainMenuScene");
    }
    public void goToSilverLevel()
    {
        if(PlayerPrefs.GetInt("gameMode") == 1)
        {
     
            PlayerPrefs.SetInt("bronzeLevelRound", 2);
            PlayerPrefs.SetInt("winScore", PlayerPrefs.GetInt("winScore") + 1000);
            SceneManager.LoadScene("_Scene_0");
        }

       
    }
    public void goToGoldLevel()
    {
        if(PlayerPrefs.GetInt("gameMode") == 1)
        {
            PlayerPrefs.SetInt("bronzeLevelRound", 3);
            PlayerPrefs.SetInt("winScore", PlayerPrefs.GetInt("winScore") + 1000);
            SceneManager.LoadScene("_Scene_0");
        }
        if(PlayerPrefs.GetInt("gameMode") == 2)
        {
            PlayerPrefs.SetInt("silverLevelRound", 3);
            PlayerPrefs.SetInt("winScore", PlayerPrefs.GetInt("winScore") + 1000);
            SceneManager.LoadScene("_Scene_0");
        }

    }
}

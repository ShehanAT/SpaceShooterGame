using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemiesScript : MonoBehaviour
{

    public static string gameLevel;//bronze, silver, or gold
    public GameObject winScoreText;
    public GameObject InvalidText;
    public GameObject gameLevelText;
    public GameObject enemy0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    // Start is called before the first frame update
    void Start()
    {
        InvalidText.SetActive(false);
        //switch (PlayerPrefs.GetInt("gameMode"))
        //{
        //    case 1:
        //        gameLevelText.GetComponent<Text>().text = "Bronze Game Mode(Score to Win Game \n" +
        //            "Must be Equal to or Higher Than 2000)";
        //        break;
        //    case 2:
        //        gameLevelText.GetComponent<Text>().text = "Silver Game Mode(Socre to Win Game \n" +
        //            "Must be Equal to or Higher Than 3000)";
        //        break;
        //    case 3:
        //        gameLevelText.GetComponent<Text>().text = "Gold Game Mode(Score to Win Game \n" +
        //            "Must be Equal to or Higher Than 4000)";
        //        break;
        //    default:
        //        Application.Quit();
        //        break;

        //}
        //PlayerPrefs.SetInt("enemy0show", 1);
        //PlayerPrefs.SetInt("enemy1show", 1);
        //PlayerPrefs.SetInt("enemy2show", 1);
        //PlayerPrefs.SetInt("enemy3show", 1);
        //PlayerPrefs.SetInt("enemy4show", 1);
    

    }
    public void goToEnemiesScene()
    {

        if (winScoreText.GetComponent<InputField>().text == "")
        {
            InvalidText.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("EnemiesScene");
            //if (PlayerPrefs.GetInt("ValidWinScore") == 1)
            //{
            //    SceneManager.LoadScene("EnemiesScene");
            //}
        }


    }
    public void goToAudioScene()
    {
        SceneManager.LoadScene("AudioScene");
    }
    public void goToGameLevelScene()
    {
        SceneManager.LoadScene("gameLevelsScene");
    }
    public void goToBackGroundScene()
    {
        SceneManager.LoadScene("BackgroundScene");
    }
    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("gameLevelsScene");
    }
    // Update is called once per frame

    //public void goToGameScene2(int code)
    //{

    //    if (code == 1)
    //    {
    //        gameLevel = "Bronze";
    //        PlayerPrefs.SetInt("gameMode", 1);
    //        SceneManager.LoadScene("gameLevelScene2");
    //    }
    //    else if (code == 2)
    //    {
    //        gameLevel = "Silver";
    //        PlayerPrefs.SetInt("gameMode", 2);
    //        SceneManager.LoadScene("gameLevelScene2");
    //    }
    //    else if (code == 3)
    //    {
    //        gameLevel = "Gold";
    //        PlayerPrefs.SetInt("gameMode", 3);
    //        SceneManager.LoadScene("gameLevelScene2");
    //    }

    //}
    public void Update()
    {

    }
    public void goToScene0()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void quitGame()
    {
        SceneManager.LoadScene("navMenuScene");
    }
    public void goToStartScreen()
    {
        SceneManager.LoadScene("mainMenuScene");
    }

    public void disableEnemy0()
    {

        if (!enemy0.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy0show", 0);

        }
        if (enemy0.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy0show", 1);
        }

    }
    public void disableEnemy1()
    {
        if (!enemy1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy1show", 0);
        }
        if (enemy1.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy1show", 1);
        }
    }
    public void disableEnemy2()
    {
        if (!enemy2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy2show", 0);
        }
        if (enemy2.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy2show", 1);
        }
    }
    public void disableEnemy3()
    {
        if (!enemy3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy3show", 0);
        }
        if (enemy3.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy3show", 1);
        }
    }
    public void disableEnemy4()
    {
        if (!enemy4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy4show", 0);
        }
        if (enemy4.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("enemy4show", 1);
        }
    }
    public void goToSettings()
    {
        SceneManager.LoadScene("ConfigScene");
    }

}

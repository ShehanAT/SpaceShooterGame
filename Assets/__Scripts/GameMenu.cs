using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playButton;
    public GameObject exitMenu;
    public GameObject configButton;
    public GameObject gameLevel;
    public GameObject historyButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void goToConfigScene()
    {
        SceneManager.LoadScene("ConfigScene");
    }
    void goToHistoryScene()
    {
        SceneManager.LoadScene("HistoryScene");
    }
    void goToMainMenu()
    {
        SceneManager.LoadScene("ExitMenu");
    }
    void goToGameLevel()
    {
        SceneManager.LoadScene("GameLevelsScene");
    }
    void goToStartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
}

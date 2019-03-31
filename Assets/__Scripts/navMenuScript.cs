using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class navMenuScript : MonoBehaviour
{
    public GameObject createUserButton;
    public GameObject deleteUserButton;
    public GameObject changePasswordButton;
    public GameObject releaseBlocksButton;
    public GameObject notificationText;

    // Start is called before the first frame update
    void Start()
    {
      
        if(PlayerPrefs.GetInt("newUserAdded") == 1)
        {
            notificationText.GetComponent<Text>().text = "new user " + PlayerPrefs.GetString("newUser") + " added";
            PlayerPrefs.SetInt("newUserAdded", 0);
        }
        
        if (String.Compare(PlayerPrefs.GetString("currentUser"), "admin") == 0)
        {
            createUserButton.SetActive(true);
            deleteUserButton.SetActive(true);
            releaseBlocksButton.SetActive(true);
        }
        else
        {

            Destroy(createUserButton);
            Destroy(deleteUserButton);
            Destroy(releaseBlocksButton);

        }
        changePasswordButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void goToApplePickerGame()
    {
        SceneManager.LoadScene("_Scene_0ApplePicker");
        //PlayerPrefs.SetInt(PlayerPrefs.GetString("currentUser") + "score", 0);
    }

    public void goToLoginScene()
    {
        SceneManager.LoadScene("LoginScene");
    }
    public void goToHistoryScene()
    {
        SceneManager.LoadScene("HistoryScene");
    }
    public void goToShooterGame()
    {
        PlayerPrefs.SetInt(PlayerPrefs.GetString("currentUser") + "score", 0);
        SceneManager.LoadScene("mainMenuScene");
    }
    public void goToDeleteScene()
    {
        SceneManager.LoadScene("DeleteUserScene");
    }
    public void goToCreateUserScene()
    {
        SceneManager.LoadScene("CreateNewUser");
    }
}

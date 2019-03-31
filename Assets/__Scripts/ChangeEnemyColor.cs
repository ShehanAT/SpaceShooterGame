using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeEnemyColor : MonoBehaviour
{
    public Camera cam;
    public Dropdown dropDown0;
    public Dropdown dropDown1;
    public Dropdown dropDown2;
    public Dropdown dropDown3;
    public Dropdown dropDown4;
    public InputField inputField0;
    public InputField inputField1;
    public InputField inputField2;
    public InputField inputField3;
    public InputField inputField4;
    public GameObject main;
    string enemy0color;
    string enemy1color;
    string enemy2color;
    string enemy3color;
    string enemy4color;
    public GameObject proofColor;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("enemy0show") == 0)
        {
            Debug.Log("passing");
            Destroy(GameObject.Find("Enemy0ValueInput"));
            Destroy(GameObject.Find("DropdownEnemy0"));
            Destroy(GameObject.Find("Enemy0Pic"));
        }
        if(PlayerPrefs.GetInt("enemy1show") == 0)
        {
            Destroy(GameObject.Find("Enemy1ValueInput"));
            Destroy(GameObject.Find("DropdownEnemy1"));
            Destroy(GameObject.Find("Enemy1Pic"));
        }
        if (PlayerPrefs.GetInt("enemy2show") == 0)
        {
            Destroy(GameObject.Find("Enemy2ValueInput"));
            Destroy(GameObject.Find("DropdownEnemy2"));
            Destroy(GameObject.Find("Enemy2Pic"));
        }
        if (PlayerPrefs.GetInt("enemy3show") == 0)
        {
            Destroy(GameObject.Find("Enemy3ValueInput"));
            Destroy(GameObject.Find("DropdownEnemy3"));
            Destroy(GameObject.Find("Enemy3Pic"));
        }
        if (PlayerPrefs.GetInt("enemy4show") == 0)
        {
            Destroy(GameObject.Find("Enemy4ValueInput"));
            Destroy(GameObject.Find("DropdownEnemy4"));
            Destroy(GameObject.Find("Enemy4Pic"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        //for enemy 0
     

    }
    public void Dropdown_IndexChanged0(int index)
    {
   
        switch (dropDown0.value)
        {
            case 0:
                PlayerPrefs.SetString("enemy0color", "enemy0grey");
                break;
            case 1:
                PlayerPrefs.SetString("enemy0color", "enemy0red");
                break;
            case 2:
                PlayerPrefs.SetString("enemy0color", "enemy0blue");
                break;
        }
        Debug.Log("enemy0 color is: " + PlayerPrefs.GetString("enemy0color"));
        proofColor.GetComponent<Text>().text = PlayerPrefs.GetString("enemy0color");

    }
    public void Dropdown_IndexChanged1(int index)
    {
        switch (dropDown1.value)
        {
            case 0:
                PlayerPrefs.SetString("enemy1color", "enemy1grey");
                break;
            case 1:
                PlayerPrefs.SetString("enemy1color", "enemy1red");
                break;
            case 2:
                PlayerPrefs.SetString("enemy1color", "enemy1blue");
                break;
        }
        Debug.Log("enemy1 color is: " + PlayerPrefs.GetString("enemy1color"));
        proofColor.GetComponent<Text>().text = PlayerPrefs.GetString(enemy1color);

    }
    public void Dropdown_IndexChanged2(int index)
    {
        switch (dropDown2.value)
        {
            case 0:
                PlayerPrefs.SetString("enemy2color", "enemy2grey");
                break;
            case 1:
                PlayerPrefs.SetString("enemy2color", "enemy2red");
                break;
            case 2:
                PlayerPrefs.SetString("enemy2color", "enemy2blue");
                break;
        }
        Debug.Log("enemy2 color is: " + PlayerPrefs.GetString("enemy2color"));
        proofColor.GetComponent<Text>().text = PlayerPrefs.GetString(enemy2color);

    }
    public void Dropdown_IndexChanged3(int index)
    {
        switch (dropDown3.value)
        {
            case 0:
                PlayerPrefs.SetString("enemy3color", "enemy3grey");
                break;
            case 1:
                PlayerPrefs.SetString("enemy3color", "enemy3red");
                break;
            case 2:
                PlayerPrefs.SetString("enemy3color", "enemy3blue");
                break;
        }
        Debug.Log("enemy3 color is: "+ PlayerPrefs.GetString("enemy3color"));
        proofColor.GetComponent<Text>().text = PlayerPrefs.GetString(enemy3color);

    }
    public void Dropdown_IndexChanged4(int index)
    {
        switch (dropDown4.value)
        {
            case 0:
                PlayerPrefs.SetString("enemy4color", "enemy4grey");
                break;
            case 1:
                PlayerPrefs.SetString("enemy4color", "enemy4red");
                break;
            case 2:
                PlayerPrefs.SetString("enemy4color", "enemy4blue");
                break;
        }
        Debug.Log("enemy4 color is: " + PlayerPrefs.GetString("enemy4color"));
        proofColor.GetComponent<Text>().text = PlayerPrefs.GetString(enemy4color);

    }
    public void InputEndEdit0()
    {
        if (int.Parse(inputField0.text) > 0)
        {
            PlayerPrefs.SetInt("enemy0value", int.Parse(inputField0.text));
        }
      //  proofColor.GetComponent<Text>().text =  PlayerPrefs.GetInt("enemy0value").ToString();
    }
    public void InputEndEdit1()
    {
        if (int.Parse(inputField1.text) > 0)
        {
            PlayerPrefs.SetInt("enemy1value", int.Parse(inputField1.text));
        }
    }
    public void InputEndEdit2()
    {
        if (int.Parse(inputField2.text) > 0)
        {
            PlayerPrefs.SetInt("enemy2value", int.Parse(inputField2.text));
        }
    }
    public void InputEndEdit3()
    {
        if (int.Parse(inputField3.text) > 0)
        {
            PlayerPrefs.SetInt("enemy3value", int.Parse(inputField3.text));
        }
    }
    public void InputEndEdit4() {
        if (int.Parse(inputField4.text) > 0)
        {
            PlayerPrefs.SetInt("enemy4value", int.Parse(inputField4.text));
        }
    }
    public void increaseHighScore()
    {

    }
    public void exitToGameLevelScene2()
    {
        SceneManager.LoadScene("gameLevelScene2");
    }
}

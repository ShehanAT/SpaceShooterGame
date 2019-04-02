using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class createUserScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField userNameField;
    public InputField passwordField;
    public Text notificationText;
    loginScript login;
    navMenuScript navMenu;
    Dictionary<string, string> userList;
    Dictionary<string, string> data;

    int invalidNum;
    string newUser;

    void Start()
    {
 
        StreamReader inp_stm = new StreamReader("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject/Users.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            string[] inp_arr = inp_ln.Split(' ');
            userList.Add(inp_arr[0], inp_arr[1]);
        }
        inp_stm.Close();
        Debug.Log("Before Deleting");
        foreach (System.Collections.Generic.KeyValuePair<string, string> i in userList)
        {
            Debug.Log(i.Key + " " + i.Value);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveData()
    {
        if (File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.txt"))
        {
            StreamWriter file2 = File.CreateText("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.txt");
            foreach (System.Collections.Generic.KeyValuePair<string, string> i in userList)
            {
                file2.WriteLine(i.Key + " " + i.Value);
            }
            file2.Close();

        }
    }
    public Dictionary<string, string> loginDetails = new Dictionary<string, string>
    {
        {"admin", "admin"},
        {"Shehan", "Shehan"},
        {"Cezar", "Cezar"},
        {"Meer", "Meer"}
    };
    public void createUser() {
        userList = new Dictionary<string, string>();
        data = new Dictionary<string, string>();
            if(!int.TryParse(userNameField.text, out invalidNum) && !int.TryParse(passwordField.text, out invalidNum))
        {
            Debug.Log("userName is " + userNameField.text + " password is " + passwordField.text);
            PlayerPrefs.SetString("newPassword", passwordField.text);
            PlayerPrefs.SetString("newUserName", userNameField.text);
            PlayerPrefs.SetString("newPlayerStatus", userNameField.text);

            userList.Add(userNameField.text, passwordField.text);
            
           // data.Add(userNameField.text, passwordField.text);
            SaveData();
            foreach (System.Collections.Generic.KeyValuePair<string, string> i in userList)
            {
                Debug.Log(i.Value);

            }
            PlayerPrefs.SetInt("newUserAdded", 1);
            SceneManager.LoadScene("navMenuScene");
        }
        else
        {
            //user entered a number into one of the input field 
            notificationText.text = "Username and/or Password CANNOT be integers!!!";
            notificationText.color = Color.red;
        }


    }
}

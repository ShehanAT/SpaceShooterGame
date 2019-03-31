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
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData()
    {
        ////load login information if(File.Exists(Application.persistentDataPath + "/Login.gd")) {
        //if (File.Exists(Application.persistentDataPath + "/Login.gd"))
        //{
        //    BinaryFormatter bf1 = new BinaryFormatter();
        //    FileStream file1 = File.Open("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
        //                                  "/Login.gd", FileMode.Open);
        //        userList =
        //  (Dictionary<string, string>)bf1.Deserialize(file1);
          
        //    file1.Close();
       
        //    //loginDetails = new Dictionary<string, string>(userList);
        //}
        //load user information
        if (File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd"))
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            FileStream file2 = File.Open("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
                                 "/Users.gd", FileMode.Open);
            userList =
            (Dictionary<string, string>)bf2.Deserialize(file2);
         
            file2.Close();
            // userData = new Dictionary<string, string>(data);
        }
    }
    public void SaveData()
    {
        //BinaryFormatter bf1 = new BinaryFormatter();
        //FileStream file1 = File.Create("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
        //                                    "/Login.gd");
        //// Dictionary<string, string> userList = new Dictionary<string, string>(loginDetails);
      
        //bf1.Serialize(file1, userList);
        //file1.Close();
 
        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file2 = File.Create("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd");
        bf2.Serialize(file2, userList);
        file2.Close();

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

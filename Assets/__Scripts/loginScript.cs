using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class loginScript : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public Button loginButton;
    public GameObject InvalidText;
    public List<string> testList = new List<string>();
    createUserScript createUser;
    static int counter = 0;
    public Dictionary<string, string> login;
    public Dictionary<string, string> userData;
    // Start is called before the first frame update
    void Start()
    {
       
        LoadData();
        userData.Add("admin", "admin");
        userData.Add("Shehan", "Shehan");
        userData.Add("Cezar", "Cezar");
        userData.Add("Meer", "Meer");
        foreach (System.Collections.Generic.KeyValuePair<string, string> i in userData)
        {
            Debug.Log(i.Value);

        }
        //SaveData();

        PlayerPrefs.SetString("admin", "admin");
        InvalidText.SetActive(false);
        loginButton.onClick.AddListener(adminDetails);
    }
    public Dictionary<string, string> loginTime = new Dictionary<string, string>();
    public Dictionary<string, string> loginDetails = new Dictionary<string, string>
    {
        {"admin", "admin"},
        {"Shehan", "Shehan"},
        {"Cezar", "Cezar"},
        {"Meer", "Meer"}
    };
    public void LoadData()
    {
        //load login information if(File.Exists(Application.persistentDataPath + "/Login.gd")) {
        //if (File.Exists(Application.persistentDataPath + "/Login.gd"))
        //{
        //    BinaryFormatter bf1 = new BinaryFormatter();
        //    FileStream file1 = File.Open("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
        //                                  "/Login.gd", FileMode.Open);
        //    userData =
        // (Dictionary<string, string>)bf1.Deserialize(file1);
        //    file1.Close();
        //    // login = new Dictionary<string, string>(userList);
        //}
        //load user information
        if (File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd"))
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            FileStream file2 = File.Open("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
                                 "/Users.gd", FileMode.Open);
            userData =
            (Dictionary<string, string>)bf2.Deserialize(file2);
           
            foreach (System.Collections.Generic.KeyValuePair<string, string> i in userData)
            {
                Debug.Log(i.Value);

            }
            file2.Close();
            //userData = new Dictionary<string, string>(data); }
        }
    }
    public void SaveData()
    {
        //BinaryFormatter bf1 = new BinaryFormatter();
        //FileStream file1 = File.Create("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" +
        //                                    "/Login.gd");
        //Dictionary<string, string> userList = new Dictionary<string, string>(loginDetails);
        //bf1.Serialize(file1, loginDetails);
        //file1.Close();
        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file2 = File.Create("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd");
       // Dictionary<string, string> data = new Dictionary<string, string>(loginDetails);

        bf2.Serialize(file2, userData);
       // File.AppendAllText("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd", )
        file2.Close();
    }
  

    //public void adminDetails()
    //{
    //    string userName = userNameField.text;
    //    string password = passwordField.text;

    //    string foundPassword;
    //    if(loginDetails.TryGetValue(userName, out foundPassword) && (String.Compare(foundPassword,password) == 0))
    //    {
    //        if (String.Compare(userName, "admin") == 0)
    //        {
    //            PlayerPrefs.SetString("currentUser", "admin");
    //            Debug.Log("ADMIN HAS LOGGED IN");
    //            SceneManager.LoadScene("navMenuScene");
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetString("currentUser", userName);
    //            SceneManager.LoadScene("navMenuScene");
    //        }
           
    //    }
    //    else
    //    {
    //        Debug.Log("Invalid password");
    //        InvalidText.SetActive(true);
    //    }
    ////}
      public void adminDetails()
    {
        string userName = userNameField.text;
        string password = passwordField.text;

        string foundPassword;
        if(userData.TryGetValue(userName, out foundPassword) && (String.Compare(foundPassword, password) == 0)) 
        {
            if(String.Compare(userName, "admin") == 0)
            {
                PlayerPrefs.SetString("currentUser", "admin");
                loginTime.Add(PlayerPrefs.GetString("currentUser"), PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
                PlayerPrefs.SetString("currentUserLoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
            }
            else
            {
                PlayerPrefs.SetString("currentUser", userName);
                loginTime.Add(PlayerPrefs.GetString("currentUser"), PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

            }
            saveLoginTimes();
            SceneManager.LoadScene("navMenuScene");

        }
    }
    public void saveLoginTimes()
    {
        if (File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Login.txt"))
        {
            BinaryFormatter bf2 = new BinaryFormatter();
            StreamWriter file2 = File.AppendText("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Login.txt");
            foreach (System.Collections.Generic.KeyValuePair<string, string> i in loginTime)
            {
                file2.WriteLine(i.Value);

            }
            file2.Close();
         }
    }
    //public void adminDetails()
    //{
    //    string userName = userNameField.text;
    //    string password = passwordField.text;

    //    string foundPassword;
    //    if(loginDetails.TryGetValue(userName, out foundPassword) && (String.Compare(foundPassword, password) == 0))
    //    {
    //        counter++;
    //        if(String.Compare(userName, "admin") == 0)
    //        {
    //            PlayerPrefs.SetString("currentUser", "admin");
    //            if (counter == 1)
    //            {
    //                PlayerPrefs.SetString("currentUser1LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            else if (counter == 2)
    //            {
    //                PlayerPrefs.SetString("currentUser2LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            if (counter == 3)
    //            {
    //                PlayerPrefs.SetString("currentUser3LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                counter = 0;

    //            }
    //            SceneManager.LoadScene("navMenuScene");
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetString("currentUser", userName);
    //            if (counter == 1)
    //            {
    //                PlayerPrefs.SetString("currentUser1LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                PlayerPrefs.SetInt("currentUser1HighestScore", PlayerPrefs.GetInt(PlayerPrefs.GetString("currentUser") + "score" ));

    //            }
    //            if (counter == 2)
    //            {
    //                PlayerPrefs.SetString("currentUser2LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                PlayerPrefs.SetInt("currentUser2HighestScore", PlayerPrefs.GetInt(PlayerPrefs.GetString("currentUser") + "score"));
    //            }
    //            if (counter == 3)
    //            {
    //                PlayerPrefs.SetString("currentUser3LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                PlayerPrefs.SetInt("currentUser3HighestScore", PlayerPrefs.GetInt(PlayerPrefs.GetString("currentUser") + "score"));
    //                counter = 0;

    //            }
    //            SceneManager.LoadScene("navMenuScene");
    //        }



    //    }
    //    else if((String.Compare(PlayerPrefs.GetString("newPassword"), password) == 0) && (String.Compare(PlayerPrefs.GetString("newUserName"), userName) == 0))
    //    {
    //        counter++;
    //        if (String.Compare(userName, "admin") == 0)
    //        {
    //            PlayerPrefs.SetString("currentUser", "admin");
    //            if (counter == 1)
    //            {
    //                PlayerPrefs.SetString("currentUser1LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            if (counter == 2)
    //            {
    //                PlayerPrefs.SetString("currentUser2LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            if (counter == 3)
    //            {
    //                PlayerPrefs.SetString("currentUser3LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                counter = 0;

    //            }
    //            SceneManager.LoadScene("navMenuScene");
    //        }
    //        else
    //        {
    //            PlayerPrefs.SetString("currentUser", userName);
    //            if (counter == 1)
    //            {
    //                PlayerPrefs.SetString("currentUser1LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            if (counter == 2)
    //            {
    //                PlayerPrefs.SetString("currentUser2LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());

    //            }
    //            if (counter == 3)
    //            {
    //                PlayerPrefs.SetString("currentUser3LoginTime", PlayerPrefs.GetString("currentUser") + ", Logged in at: " + System.DateTime.Now.ToString());
    //                counter = 0;

    //            }
    //            SceneManager.LoadScene("navMenuScene");
    //        }
    //        PlayerPrefs.SetString("newUserName", "");
    //        PlayerPrefs.SetString("newPassword", "");


    //    }
    //    else
    //    {
    //        Debug.Log("Invalid password");
    //        InvalidText.SetActive(true);
    //    }

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

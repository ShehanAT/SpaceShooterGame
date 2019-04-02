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
    public Dictionary<string, string> userData = new Dictionary<string, string>();


    // Start is called before the first frame update
    void Start()
    {
       
        LoadData();
     //  userData.Add("admin", "admin");
      //  userData.Add("Shehan", "Shehan");
      //  userData.Add("Cezar", "Cezar");
      //  userData.Add("Meer", "Meer");
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
   
        if (File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.gd"))
        {
          //  string[] linesInFile = TextFile.text.Split('\n');
            StreamReader inp_stm = new StreamReader("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject/Users.txt");
            while (!inp_stm.EndOfStream)
            {
                string inp_ln = inp_stm.ReadLine();
                string[] inp_arr = inp_ln.Split(' ');
                userData.Add(inp_arr[0], inp_arr[1]);
            }
            inp_stm.Close();
         
            Debug.Log("Before Deleting");
            foreach (System.Collections.Generic.KeyValuePair<string, string> i in userData)
            {
                Debug.Log(i.Key + " " + i.Value);


            }

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
        else
        {
            InvalidText.SetActive(true);
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
    public void saveLoginUsers()
    {
        if(File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Login.txt"))
        {
           
        }
    
    }


    // Update is called once per frame
    public void exitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}

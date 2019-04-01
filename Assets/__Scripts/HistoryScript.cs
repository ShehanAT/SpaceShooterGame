using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class HistoryScript : MonoBehaviour
{

    public StreamReader reader = null;
    public string text = "";
    public GameObject displayLogins;
    public Dictionary<string, string> loginTimes;
    // Start is called before the first frame update
   //public List<string> userList = new List<string>();
    void Start()
    {
        loginTimes = new Dictionary<string, string>();
        getLoginTimes();
    }
    public void getLoginTimes()
    {
        if(File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Login.txt"))
        {
            FileInfo sourceFile = new FileInfo("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Login.txt");
            reader = sourceFile.OpenText();


        }
        text = reader.ReadLine();
        while (text != null)
        {
            loginTimes.Add(text, text);
            text = reader.ReadLine();

        }
        foreach (System.Collections.Generic.KeyValuePair<string, string> i in loginTimes)
        {
            displayLogins.GetComponent<Text>().text += i.Value + "\n";
        }
    }
    public void goToNavSceneMenu()
    {
        SceneManager.LoadScene("navMenuScene");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeleteScript : MonoBehaviour
{
    public TextAsset TextFile;
    public Dictionary<string, string> users = new Dictionary<string, string>();
    public GameObject text;
    public InputField userNameInputField;
    string userToBeDeleted;
    // Start is called before the first frame update
    void Start()
    {

        string[] linesInFile = TextFile.text.Split('\n');
        StreamReader inp_stm = new StreamReader("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject/Users.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            string[] inp_arr = inp_ln.Split(' ');
            users.Add(inp_arr[0], inp_arr[1]);
        }
        inp_stm.Close();
        text.GetComponent<Text>().text = "";
        Debug.Log("Before Deleting");
        foreach (System.Collections.Generic.KeyValuePair<string, string> i in users)
        {
            Debug.Log(i.Key + " " + i.Value);

            text.GetComponent<Text>().text += i.Value + "\n";

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void verifyUser()
    {
        Debug.Log(userNameInputField.text);
     
        if(users.ContainsKey(userNameInputField.text)){
            Debug.Log("passing2");
            deleteUser(); 
            
        }
    }
    public void deleteUser()
    {
        users.Remove(userNameInputField.text);
        saveData();
    }
    public void saveData()
    {
       
        if(File.Exists("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.txt")){
            StreamWriter file2 = File.CreateText("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject" + "/Users.txt");
            foreach(System.Collections.Generic.KeyValuePair<string, string> i in users)
            {
                file2.WriteLine(i.Key + " " + i.Value);
            }
            file2.Close();

        }
        users.Clear();
        string[] linesInFile = TextFile.text.Split('\n');
        StreamReader inp_stm = new StreamReader("/Users/shehanatukorala/Library/Application Support/DefaultCompany/atukoran_SpaceShootProject/Users.txt");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            string[] inp_arr = inp_ln.Split(' ');
            users.Add(inp_arr[0], inp_arr[1]);
        }
        Debug.Log("After Deleting");
        foreach(System.Collections.Generic.KeyValuePair<string, string> i in users)
        {
            Debug.Log(i.Key + " " + i.Value);
        }
        inp_stm.Close();
    }
}

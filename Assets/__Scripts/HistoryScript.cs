using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class HistoryScript : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    // Start is called before the first frame update
   //public List<string> userList = new List<string>();
    void Start()
    {
        player1.GetComponent<Text>().text = PlayerPrefs.GetString("currentUser1LoginTime")+ "\nHighest Score: " + PlayerPrefs.GetInt("currentUser1HighestScore").ToString();
        player2.GetComponent<Text>().text = PlayerPrefs.GetString("currentUser2LoginTime") + "\nHighest Score: " + PlayerPrefs.GetInt("currentUser2HighestScore").ToString();
        player3.GetComponent<Text>().text = PlayerPrefs.GetString("currentUser3LoginTime") + "\nHighest Score: " + PlayerPrefs.GetInt("currentUser3HighestScore").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

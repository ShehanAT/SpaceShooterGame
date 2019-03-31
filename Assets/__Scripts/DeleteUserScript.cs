using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteUserScript : MonoBehaviour
{
    loginScript theLoginScript;
    public GameObject userListText;

    // Start is called before the first frame update
    void Start()
    {
        foreach(string value in theLoginScript.testList)
        {
            Debug.Log(value);
        }
        //foreach (string value in theLoginScript.loginDetails.Values)
        //{
        //    userListText.GetComponent<Text>().text += value + "\n";
        //}


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public GameObject timeText;
    float timeTaken = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTaken += Time.deltaTime;
        timeText.GetComponent<Text>().text = "Timer: " + timeTaken.ToString();
    }
}

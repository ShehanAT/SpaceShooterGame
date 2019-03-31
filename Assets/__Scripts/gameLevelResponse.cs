using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameLevelResponse : MonoBehaviour
{
    public Text gameLevelText;
    // Start is called before the first frame update
    void Start()
    {
        gameLevelText = GetComponent<Text>();
        gameLevelText.text = "Sample";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

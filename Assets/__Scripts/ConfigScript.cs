using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goTogameLevelsScene()
    {
        SceneManager.LoadScene("gameLevelsScene");
    }
    public void goToEnemiesScene()
    {
        SceneManager.LoadScene("EnemiesScene");
    }
}

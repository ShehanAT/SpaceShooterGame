using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class validateGameScene : MonoBehaviour
{
    public GameObject gameLevelText;
    public InputField winScore;
    public Text winScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void validateWinScoreInput()
    {
        score = int.Parse(winScore.text);

        Debug.Log("The win score is: " + score);
        if (PlayerPrefs.GetInt("gameMode") == 1)
        {
            if (2000 <= score && 3000 > score)
            {
                PlayerPrefs.SetInt("winScore", score);
                PlayerPrefs.SetInt("ValidWinScore", 1);
                PlayerPrefs.SetInt("bronzeLevelRound", 1);
                gameLevelText.GetComponent<Text>().text = "Valid score to win level!";
            }
            else
            {
                gameLevelText.GetComponent<Text>().text = "Bronze Score MUST BE BETWEEN 2000 AND 3000!";
                PlayerPrefs.SetInt("ValidWinScore", 0);
            }

        }
        if(PlayerPrefs.GetInt("gameMode") == 2)
        {
            if(3000 <= score && 4000 > score)
            {
                PlayerPrefs.SetInt("winScore", score);
                PlayerPrefs.SetInt("ValidWinScore", 1);
                PlayerPrefs.SetInt("silverLevelRound", 2);
                gameLevelText.GetComponent<Text>().text = "Valid score to win level!";
            }
            else
            {
                gameLevelText.GetComponent<Text>().text = "Silver Score MUST BE BETWEEN 3000 AND 4000!";
                PlayerPrefs.SetInt("ValidWinScore", 0);
            }

        }
        if(PlayerPrefs.GetInt("gameMode") == 3)
        {
            if(4000 <= score)
            {
                PlayerPrefs.SetInt("winScore", score);
                PlayerPrefs.SetInt("ValidWinScore", 1);
                PlayerPrefs.SetInt("silverLevelRound", 2);
                gameLevelText.GetComponent<Text>().text = "Valid score to win level!";
            }
            else
            {
                gameLevelText.GetComponent<Text>().text = "Gold Score MUST BE OVER 4000!";
                PlayerPrefs.SetInt("ValidWinScore", 0);
            }
        }

    }
}

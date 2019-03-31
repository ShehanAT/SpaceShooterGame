using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {
	static public int    score = 1000;
	Text gt;

	void Start () {
	
	}
	void Awake() {                                                      

		if (PlayerPrefs.HasKey("ApplePickerHighScore")) {                 
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}

		PlayerPrefs.SetInt("ApplePickerHighScore", score);                
	}


	void Update () {
		gt = GetComponent<Text>();
		gt.text = "High Score: "+score;

		if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) {          
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
		}
	}
}

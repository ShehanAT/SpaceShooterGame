using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class changeBackGroundScript : MonoBehaviour
{
  
    public Image image;
    public Dropdown dropDown;
    int backgroundValue;
    // Start is called before the first frame update
    void Start()
    {
        Sprite space1 = Resources.Load<Sprite>("space1");
        Sprite space2 = Resources.Load<Sprite>("space2");
        Sprite space3 = Resources.Load<Sprite>("space3");
        image.sprite = space1;
    }
    public void goToMainMenu()
    {
        PlayerPrefs.SetInt("backgroundSelection", dropDown.value);
        SceneManager.LoadScene("ConfigScene");
    }
    public void onBackgroundChanged(int code)
    {
        Sprite space1 = Resources.Load<Sprite>("space1");
        Sprite space2 = Resources.Load<Sprite>("space2");
        Sprite space3 = Resources.Load<Sprite>("space3");
        switch (dropDown.value)
        {
            case 0:
                image.sprite = space1;
                break;
            case 1:
                image.sprite = space2;
                break;
            case 2:
                image.sprite = space3;
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

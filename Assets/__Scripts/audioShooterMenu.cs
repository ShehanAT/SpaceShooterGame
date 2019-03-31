using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioShooterMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource buttonClick;
    private Rect audiorect;
    void Start()
    {
        audiorect = new Rect(20, 20, 100, 20);
        
    }

    // Update is called once per frame
    void Update()
    {
        GUI.Label(audiorect, "Play Audio");
        if (audiorect.Contains(Event.current.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                buttonClick.Play();
            }
        }
    }
    public void playButtonClickSound()
    {
        buttonClick.Play();
        DontDestroyOnLoad(buttonClick);
    }
}

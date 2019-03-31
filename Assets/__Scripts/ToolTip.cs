using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToolTip : MonoBehaviour
{
    [System.Serializable]
    public class AnimationSettings
    {
        public enum OpenStyle { WidthToHeight, HeightToWidth, HeightAndWidth};
        public OpenStyle openStyle;
        public float widthSmooth = 4.6f, heightSmooth = 4.6f;
        public float textSmooth = 0.1f;

        [HideInInspector]
        public bool widthOpen = false, heightOpen = false;

        public void Initialize()
        {
            widthOpen = false;
            heightOpen = false;
        }
    }
    [System.Serializable]
    public class UISettings
    {
        public Image textBox;
        public Text text;
        public Vector2 initialBoxSize = new Vector2(0.25f, 0.25f);
        public Vector2 openedBoxSize = new Vector2(400, 200);
        public float snapToSizeDistance = 0.25f;
        public float lifeSpan = 5;
        public float lifeSpan2 = 5;
        [HideInInspector]
        public bool opening = false;
        [HideInInspector]
        public Color textColor;
        [HideInInspector]
        public Color textBoxColor;
        [HideInInspector]
        public RectTransform textBoxRect;
        [HideInInspector]
        public Vector2 currentSize;

        public void Initialize() {

      
            textBoxRect = textBox.GetComponent<RectTransform>();

            textBoxRect.sizeDelta = initialBoxSize;
            currentSize = textBoxRect.sizeDelta;
            opening = false;
           
            textColor = text.color;
            textColor.a = 0;
            text.color = textColor;
            textBoxColor = textBox.color;
            textBoxColor.a = 1;
            textBox.color = textBoxColor;
            text.color = new Vector4(0, 1, 0, 1);
           
            textBox.gameObject.SetActive(false);
            text.gameObject.SetActive(false);
         
           }

    }
    public AnimationSettings animSettings = new AnimationSettings();
    public UISettings uiSettings = new UISettings();

    public AnimationSettings animSettings2 = new AnimationSettings();
    public UISettings uiSettings2 = new UISettings();

    public AnimationSettings animSettings3 = new AnimationSettings();
    public UISettings uiSettings3 = new UISettings();

    public AnimationSettings animSettings4 = new AnimationSettings();
    public UISettings uiSettings4 = new UISettings();

    public AnimationSettings animSettings5 = new AnimationSettings();
    public UISettings uiSettings5 = new UISettings();

    public GameObject AdminLoginText;


    float lifeTimer = 0;
    float lifeTimer2 = 0;

    // Start is called before the first frame update
    void Start()
    {
     
        if(String.Compare(PlayerPrefs.GetString("currentUser"), "admin") == 0)
        {
            AdminLoginText.SetActive(true);
                animSettings.Initialize();
                uiSettings.Initialize();

                animSettings2.Initialize();
                uiSettings2.Initialize();

                animSettings3.Initialize();
                uiSettings3.Initialize();

                animSettings4.Initialize();
                uiSettings4.Initialize();

                animSettings5.Initialize();
                uiSettings5.Initialize();
            }
        else
        {
            AdminLoginText.SetActive(false);
            animSettings3.Initialize(); 
            uiSettings3.Initialize();
            
            animSettings5.Initialize();
            uiSettings5.Initialize();
            }
       
      

    }
 
    public void StartOpen()
    {
        if(String.Compare(PlayerPrefs.GetString("currentUser"), "admin") == 0)
        {
            uiSettings.opening = true;
            uiSettings.textBox.gameObject.SetActive(true);
            uiSettings.text.gameObject.SetActive(true);

            uiSettings2.opening = true;
            uiSettings2.textBox.gameObject.SetActive(true);
            uiSettings2.text.gameObject.SetActive(true);

            uiSettings3.opening = true;
            uiSettings3.textBox.gameObject.SetActive(true);
            uiSettings3.text.gameObject.SetActive(true);

            uiSettings4.opening = true;
            uiSettings4.textBox.gameObject.SetActive(true);
            uiSettings4.text.gameObject.SetActive(true);

            uiSettings5.opening = true;
            uiSettings5.textBox.gameObject.SetActive(true);
            uiSettings5.text.gameObject.SetActive(true);
        }
        else
        {

            uiSettings3.opening = true;
            uiSettings3.textBox.gameObject.SetActive(true);
            uiSettings3.text.gameObject.SetActive(true);

            uiSettings5.opening = true;
            uiSettings5.textBox.gameObject.SetActive(true);
            uiSettings5.text.gameObject.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {

        if(String.Compare(PlayerPrefs.GetString("currentUser"), "admin") == 0)
        {
            if (uiSettings.opening)
            {
                OpenToolTip();
                if (animSettings.widthOpen && animSettings.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings, animSettings);
                    }
                    else
                    {
                        FadeTextIn(uiSettings, animSettings);
                    }
                }
            }
            if (uiSettings2.opening)
            {
                OpenToolTip();
                if (animSettings2.widthOpen && animSettings2.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings2.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings2, animSettings2);
                    }
                    else
                    {
                        FadeTextIn(uiSettings2, animSettings2);
                    }
                }
            }
            if (uiSettings3.opening)
            {
                OpenToolTip();
                if (animSettings3.widthOpen && animSettings3.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings3.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings3, animSettings3);
                    }
                    else
                    {
                        FadeTextIn(uiSettings3, animSettings3);
                    }
                }
            }
            if (uiSettings4.opening)
            {
                OpenToolTip();
                if (animSettings4.widthOpen && animSettings4.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings4.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings4, animSettings4);
                    }
                    else
                    {
                        FadeTextIn(uiSettings4, animSettings4);
                    }
                }
            }
            if (uiSettings5.opening)
            {
                OpenToolTip();
                if (animSettings5.widthOpen && animSettings5.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings5.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings5, animSettings5);
                    }
                    else
                    {
                        FadeTextIn(uiSettings5, animSettings5);
                    }
                }
            }
        }
        else
        {
            if (uiSettings3.opening)
            {
                OpenToolTip();
                if (animSettings3.widthOpen && animSettings3.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings3.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings3, animSettings3);
                    }
                    else
                    {
                        FadeTextIn(uiSettings3, animSettings3);
                    }
                }
            }
            if (uiSettings5.opening)
            {
                OpenToolTip();
                if (animSettings5.widthOpen && animSettings5.heightOpen)
                {
                    lifeTimer += Time.deltaTime;
                    if (lifeTimer > uiSettings5.lifeSpan)
                    {
                        FadeToolTipOut(uiSettings5, animSettings5);
                    }
                    else
                    {
                        FadeTextIn(uiSettings5, animSettings5);
                    }
                }
            }
        }


    }
    void OpenToolTip()
    {
        switch (animSettings.openStyle)
        {
            case AnimationSettings.OpenStyle.HeightToWidth:
                OpenHeightToWidth( uiSettings,  animSettings);
                break;

            case AnimationSettings.OpenStyle.WidthToHeight:
                OpenWidthToHeight( uiSettings,  animSettings);
                break;
            case AnimationSettings.OpenStyle.HeightAndWidth:
                OpenHeightAndWidth( uiSettings,  animSettings);
                break;
            default:
                Debug.LogError("No animation is set for the selected open style!");
                break;

        }
        uiSettings.textBoxRect.sizeDelta = uiSettings.currentSize;

        switch (animSettings2.openStyle)
        {
            case AnimationSettings.OpenStyle.HeightToWidth:
                OpenHeightToWidth( uiSettings,  animSettings);
                break;

            case AnimationSettings.OpenStyle.WidthToHeight:
                OpenWidthToHeight( uiSettings,  animSettings);
                break;
            case AnimationSettings.OpenStyle.HeightAndWidth:
                OpenHeightAndWidth( uiSettings,  animSettings);
                break;
            default:
                Debug.LogError("No animation is set for the selected open style!");
                break;

        }
        uiSettings2.textBoxRect.sizeDelta = uiSettings2.currentSize;
    }

    void OpenWidthToHeight(UISettings uiSettings, AnimationSettings animSettings)
    {
        if (!animSettings.widthOpen)
        {
            OpenWidth( uiSettings,  animSettings);
        }
        else
        {
            OpenHeight( uiSettings,  animSettings);
        }
        if (!animSettings2.widthOpen)
        {
            OpenWidth( uiSettings,  animSettings);
        }
        else
        {
            OpenHeight( uiSettings,  animSettings);
        }
    }
    void OpenHeightAndWidth(UISettings uiSettings, AnimationSettings animSettings)
    {
        if (!animSettings.widthOpen)
        {
            OpenWidth( uiSettings,  animSettings);
        }
        if (!animSettings.heightOpen)
        {
            OpenHeight( uiSettings,  animSettings);
        }
        if (!animSettings2.widthOpen)
        {
            OpenWidth( uiSettings,  animSettings);
        }
        if (!animSettings2.heightOpen)
        {
            OpenHeight( uiSettings,  animSettings);
        }
    }
    void OpenHeightToWidth(UISettings uiSettings, AnimationSettings animSettings)
    {
        if (!animSettings.heightOpen)
        {
            OpenHeight( uiSettings,  animSettings);
        }
        else
        {
            OpenWidth( uiSettings,  animSettings);
        }
        if (!animSettings2.heightOpen)
        {
            OpenHeight( uiSettings,  animSettings);
        }
        else
        {
            OpenWidth( uiSettings,  animSettings);
        }
    }

    void OpenWidth(UISettings uiSettings, AnimationSettings animSettings)
    {
        uiSettings.currentSize.x = Mathf.Lerp(uiSettings.currentSize.x, uiSettings.openedBoxSize.x, animSettings.widthSmooth*Time.deltaTime);
        if(Mathf.Abs(uiSettings.currentSize.x - uiSettings.openedBoxSize.x) < uiSettings.snapToSizeDistance)
        {
            uiSettings.currentSize.x = uiSettings.openedBoxSize.x;
            animSettings.widthOpen = true;
        }
    }


    void OpenHeight(UISettings uiSettings, AnimationSettings animSettings)
    {
        uiSettings.currentSize.y = Mathf.Lerp(uiSettings.currentSize.y, uiSettings.openedBoxSize.y, animSettings.heightSmooth*Time.deltaTime);
        if(Mathf.Abs(uiSettings.currentSize.y - uiSettings.openedBoxSize.y) < uiSettings.snapToSizeDistance)
        {
            uiSettings.currentSize.y = uiSettings.openedBoxSize.y;
        }
    }
    void FadeTextIn(UISettings uiSettings, AnimationSettings animSettings)
    {
        uiSettings.textColor.a = Mathf.Lerp(uiSettings.textColor.a, 1, animSettings.textSmooth * Time.deltaTime);
        uiSettings.text.color = uiSettings.textColor;
    }
    void FadeToolTipOut(UISettings uiSettings, AnimationSettings animSettings)
    {
        uiSettings.textColor.a = Mathf.Lerp(uiSettings.textColor.a, 0, animSettings.textSmooth * Time.deltaTime);
        uiSettings.text.color = uiSettings.textColor;
        uiSettings.textBoxColor.a = Mathf.Lerp(uiSettings.textBoxColor.a, 0, animSettings.textSmooth * Time.deltaTime);
        uiSettings.textBox.color = uiSettings.textBoxColor;
        if(uiSettings.textBoxColor.a < 0.01f)
        {
            uiSettings.opening = false;
            animSettings.Initialize();
            uiSettings.Initialize();
            lifeTimer = 0;

        }
    }








}

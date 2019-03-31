using System.Collections; // Required for Arrays & other Collections
using System.Collections.Generic; // Required for Lists and Dictionaries
using UnityEngine; // Required for Unity
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")] public float speed = 10f; // The speed in m/s
    public float fireRate = 0.3f; // Seconds/shot (Unused)
    public float health = 10;

    static int score = 0; // Points earned for destroying this
    static int assignedScore = 0;
    public float showDamageDuration = 0.1f; // # seconds to show damage
    public float powerUpDropChance = 1f; // Chance to drop a power-up
    public Main main;
    [Header("Set Dynamically: Enemy")] public Color[] originalColors;
    public Material[] materials; // All the Materials of this & its children
    public bool showingDamage = false;
    public float damageDoneTime; // Time to stop showing damage
    public bool notifiedOfDestruction = false; // Will be used later
    public GameObject displayHighScore;
    protected BoundsCheck BndCheck;
    private bool _isBndCheckNotNull;
    private int currentScore;
    public GameObject e0KillCountText;
    public GameObject e1KillCountText;
    public GameObject e2KillCountText;
    public GameObject e3KillCountText;
    public GameObject e4KillCountText;
    static int e0killcountint;
    static int e1killcountint;
    static int e2killcountint;
    static int e3killcountint;
    static int e4killcountint;


    private void Awake()
    {
   
        assignedScore = PlayerPrefs.GetInt("enemy0value");
        BndCheck = GetComponent<BoundsCheck>();
//        displayHighScore.GetComponent<Text>().text = (0).ToString();
        _isBndCheckNotNull = BndCheck != null;

        // Get materials and colors for this GameObject and its children
        materials = Utils.GetAllMaterials(gameObject); // b
        originalColors = new Color[materials.Length];
        for (var i = 0; i < materials.Length; i++)
        {
            originalColors[i] = materials[i].color;
        }
    }
    void Start()
    {
        // PlayerPrefs.SetInt("currentScore", 187);you
       // PlayerPrefs.SetInt("currentScore", 299);
       //displayHighScore.GetComponent<Text>().text = "current Score:" + PlayerPrefs.GetInt("currentScore").ToString();


    }



    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }

    void Update()
    {
        Move();

        if (showingDamage && Time.time > damageDoneTime)
        {
            UnShowDamage();
        }

        if (_isBndCheckNotNull && BndCheck.offDown)
        {
            //   Debug.Log("PASSING FIRST TEST!!!" + "gameObject Name: " + gameObject.name + "" + PlayerPrefs.GetString("enemy0color");
            // We're off the bottom, so destroy this GameObject
            //  if (gameObject.name == PlayerPrefs.GetString("enemy0color"))
            // {

   

          //  }
            Destroy(gameObject);
        }
        // displayHighScore.transform.Find("Text").GetComponent<Text>().text = (PlayerPrefs.GetInt("currentScore")).ToString();
        //TempFire();
    }

    public virtual void Move()
    {
        var tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

//    private void OnCollisionEnter(Collision coll)
//    {
//        var otherGO = coll.gameObject;
//        if (otherGO.CompareTag("ProjectileHero"))
//        {
//            Destroy(otherGO); // Destroy the Projectile
//            Destroy(gameObject); // Destroy this Enemy GameObject
//        }
//        else
//        {
//            print("Enemy hit by non-ProjectileHero: " + otherGO.name);
//        }
//    }

    private void OnCollisionEnter(Collision coll)
    {
        ShowDamage();
        var otherGO = coll.gameObject;
        switch (otherGO.tag)
        {
            case "ProjectilePlayer":
                var p = otherGO.GetComponent<Projectile>();
                // If this Enemy is off screen, don't damage it.
                if (!BndCheck.isOnScreen)
                {
                    Destroy(otherGO);
                    break;
                }

                // Hurt this Enemy
                // Get the damage amount from the Main WEAP_DICT.
                health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                if (health <= 0)
                {
                    // Destroy this Enemy
                    if (!notifiedOfDestruction)
                    {
                        if(gameObject.tag == "enemy0")
                        {
                            Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
                            currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy0value");
                            PlayerPrefs.SetInt("enemy0killcount", PlayerPrefs.GetInt("enemy0killcount") + 1);
                            PlayerPrefs.SetInt("currentScore", currentScore);
                        }
                        if(gameObject.tag == "enemy1")
                        {
                            Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
                            currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy1value");
                            PlayerPrefs.SetInt("enemy1killcount", PlayerPrefs.GetInt("enemy1killcount") + 1);
                            PlayerPrefs.SetInt("currentScore", currentScore);
                        }
                        if(gameObject.tag == "enemy2")
                        {
                            Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
                            currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy2value");
                            PlayerPrefs.SetInt("enemy2killcount", PlayerPrefs.GetInt("enemy2killcount") + 1);
                            PlayerPrefs.SetInt("currentScore", currentScore);
                        }
                        if(gameObject.tag == "enemy3")
                        {
                            Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
                            currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy3value");
                            PlayerPrefs.SetInt("enemy3killcount", PlayerPrefs.GetInt("enemy3killcount") + 1);
                            PlayerPrefs.SetInt("currentScore", currentScore);
                        }
                        if(gameObject.tag == "enemy4")
                        {
                            Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
                            currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy4value");
                            PlayerPrefs.SetInt("enemy4killcount", PlayerPrefs.GetInt("enemy4killcount") + 1);
                            PlayerPrefs.SetInt("currentScore", currentScore);
                        }
                        Debug.Log(PlayerPrefs.GetInt("currentScore"));
                      //  displayHighScore.GetComponent<Text>().text = "current Score: Shehan"; //+(PlayerPrefs.GetInt("currentScore")).ToString();
                        //  currentScore.text = (PlayerPrefs.GetInt("currentScore")).ToString();
                        //main.updateCurrentScore();
                        Main.S.ShipDestroyed(this);
                    }


                    notifiedOfDestruction = true;
                
                 
                    // Destroy this Enemy
                    Destroy(gameObject);
                }

                Destroy(otherGO);
                break;
            default:
         
                break;
        }
    }

    private void ShowDamage()
    {
        foreach (Material m in materials)
        {
            m.color = Color.red;
        }

        showingDamage = true;
        damageDoneTime = Time.time + showDamageDuration;
    }

    private void UnShowDamage()
    {
        for (var i = 0; i < materials.Length; i++)
        {
            materials[i].color = originalColors[i];
        }

        showingDamage = false;
    }
  
}
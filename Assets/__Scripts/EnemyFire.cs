using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public float fireRate = 0.3f; // Seconds/shot (Unused)
    public float health = 10;
    public GameObject projectilePrefab;
    public float speed = 10f;
    protected BoundsCheck BndCheck;
    private bool _isBndCheckNotNull;
    public float powerUpDropChance = 1f;
    private Vector3 _p0, _p1; // The two points to interpolate
    private float _timeStart; // Birth time for this Enemy_4
    private float _duration = 4; // Duration of movement
    public Part[] parts;
    public Material[] materials;
    public Color[] originalColors;
    public bool notifiedOfDestruction = false;
    private int currentScore;
    public bool showingDamage = false;
    public float damageDoneTime;
    public float showDamageDuration = 0.1f;
    private void Awake()
    {
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
    }                           // Start is called before the first frame update
    private void Start()
    {
        // There is already an initial position chosen by Main.SpawnEnemy()
        // so add it to points as the initial p0 & p1
        _p0 = _p1 = pos;
        InitMovement();

        // Cache GameObject & Material of each Part in parts
        foreach (var prt in parts)
        {
            var t = transform.Find(prt.name);
            if (t == null) continue;
            prt.go = t.gameObject;
            prt.mat = prt.go.GetComponent<Renderer>().material;
        }
    }

    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if (_isBndCheckNotNull && BndCheck.offDown)
        {
            //   Debug.Log("PASSING FIRST TEST!!!" + "gameObject Name: " + gameObject.name + "" + PlayerPrefs.GetString("enemy0color");
            // We're off the bottom, so destroy this GameObject
            //  if (gameObject.name == PlayerPrefs.GetString("enemy0color"))
            // {



            //  }
            Destroy(gameObject);
        }
        TempFire();
    }
    void TempFire()
    {
        var projGO = Instantiate(projectilePrefab);
        projGO.transform.position = transform.position;
        var rigidB = projGO.GetComponent<Rigidbody>();
        //        rigidB.velocity = Vector3.up * projectileSpeed;

        var proj = projGO.GetComponent<Projectile>();
        proj.type = WeaponType.blaster;
        var tSpeed = Main.GetWeaponDefinition(proj.type).velocity;
        rigidB.velocity = Vector3.up * tSpeed;
    }

    public virtual void Move()
    {
        // This completely overrides Enemy.Move() with a linear interpolation
        var u = (Time.time - _timeStart) / _duration;
        if (u >= 1)
        {
            InitMovement();
            u = 0;
        }

        u = 1 - Mathf.Pow(1 - u, 2); // Apply Ease Out easing to u
        pos = (1 - u) * _p0 + u * _p1; // Simple linear interpolation
    }
    private void InitMovement()
    {
        _p0 = _p1; // Set p0 to the old p1
        // Assign a new on-screen location to p1
        var widMinRad = BndCheck.camWidth - BndCheck.radius;
        var hgtMinRad = BndCheck.camHeight - BndCheck.radius;
        _p1.x = Random.Range(-widMinRad, widMinRad);
        _p1.y = Random.Range(-hgtMinRad, hgtMinRad);
        // Reset the time
        _timeStart = Time.time;
    }
    private void OnCollisionEnter(Collision coll)
    {
        ShowDamage();
        var otherGO = coll.gameObject;
        //switch (otherGO.tag)
        //{
        //    case "ProjectilePlayer":
        //        var p = otherGO.GetComponent<Projectile>();
        //        // If this Enemy is off screen, don't damage it.
        //        if (!BndCheck.isOnScreen)
        //        {
        //            Destroy(otherGO);
        //            break;
        //        }

        //        // Hurt this Enemy
        //        // Get the damage amount from the Main WEAP_DICT.
        //        health -= Main.GetWeaponDefinition(p.type).damageOnHit;
        //        if (health <= 0)
        //        {
        //            // Destroy this Enemy
        //            if (!notifiedOfDestruction)
        //            {
                       
        //                    Debug.Log("GAMEOBJECT NAME: " + gameObject.name);
        //                    currentScore = PlayerPrefs.GetInt("currentScore") + PlayerPrefs.GetInt("enemy4value");
        //                    PlayerPrefs.SetInt("currentScore", currentScore);
        //                Main.S.ShipDestroyed(this);
        //            }


        //            notifiedOfDestruction = true;


        //            // Destroy this Enemy
        //            Destroy(gameObject);
        //        }

        //        Destroy(otherGO);
        //        break;
        //    default:

        //        break;
        //}
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

}

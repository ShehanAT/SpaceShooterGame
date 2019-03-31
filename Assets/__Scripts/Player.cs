using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player S; // Singleton

    [Header("Set in Inspector")]
    // These fields control the movement of the ship
    public float speed = 30;

    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 40;
    public Weapon[] weapons;
    public AudioSource weaponFireSound;


    [Header("Set dynamically")] [SerializeField]
    private float _shieldLevel = 1;

    // This variable holds a reference to the last triggering GameObject
    private GameObject _lastTriggerGo = null;

    // Declare a new delegate type WeaponFireDelegate
    public delegate void WeaponFireDelegate();

    // Create a WeaponFireDelegate field named fireDelegate.
    public WeaponFireDelegate fireDelegate;

    private void Start()
    {
        if (S == null)
        {
            S = this; // Set the singleton
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }

//        fireDelegate += TempFire;

        // Reset the weapons to start _Player with 1 blaster
        ClearWeapons();
        weapons[0].SetType(WeaponType.blaster);
    }

    private void Update()
    {
        // Pull in information from the Input class
        var xAxis = Input.GetAxis("Horizontal");
        var yAxis = Input.GetAxis("Vertical");
        // Change transform.position based on the axes
        var playerTransform = transform;
        var pos = playerTransform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        playerTransform.position = pos;
        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 0);

//        // Allow the ship to fire
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            TempFire();
//        }
        // Use the fireDelegate to fire Weapons
        // First, make sure the button is pressed: Axis("Jump")
        if (Input.GetAxis("Jump") == 1)
        {
            // Then ensure that fireDelegate isn't null to avoid an error
            fireDelegate?.Invoke();
        }
    }

//    void TempFire()
//    {
//        var projGO = Instantiate(projectilePrefab);
//        projGO.transform.position = transform.position;
//        var rigidB = projGO.GetComponent<Rigidbody>();
////        rigidB.velocity = Vector3.up * projectileSpeed;
//
//        var proj = projGO.GetComponent<Projectile>();
//        proj.type = WeaponType.blaster;
//        var tSpeed = Main.GetWeaponDefinition(proj.type).velocity;
//        rigidB.velocity = Vector3.up * tSpeed;
//    }

    private void OnTriggerEnter(Collider other)
    {
        var rootT = other.gameObject.transform.root;
        var go = rootT.gameObject;
        // print("Triggered: " + go.name);

        // Make sure it's not the same triggering go as last time
        if (go == _lastTriggerGo)
        {
            return;
        }

        _lastTriggerGo = go;
        if (go.CompareTag("enemy0") || go.CompareTag("enemy1") || go.CompareTag("enemy2") || go.CompareTag("enemy3") || go.CompareTag("enemy4"))
        {
            // If the shield was triggered by an enemy
            ShieldLevel--; // Decrease the level of the shield by 1
            Destroy(go); // … and Destroy the enemy
        }
        else if (go.CompareTag("PowerUp"))
        {
            // If the shield was triggered by a PowerUp
            AbsorbPowerUp(go);
        }
        else
        {
            print("Triggered by non-Enemy: " + go.name);
        }
    }

    private void AbsorbPowerUp(GameObject go)
    {
        var pu = go.GetComponent<PowerUp>();
        switch (pu.type)
        {
            case WeaponType.shield:
                ShieldLevel++;
                break;
            default:
                if (pu.type == weapons[0].type)
                {
                    // If it is the same type 
                    var w = GetEmptyWeaponSlot();
                    if (w != null)
                    {
                        // Set it to pu.type
                        w.SetType(pu.type);
                    }
                }
                else
                {
                    // If this is a different weapon type 
                    ClearWeapons();
                    weapons[0].SetType(pu.type);
                }

                break;
        }

        pu.AbsorbedBy(this.gameObject);
    }

    public float ShieldLevel
    {
        get { return (_shieldLevel); }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);
            // If the shield is going to be set to less than zero
            if (!(value < 0)) return;
            print("Destroyed");
            Destroy(this.gameObject);
            // Tell Main.S to restart the game after a delay
            Main.S.DelayedRestart(gameRestartDelay);
        }
    }

    private Weapon GetEmptyWeaponSlot()
    {
        return (from w in weapons where w.type == WeaponType.none select (w)).FirstOrDefault();
    }

    private void ClearWeapons()
    {
        foreach (var w in weapons)
        {
            w.SetType(WeaponType.none);
        }
    }
}
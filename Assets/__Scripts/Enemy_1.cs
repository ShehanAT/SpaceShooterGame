using UnityEngine;

// Enemy_1 extends the Enemy class
public class Enemy_1 : Enemy
{
    [Header("Set in Inspector: Enemy_1")]
    // # seconds for a full sine wave
    public float waveFrequency = 2;

    // sine wave width in meters
    public float waveWidth = 4;
    public float waveRotY = 45;
    private float _x0; // The initial x value of pos

    private float _birthTime;

    // Start works well because it's not used by the Enemy superclass
    private void Start()
    {
        // Set x0 to the initial x position of Enemy_1
        _x0 = pos.x;
        _birthTime = Time.time;
    }

    // Override the Move function on Enemy
    public override void Move()
    {
        // Because pos is a property, you can't directly set pos.x
        // so get the pos as an editable Vector3
        var tempPos = pos;
        // theta adjusts based on time
        var age = Time.time - _birthTime;
        var theta = Mathf.PI * 2 * age / waveFrequency;
        var sin = Mathf.Sin(theta);
        tempPos.x = _x0 + waveWidth * sin;
        pos = tempPos;
        // rotate a bit about y
        var rot = new Vector3(0, sin * waveRotY, 0);
        this.transform.rotation = Quaternion.Euler(rot);
        // base.Move() still handles the movement down in y
        base.Move();
        // print( BndCheck.isOnScreen );
    }
}
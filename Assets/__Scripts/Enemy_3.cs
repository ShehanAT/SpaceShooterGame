using UnityEngine;

public class Enemy_3 : Enemy
{
    // Enemy_3 extends Enemy
    // Enemy_3 will move following a Bezier curve, which is a linear
    // interpolation between more than two points.
    [Header("Set in Inspector: Enemy_3")] public float lifeTime = 5;
    [Header("Set Dynamically: Enemy_3")] public Vector3[] points;

    public float birthTime;

    // Again, Start works well because it is not used by the Enemy superclass
    private void Start()
    {
        points = new Vector3[3]; // Initialize points
        // The start position has already been set by Main.SpawnEnemy()
        points[0] = pos;
        // Set xMin and xMax the same way that Main.SpawnEnemy() does
        var xMin = -BndCheck.camWidth + BndCheck.radius;
        var xMax = BndCheck.camWidth - BndCheck.radius;
        // Pick a random middle position in the bottom half of the screen
        var v = Vector3.zero;
        v.x = Random.Range(xMin, xMax);
        v.y = -BndCheck.camHeight * Random.Range(2.75f, 2);
        points[1] = v;
        // Pick a random final position above the top of the screen
        v = Vector3.zero;
        v.y = pos.y;
        v.x = Random.Range(xMin, xMax);
        points[2] = v;
        // Set the birthTime to the current time
        birthTime = Time.time;
    }

    public override void Move()
    {
        // Bezier curves work based on a u value between 0 & 1
        var u = (Time.time - birthTime) / lifeTime;
        if (u > 1)
        {
            // This Enemy_3 has finished its life
            Destroy(gameObject);
            return;
        }

        // Interpolate the three Bezier curve points
        u = u - 0.2f * Mathf.Sin(u * Mathf.PI * 2);
        var p01 = (1 - u) * points[0] + u * points[1];
        var p12 = (1 - u) * points[1] + u * points[2];
        pos = (1 - u) * p01 + u * p12;
    }
}
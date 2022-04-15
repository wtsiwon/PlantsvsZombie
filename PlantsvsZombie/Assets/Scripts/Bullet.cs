using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    public Vector2 dir;
    public float spd;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    public void SetBullet(float dmg, Vector2 dir, float spd)
    {
        this.dmg = dmg;
        this.dir = dir;
        this.spd = spd;
    }
}

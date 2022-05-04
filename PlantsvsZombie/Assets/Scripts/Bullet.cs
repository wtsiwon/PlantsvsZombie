using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    public Vector2 dir;
    public float spd;

    private Rigidbody2D rb;

    private void Start()//한 방향으로만 스폰되고나서 바로 날아가기
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    public void SetBullet(float dmg, Vector2 dir, float spd)//총알 스탯 조정
    {
        this.dmg = dmg;
        this.dir = dir;
        this.spd = spd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyZone") && collision.CompareTag("Zombie"))
        {
            ReturnBullet();
        }
    }
    private void ReturnBullet()
    {
        BulletPooling.ReturnObject(this);
    }
}

using UnityEngine;

public enum EBulletType
{
    Basic,
    Ice
}
public class Bullet : Obj
{
    public float dmg;
    public Vector2 dir;
    public float spd;
    public EBulletType bulletType;

    private Rigidbody2D rb;

    private void Start()//한 방향으로만 스폰되고나서 바로 날아가기
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    public void SetBullet(float dmg, Vector2 dir, float spd, EBulletType eBulletType = EBulletType.Basic)//총알 스탯 조정
    {
        this.dmg = dmg;
        this.dir = dir;
        this.spd = spd;
        this.bulletType = eBulletType;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie") || collision.CompareTag("DestroyZone"))
        {
            ObjPool.Instance.Return(pooltype, this);
        }
    }
}

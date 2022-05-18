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

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }


    public void SetBullet(float dmg, Vector2 dir, float spd, EBulletType eBulletType = EBulletType.Basic)//ÃÑ¾Ë ½ºÅÈ Á¶Á¤
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
            if (bulletType == EBulletType.Basic)
            {
                ObjPool.Instance.Return(ePool_ObjType.BaseBullet, this);
            }
            else if (bulletType == EBulletType.Ice)
            {
                ObjPool.Instance.Return(ePool_ObjType.IceBullet, this);
            }
        }
    }
}

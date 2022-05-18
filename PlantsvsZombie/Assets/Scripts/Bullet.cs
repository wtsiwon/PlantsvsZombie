using UnityEngine;

public class Bullet : Obj
{
    public float dmg;
    public Vector2 dir;
    public float spd;

    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }


    public void SetBullet(float dmg, Vector2 dir, float spd, ePool_ObjType eBulletType = ePool_ObjType.BaseBullet)//ÃÑ¾Ë ½ºÅÈ Á¶Á¤
    {
        this.dmg = dmg;
        this.dir = dir;
        this.spd = spd;
        this.pooltype = eBulletType;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Zombie") || collision.CompareTag("DestroyZone"))
        {
            for (int i = (int)ePool_ObjType.BaseBullet;
                i <= (int)ePool_ObjType.IceBullet; i++)
            {
                if (pooltype == (ePool_ObjType)i)
                {
                    ObjPool.Instance.Return((ePool_ObjType)i, this);
                }
            }
        }
    }
}

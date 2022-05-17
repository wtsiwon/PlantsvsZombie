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

    private void Start()//�� �������θ� �����ǰ��� �ٷ� ���ư���
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    public void SetBullet(float dmg, Vector2 dir, float spd, EBulletType eBulletType = EBulletType.Basic)//�Ѿ� ���� ����
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

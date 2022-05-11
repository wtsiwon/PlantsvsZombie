using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    public Vector2 dir;
    public float spd;
    private enum EBulletType
    {
        Basic,
        Ice
    }
    private EBulletType bulletType;

    private Rigidbody2D rb;

    private void Start()//�� �������θ� �����ǰ��� �ٷ� ���ư���
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    public void SetBullet(float dmg, Vector2 dir, float spd)//�Ѿ� ���� ����
    {
        this.dmg = dmg;
        this.dir = dir;
        this.spd = spd;
        //this.bulletType = bulletType;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            BaseObjPool.Instance.ReturnObject(this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyZone"))
        {
            BaseObjPool.Instance.ReturnObject(this);
        }
    }
}

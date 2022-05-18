using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class MoneyObj : Obj
{
    Rigidbody2D rb;
    [SerializeField] private float spd;
    private const int MONEY = 25;


    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * spd;
    }

    public void MoneyAdd()
    {
        GameManager.Instance.Money += MONEY;
        ObjPool.Instance.Return(ePool_ObjType.Money, this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyZone"))
        {
            ObjPool.Instance.Return(ePool_ObjType.Money, this);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlants : Plants
{
    protected override void Attack()
    {
        DoublePattern(transform.position);
    }
}

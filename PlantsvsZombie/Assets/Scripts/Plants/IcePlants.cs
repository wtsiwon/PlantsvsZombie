using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlants : Plants
{
    protected override void Attack()
    {
        IcePattern(this.transform.position);
    }
}

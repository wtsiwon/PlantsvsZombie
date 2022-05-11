using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlants : Plants
{
    protected override void Attack()
    {
        BasicPattern(this.transform.position);
    }

}

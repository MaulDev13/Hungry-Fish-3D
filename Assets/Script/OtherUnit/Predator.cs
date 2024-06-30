using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : OtherUnit
{
    [SerializeField] float damage = 20f;

    public override float Collide()
    {
        return -damage;
    }
}

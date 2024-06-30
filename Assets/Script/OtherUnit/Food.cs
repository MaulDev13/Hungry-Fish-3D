using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : OtherUnit
{
    [SerializeField] float heal = 20f;

    public override float Collide()
    {
        Invoke("Dead", 0.2f);

        return heal;
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}

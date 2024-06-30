using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] string otherUnit = "Unit";

    [SerializeField] float life = 100f;
    [SerializeField] float maxLife = 100f;
    [SerializeField] float currentInjuryTime = 0f;
    [SerializeField] float injuryTime = 0.5f;

    [SerializeField] TextMeshProUGUI lifeTxt;

    [SerializeField] bool isBleeding = true;
    [SerializeField] float bleedingDamage = 1f;

    bool isDead = false;
    public bool IsDead => isDead;

    public delegate void OnEvent();
    public OnEvent onDead;

    private void Start()
    {
        isDead = false;

        if (isBleeding)
            InvokeRepeating("Bleeding", 1f, 1f);
    }

    private void FixedUpdate()
    {
        if (currentInjuryTime >= 0f)
            currentInjuryTime -= Time.fixedDeltaTime;
    }

    void Bleeding()
    {
        OnLifeChange(-bleedingDamage);
    }

    public void OnLifeChange(float value)
    {
        life = life + value;

        if(life < 0f)
        {
            // Dead
            life = 0f;
            LifeTxt();
            Dead();
        }
        
        if(life > maxLife)
        {
            life = maxLife;
        }

        LifeTxt();
    }

    public void Dead()
    {
        // GameOver
        isDead = true;

        if (onDead != null)
            onDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == otherUnit)
        {
            var unitScript = other.gameObject.GetComponent<OtherUnit>();

            OnLifeChange(unitScript.Collide());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == otherUnit)
        {
            var unitScript = collision.gameObject.GetComponent<OtherUnit>();

            var value = unitScript.Collide();

            // Interval when get hit
            if (value < 0f)
            {
                if (currentInjuryTime > 0f)
                    return;
                else
                    currentInjuryTime = injuryTime;
            }

            OnLifeChange(value);
        }
    }

    void LifeTxt()
    {
        lifeTxt.text = $"Nyawa {Mathf.RoundToInt(life)}/{Mathf.RoundToInt(maxLife)}";
    }
}

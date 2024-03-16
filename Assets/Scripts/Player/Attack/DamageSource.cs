using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MonsterHealth>())
        {
            MonsterHealth monsterHealth = other.gameObject.GetComponent<MonsterHealth>();
            monsterHealth.TakeDamage(damageAmount);
        }
        if (other.gameObject.GetComponent<MonsterAI>())
        {
            Debug.Log("aaaa");
        }
    }
}

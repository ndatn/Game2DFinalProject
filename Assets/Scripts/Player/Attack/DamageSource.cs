using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class DamageSource : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 3;

        private void OnTriggerEnter2D(Collider2D other)
        {
            MonsterHealth monsterHealth = other.gameObject.GetComponent<MonsterHealth>();
            monsterHealth?.TakeDamage(damageAmount);

        }
    }




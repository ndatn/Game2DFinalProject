using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private GameObject dieEffectPrefab;
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        flash = GetComponentInChildren<Flash>();
    }
    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(checkDetectDieRoutine());
    }
    private IEnumerator checkDetectDieRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMaterialTime());
        DetectDie();
    }

    public void DetectDie()
    {
        if (currentHealth <= 0)
        {
            Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

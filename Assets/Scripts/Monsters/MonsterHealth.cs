using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
public class MonsterHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

    private int currentHealth;
    private KnockBack knockback;
    private Flash flash;
    private WorldTime.WorldTime worldTime;
    private SoundsManager soundsManager;
    //private bool stop = false;

    private void Awake()
    {
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();

        flash = GetComponent<Flash>();
        knockback = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    /*private void OnDestroy()
    {
        if (worldTime != null)
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        if (newTime.Hours <= 5)
        {
            currentHealth = 4;
            //Debug.Log(currentHealth);
        }
        else
        {
            currentHealth = 6;
            //Debug.Log(currentHealth);

        }
    }

    private void Update()
    {

        if (worldTime != null&& !stop)
        {
            if (worldTime != null)
            {
                worldTime.WorldTimeChanged += OnWorldTimeChanged;
            }
            TimeSpan currentTime = worldTime._currentTime;

            if (currentTime.Hours <= 5)
            {
                currentHealth = 4;
            }
            else
            {
                currentHealth = 6;
            }
            Debug.Log(currentHealth);

        }
    }*/

    public void TakeDamage(int damage)
    {
        //stop = true;
        currentHealth -= damage;
        Debug.Log(currentHealth);
        knockback.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
        soundsManager.PlaySFX(soundsManager.DamageS);

    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMaterialTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0 )
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickupSpawner>().DropItems();
            Destroy(gameObject);
        }
    }
}
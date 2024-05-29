using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;
    private SoundsManager soundsManager;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newArrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
        soundsManager.PlaySFX(soundsManager.Gun);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}

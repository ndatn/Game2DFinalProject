using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WorldTime
{
public class Destructible : MonoBehaviour
{
        [SerializeField] private GameObject destroyVFX;
        private SoundsManager soundsManager;
        private void Awake()
        {
            soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
            {
                soundsManager.PlaySFX(soundsManager.BWood);
                GetComponent<PickupSpawner>().DropItems();
                Instantiate(destroyVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}



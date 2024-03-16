using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material WhiteFlashMaterial;
    [SerializeField] private float restoreDefaultMaterialTime = .2f;
    private Material defaultMaterial;
    private SpriteRenderer spriteRenderer;
    private MonsterHealth monsterHealth;
    private void Awake()
    {
        monsterHealth = GetComponent<MonsterHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = spriteRenderer.material;
    }
    public IEnumerator FlashRoutine()
    {
        spriteRenderer.material = WhiteFlashMaterial;
        yield return new WaitForSeconds(restoreDefaultMaterialTime);
        spriteRenderer.material = defaultMaterial;
        monsterHealth.DetectDeath();
    }
}

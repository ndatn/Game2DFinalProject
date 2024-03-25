using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool GettingKnockedBack { get; private set; }
    [SerializeField] private float knockbackTime = 0.1f;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void GetKnockedBack(Transform damageSource, float knockBackThrust)
    {
        GettingKnockedBack = true;
        Vector2 different = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(different, ForceMode2D.Impulse);
        StartCoroutine(KnockRountine());
    }
    private IEnumerator KnockRountine()
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.velocity = Vector2.zero;
        GettingKnockedBack = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockBack;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (knockBack.gettingKnockedBack)
        {
            return;
        }
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }
    public void MoveTo(Vector2 targetPosstion)
    {
        moveDir = targetPosstion;
    }
}

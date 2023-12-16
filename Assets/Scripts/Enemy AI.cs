using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public static int Hp = 6;


    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target; // Jav�t�s: "Trasnform" helyett "Transform"
    private Rigidbody2D rb; // Jav�t�s: "Rigidbody20" helyett "Rigidbody2D"
    private Animator anim;
    private Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("player").transform; // Jav�t�s: "FindWithTag" helyett "FindGameObjectWithTag"
    }

    private void Update()
    {
        anim.SetBool("IsRunning", isInChaseRange); // Jav�t�s: "isRunning".isInChaseRange" helyett "isRunning", isInChaseRange)"

        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer); // Jav�t�s: "Physichs2D" helyett "Physics2D", "attckRadius" helyett "attackRadius"

        dir = target.position - transform.position; // Jav�t�s: "target.position = transform.position" helyett "target.position - transform.position"
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        Vector2 movement = dir; // Jav�t�s: "movement = dir;" helyett "Vector2 movement = dir;"

        if (shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
        if(Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(dir.normalized); // Jav�t�s: "movement" helyett "dir.normalized"
        }
        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    public void TakeDamage(int damage) {
        Hp -= damage;
        Debug.Log("Damage tanken");
    }


}

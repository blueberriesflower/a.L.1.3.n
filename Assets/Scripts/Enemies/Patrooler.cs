using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Patrooler : Enemy
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float speed;
    [SerializeField] private GameObject missile;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private Transform currentTargetTransform;
    private int missileCounter = 0;
    private GameObject player;
    static LayerMask enemyMask;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        enemyMask = ~LayerMask.GetMask("Enemy");
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentTargetTransform = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {
        isInFight = isHeroCloseEnough();

        animator.SetBool("Is Walking", !isInFight);
        if (isInFight)
        {
            if (player.transform.position.x < transform.position.x ^ GetComponent<SpriteRenderer>().flipX)
                Flip();
            Shoot();
        }
        else
        {
            if (currentTargetTransform == pointB.transform)
                rb.velocity = new Vector2(speed, 0);
            else
                rb.velocity = new Vector2(-speed, 0);

            if (Vector2.Distance(transform.position, currentTargetTransform.position) < 0.5f)
                if (currentTargetTransform == pointB.transform)
                    currentTargetTransform = pointA.transform;
                else if (currentTargetTransform == pointA.transform)
                    currentTargetTransform = pointB.transform;

            if (currentTargetTransform.position.x < transform.position.x ^ GetComponent<SpriteRenderer>().flipX)
                Flip();
        }
    }

    private void Flip()
    {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }

    private bool isHeroCloseEnough()
    {
        return Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            15,
            enemyMask)
            .transform?.CompareTag("Player") ?? false;
    }

    private void Shoot()
    {
        if (missileCounter != 0)
        {
            missileCounter--;
            return;
        }

        if (player.transform.position.x < transform.position.x)
        {
            transform.Rotate(0, 180, 0);
            Instantiate(
                missile,
                transform.position - new Vector3(0.45f, 0.2f),
                Quaternion.FromToRotation(
                    Vector3.right,
                    player.transform.position - transform.position));
            transform.Rotate(0, -180, 0);
        }
        else
            Instantiate(
                missile,
                transform.position - new Vector3(-0.45f, 0.2f),
                Quaternion.FromToRotation(
                    Vector3.right,
                    player.transform.position - transform.position));
        missileCounter = 40;
        audio.PlayOneShot(audio.clip);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}

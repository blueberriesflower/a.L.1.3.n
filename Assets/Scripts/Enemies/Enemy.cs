using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public GameObject player;
    public int health = 3;
    public bool isInFight;

    // Start is called before the first frame update
    void Start()
    {
        isInFight = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        
    }

    public void GetDamage()
    {
        health -= 1;
        if (health <= 0)
            Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float damageCooldown = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageCooldown -= Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && damageCooldown <= 0)
        {
            damageCooldown = 0.3f;
            other.gameObject.GetComponent<PlayerStatus>().GetDamage();
        }
    }
}

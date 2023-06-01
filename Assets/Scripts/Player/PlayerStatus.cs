using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] public float currentHealth = 10f;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] PlayerMovement playerMovement;
    private float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        damage = PlayerPrefs.GetString("Difficulty") switch
        {
            "Easy" => 0.4f,
            "Medium" => 1,
            "Hard" => 3
        };
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

    }

    public void GetDamage()
    {
        if (currentHealth > 0)
        {
            playerAnimator.Play("Get Damage");
            currentHealth -= damage;
            if (currentHealth <= 0)
                playerMovement.Die();
        }
    }
}

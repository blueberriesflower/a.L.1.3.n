using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Missile;
    private AudioSource audio;
    private int cooldown = 50;
    private int cooldownCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
        if (cooldownCounter > 0)
            cooldownCounter--;
    }

    private void FixedUpdate()
    {

    }

    private void Shoot()
    {
        if (cooldownCounter == 0)
        {
            Instantiate(Missile, gameObject.transform.position, Quaternion.FromToRotation(Vector3.right, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
            audio.PlayOneShot(audio.clip);
            cooldownCounter = cooldown;
        }
    }
}
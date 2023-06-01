using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Missile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }

    private void FixedUpdate()
    {

    }

    private void Shoot()
    {
        Instantiate(
            Missile,
            gameObject.transform.position,
            Quaternion.FromToRotation(
                Vector3.right, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position));
    }
}

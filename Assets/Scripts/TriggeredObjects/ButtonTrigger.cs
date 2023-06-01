using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private TriggerableObject linkedObject;
    [SerializeField] private LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeroCloseEnough() && Input.GetKeyUp(KeyCode.E))
        {
            linkedObject.MakeTriggered();
        }
    }

    private bool isHeroCloseEnough()
    {
        return Physics2D.OverlapCircle(transform.position, 1.0f, playerLayer);
    }
}

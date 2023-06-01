using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : TriggerableObject
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            sprite.color = Color.green;
            boxCollider.enabled = false;
        }
    }

    override public void MakeTriggered()
    {
        isTriggered = true;
    }
}

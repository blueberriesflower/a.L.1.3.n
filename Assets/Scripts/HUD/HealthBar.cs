using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject player;
    float current;
    Image bar;

    // Start is called before the first frame update
    void Start()
    {
        current = 1f;
        bar = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            current = 0;
            bar.fillAmount = current;
            return;
        }

        current = player.GetComponent<PlayerStatus>().currentHealth / player.GetComponent<PlayerStatus>().maxHealth;
        bar.fillAmount = current;
        var color = bar.color;
        color.r = (1 - Mathf.Max(current, 0.5f)) * 2;
        color.g = Mathf.Min(current, 0.5f) * 2;
        bar.color = color;
    }
}

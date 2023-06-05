using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    public int health;
    public Animator animator; // Reference to the Animator component
    public TextMeshPro healthText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        animator = GetComponent<Animator>();

        healthText = transform.Find("Health").GetComponent<TextMeshPro>();

        // Initially update the health display
        healthText.text = "" + health;
        healthText.color = Color.green;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the Attack script/component
        CardStats attacker = collision.gameObject.GetComponent<CardStats>();
        if (attacker != null)
        {
            Debug.Log("Boss was attacked");
            // Deduct health by the attack value of the other object
            health -= attacker.attackValue;
            healthText.text = "" + health;
            healthText.color = Color.red;
            if (health <= 0)
            {
                // Play the 'Die' animation
                animator.Play("Die");
            }
            attacker.transform.position = attacker.originalPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    public int health;
    public Animator animator; // Reference to the Animator component
    public TextMeshPro healthText; // Reference to the TextMeshProUGUI component
    public AudioSource audioSource; // Reference to the Audio Source component
    public AudioClip winSound; // Reference to the Audio Clip file

    void Start()
    {
        animator = GetComponent<Animator>();

        healthText = transform.Find("Health").GetComponent<TextMeshPro>();

        // Initially update the health display
        healthText.text = "" + health;
        
        healthText.color = Color.green;

        audioSource = GetComponent<AudioSource>(); // Get the Audio Source component
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

                // find a gameobject with name GameOverText and set its text to "You Win!"
                GameObject.Find("GameOverText").GetComponent<TextMeshPro>().text = "Victory!\nYou've defeated the boss!";
                GameObject.Find("GameOverText").GetComponent<TextMeshPro>().fontSize = 12;
                // set color to orange
                GameObject.Find("GameOverText").GetComponent<TextMeshPro>().color = new Color(206,105,0);
                // set text to bold
                GameObject.Find("GameOverText").GetComponent<TextMeshPro>().fontStyle = FontStyles.Bold;

                // Play the win sound on the Audio Source
                audioSource.PlayOneShot(winSound);

            }
            attacker.transform.position = attacker.originalPosition;
        }
    }
}

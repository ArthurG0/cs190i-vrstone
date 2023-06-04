using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CardDrop : MonoBehaviour
{
    public GameObject attackObject;
    public GameObject healthObject;
    public TextMeshPro attackText; // Reference to the TextMeshProUGUI component
    public TextMeshPro healthText; // Reference to the TextMeshProUGUI component

    void OnTriggerEnter(Collider other)
    {
        Card card = other.GetComponent<Card>();

        if (card != null) // Check if the object is a Card
        {
            MeshFilter meshFilter = other.gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null) // Check if the Card has a MeshFilter component
            {
                meshFilter.mesh = card.cardMesh; // Change the card's mesh to its cardMesh
                card.cardFront.SetActive(false);
                card.cardBack.SetActive(false);
                other.transform.localScale = Vector3.one;

                Attack attacker = other.GetComponent<Attack>();
                if (attacker != null)
                {
                    // Update the original position of the attacker
                    attacker.UpdateOriginalPosition(other.transform.position);
                }
                attackObject.SetActive(true);
                attackText = attackObject.GetComponent<TextMeshPro>();
                attackText.text = "" + attacker.attackValue;
                attackText.color = Color.red;

                healthObject.SetActive(true);
                healthText = healthObject.GetComponent<TextMeshPro>();
                healthText.text = "" + attacker.healthValue;
                healthText.color = Color.green;
            }
            else
            {
                Debug.LogError("Dropped object does not have a MeshFilter component!");
            }
        }
    }
}

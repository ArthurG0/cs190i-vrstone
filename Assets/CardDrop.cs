using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrop : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Card card = other.GetComponent<Card>();

        if (card != null) // Check if the object is a Card
        {
            MeshFilter meshFilter = other.gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null) // Check if the Card has a MeshFilter component
            {
                meshFilter.mesh = card.cardMesh; // Change the card's mesh to its cardMesh
                other.transform.localScale = Vector3.one;
            }
            else
            {
                Debug.LogError("Dropped object does not have a MeshFilter component!");
            }
        }
    }
}

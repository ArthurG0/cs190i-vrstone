using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c){
        Debug.Log("DiscardPile OnTriggerEnter");

        // check if the collision is with a card
        GameObject card = c.gameObject;

        // check if object has a component Card. If not, do nothing
        if (card.GetComponent<Card>() == null) {
            Debug.Log("Not a card");
            return;
        }
        



        // delete the card object
        Destroy(card.gameObject);



    }
}

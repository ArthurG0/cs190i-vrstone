using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("HandSlot OnTriggerEnter");
        GameObject card = c.gameObject;
        // turn off gravity of card
        card.GetComponent<Rigidbody>().useGravity = false;
        // set speed to 0 for all axis
        card.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // set angular velocity to 0 for all axis
        card.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        // set the position of the card to be slightly above the collision
        card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y + 0.15f, card.transform.position.z + 0.15f);
        // set the rotation of the card to be 0, 0, 0
        card.transform.rotation = Quaternion.Euler(-120, 0, 0);


    }
}

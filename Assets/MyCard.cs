using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Lol Start!");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("card is Colliding!");
        float offsetHeight = 0.2f;
        // Check if the collision is with the DropOffZone
        if (collision.gameObject.name == "DropOffZone")
        {
            // Disable gravity
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;
                rb.velocity = new Vector3(0,0,0);
                rb.angularVelocity = new Vector3(0,0,0);
            }

            // Adjust position above the DropOffZone
            Vector3 newPosition = collision.transform.position + Vector3.up * offsetHeight;
            transform.position = newPosition;
            transform.eulerAngles = new Vector3(75,0,0);



        }
    }

}

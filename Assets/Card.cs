using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Card : MonoBehaviour
{
    public Mesh cardMesh;
    public GameObject cardFront;
    public GameObject cardBack;
    public int attackValue;
    public int healthValue;
    public bool isGrabbed;
    public bool isCardForm;

    void Start() {

        this.isGrabbed = false;

        attackValue = this.GetComponent<CardStats>().attackValue;
        healthValue = this.GetComponent<CardStats>().healthValue;


        // get the Attack child gameobject and enable it
        // this.transform.Find("Attack").gameObject.SetActive(true);
        // get the Health child gameobject and enable it
        // this.transform.Find("Health").gameObject.SetActive(true);

        // get the TextMeshPro component of both and set the color to blue
        this.transform.Find("Attack").gameObject.GetComponent<TextMeshPro>().color = Color.blue;
        this.transform.Find("Health").gameObject.GetComponent<TextMeshPro>().color = Color.blue;

        this.transform.Find("Attack").gameObject.GetComponent<TextMeshPro>().fontSize = 20;
        this.transform.Find("Health").gameObject.GetComponent<TextMeshPro>().fontSize = 20;


    }

    void Update() {

        // if (this.isGrabbed) {
        //     // set rotation on x axis to -90, keep other rotations the same
        //     Quaternion newRotation = Quaternion.Euler(-90, this.transform.rotation.y, this.transform.rotation.z);
        //     this.transform.rotation = newRotation;
        //     // print I'm grabbed
        //     print("I'm grabbed");

                        
        // }
    }

    public void setGrabbed(bool grabbed) {
        this.isGrabbed = grabbed;

            
    }

    public void setGrabbedTrue() {
        Debug.Log("setGrabbedTrue");

        // set rotation of card to 0 on x axis
        this.transform.rotation = Quaternion.Euler(0, this.transform.rotation.y, this.transform.rotation.z);
    


        this.isGrabbed = true;
    }
    public void setGrabbedFalse() {
        Debug.Log("setGrabbedFalse");

        this.isGrabbed = false;

        // turn on gravity of card
        this.GetComponent<Rigidbody>().useGravity = true;

    }
    
}

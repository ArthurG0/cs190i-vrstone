using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CardDrop : MonoBehaviour
{
    // public GameObject attackObject;
    // public GameObject healthObject;
    // public TextMeshPro attackText; // Reference to the TextMeshProUGUI component
    // public TextMeshPro healthText; // Reference to the TextMeshProUGUI component
    public CostDisplayScript costDisplay;
    public bool cardAlive = false;
    

    void OnTriggerEnter(Collider other)
    {


        Card card = other.GetComponent<Card>();
        // print the card object and list of children
        print(card);
        int cv;
        cv = card.costValue;

        if (card.healthValue <= 0)
        {
            cardAlive = false;
        }

        // if mana is less than the current cost and a card has not been made
        if (cv < costDisplay.cost && !cardAlive)
            {
            print(card.gameObject.name);
            print(card.gameObject.transform.childCount);
            // for each child in children, print the child
            for (int i = 0; i < card.gameObject.transform.childCount; i++) {
                print(card.gameObject.transform.GetChild(i));
                // and print the type of object that child is
                print(card.gameObject.transform.GetChild(i).gameObject.GetType());
            }

            // enable attack and health objects
            card.gameObject.transform.Find("Attack").gameObject.SetActive(true);
            card.gameObject.transform.Find("Health").gameObject.SetActive(true);
            card.gameObject.transform.Find("Cost").gameObject.SetActive(true);


            // get the child object of the card object that has the name Attack and get its textMeshPro component
            TextMeshPro attackText = card.gameObject.transform.Find("Attack").gameObject.GetComponent<TextMeshPro>();
            // set the value to the attackValue varaible from the CardStats script
            attackText.text = "" + card.attackValue;
            // get the child object of the card object that has the name Health and get its textMeshPro component
            TextMeshPro healthText = card.gameObject.transform.Find("Health").gameObject.GetComponent<TextMeshPro>();
            healthText.text = "" + card.healthValue;

            TextMeshPro costText = card.gameObject.transform.Find("Cost").gameObject.GetComponent<TextMeshPro>();
            costText.text = "" + card.costValue;

            // update colors of the healthText and attackText
            attackText.color = Color.green;
            healthText.color = Color.red;
            costText.color = Color.blue;

            


            if (card == null) {
                Debug.Log("This was not a card");
                return;
            }

            MeshFilter meshFilter = other.gameObject.GetComponent<MeshFilter>();

            if (meshFilter == null) {
                Debug.Log("This card does not have a mesh filter");
                return;
            }
            meshFilter.mesh = card.cardMesh;
            Texture2D texture = Resources.Load<Texture2D>("Assets/Meshtint Free Boximon Fiery Mega Toon Series/Textures/Boximon Fiery.psd");
            // card.GetComponent<Renderer>().material.color = Color.black;
            // update the texture of renderer to texture
            Material m = card.GetComponent<Renderer>().material;
            if (m) {
                m.SetTexture("_MainTex", texture);
            }
            // set the color to a color value #bbccee



            card.cardFront.SetActive(false);
            card.cardBack.SetActive(false);
            other.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            CardStats attacker = other.GetComponent<CardStats>();
            if (attacker != null)
            {
                // Update the original position of the attacker
                attacker.UpdateOriginalPosition(other.transform.position);
            }


            costDisplay.DecreaseManaCost(cv);


            cardAlive = true;

            // if (meshFilter != null) // Check if the Card has a MeshFilter component
            // {
            //     meshFilter.mesh = card.cardMesh; // Change the card's mesh to its cardMesh
            //     card.cardFront.SetActive(false);
            //     card.cardBack.SetActive(false);
            //     other.transform.localScale = Vector3.one;

            //     attackObject.SetActive(true);
            //     attackText = attackObject.GetComponent<TextMeshPro>();
            //     attackText.text = "" + attacker.attackValue;
            //     attackText.color = Color.red;

            //     healthObject.SetActive(true);
            //     healthText = healthObject.GetComponent<TextMeshPro>();
            //     healthText.text = "" + attacker.healthValue;
            //     healthText.color = Color.green;
            // }
        }
        else
        {
            Debug.Log("Not enough mana");
        }

        

        /*
        Card card = other.GetComponent<Card>();

        print(card.gameObject.name);
        print(card.gameObject.transform.childCount);
        // for each child in children, print the child
        for (int i = 0; i < card.gameObject.transform.childCount; i++) {
            print(card.gameObject.transform.GetChild(i));
            // and print the type of object that child is
            print(card.gameObject.transform.GetChild(i).gameObject.GetType());
        }

        // enable attack and health objects
        card.gameObject.transform.Find("Attack").gameObject.SetActive(true);
        card.gameObject.transform.Find("Health").gameObject.SetActive(true);
        card.gameObject.transform.Find("Cost").gameObject.SetActive(true);


        // get the child object of the card object that has the name Attack and get its textMeshPro component
        TextMeshPro attackText = card.gameObject.transform.Find("Attack").gameObject.GetComponent<TextMeshPro>();
        // set the value to the attackValue varaible from the CardStats script
        attackText.text = "" + card.attackValue;
        // get the child object of the card object that has the name Health and get its textMeshPro component
        TextMeshPro healthText = card.gameObject.transform.Find("Health").gameObject.GetComponent<TextMeshPro>();
        healthText.text = "" + card.healthValue;

        TextMeshPro costText = card.gameObject.transform.Find("Cost").gameObject.GetComponent<TextMeshPro>();
        costText.text = "" + card.costValue;

        // update colors of the healthText and attackText
        attackText.color = Color.green;
        healthText.color = Color.red;
        costText.color = Color.blue;

        // make attacktext and healthtext bold
        attackText.fontStyle = FontStyles.Bold;
        healthText.fontStyle = FontStyles.Bold;


            


        if (card == null) {
            Debug.Log("This was not a card");
            return;
        }

        MeshFilter meshFilter = other.gameObject.GetComponent<MeshFilter>();

        if (meshFilter == null) {
            Debug.Log("This card does not have a mesh filter");
            return;
        }
        meshFilter.mesh = card.cardMesh;
        Texture2D texture = Resources.Load<Texture2D>("Assets/Meshtint Free Boximon Fiery Mega Toon Series/Textures/Boximon Fiery.psd");
        // card.GetComponent<Renderer>().material.color = Color.black;
        // update the texture of renderer to texture
        Material m = card.GetComponent<Renderer>().material;
        if (m) {
            m.SetTexture("_MainTex", texture);
        }
        // set the color to a color value #bbccee

        // change the scale of the card to 0.5, 0.5, 0.5



        card.cardFront.SetActive(false);
        card.cardBack.SetActive(false);
        CardStats attacker = other.GetComponent<CardStats>();
        if (attacker != null)
        {
            // Update the original position of the attacker
            attacker.UpdateOriginalPosition(other.transform.position);
        }

        other.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);


            // if (meshFilter != null) // Check if the Card has a MeshFilter component
            // {
            //     meshFilter.mesh = card.cardMesh; // Change the card's mesh to its cardMesh
            //     card.cardFront.SetActive(false);
            //     card.cardBack.SetActive(false);
            //     other.transform.localScale = Vector3.one;

            //     attackObject.SetActive(true);
            //     attackText = attackObject.GetComponent<TextMeshPro>();
            //     attackText.text = "" + attacker.attackValue;
            //     attackText.color = Color.red;

            //     healthObject.SetActive(true);
            //     healthText = healthObject.GetComponent<TextMeshPro>();
            //     healthText.text = "" + attacker.healthValue;
            //     healthText.color = Color.green;
            // }
        */

        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CostDisplayScript : MonoBehaviour
{
    
    public int cost;
    public int totalCost;
    public TextMeshPro costText;
    
    // Start is called before the first frame update
    void Start()
    {
        cost = 9;
        totalCost = 9;

        // healthText = transform.Find("Health").GetComponent<TextMeshPro>();
        costText = transform.Find("Cost").GetComponent<TextMeshPro>();
        costText.text = "" + cost;
        costText.color = Color.blue;

        //+ "/" + totalCost; 

    }

    public void DecreaseManaCost(int cardCost)
    {
        cost -= cardCost;
    }


    // Update is called once per frame
    void Update()
    {
        costText = transform.Find("Cost").GetComponent<TextMeshPro>();
        costText.text = "" + cost + "/" + totalCost; 

        //costText.text = cost.ToString() + "/" + totalCost.ToString;
        // text.text = cost.ToString() + "/" + totalCost.ToString();
    }
}

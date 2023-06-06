using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCardDeck : MonoBehaviour
{
    //public GameObject objectToSpawn;
    public List <Card> objectToSpawn;

    public void MyFunction() 
    {
        Debug.Log("Start MyCustomFunction");

    }

    public void IHoverOver() 
    {
        Debug.Log("Start I Hovered Over function ran");

    }


    public void ISelected() 
    {
        if (objectToSpawn.Count != 0)
        {
            int randomIndex = Random.Range(0, objectToSpawn.Count);
            Debug.Log("I selected function ran");
            Vector3 positionCurrent = GameObject.Find("CardDeck").transform.position;
            Vector3 new_pos = new Vector3(positionCurrent.x, positionCurrent.y + 0.05f, positionCurrent.z);
            Instantiate(objectToSpawn[randomIndex], new_pos, Quaternion.identity);
            
            objectToSpawn.Remove(objectToSpawn[randomIndex]);

            
        }
    }
    

}

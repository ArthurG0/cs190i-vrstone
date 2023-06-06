using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStats : MonoBehaviour
{
    public int attackValue;
    public int healthValue;
    public int costValue;
    public Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void UpdateOriginalPosition(Vector3 newPosition)
    {
        originalPosition = newPosition;
    }
}

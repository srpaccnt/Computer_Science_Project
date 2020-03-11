using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cardArray;
    GameObject randomCard;
    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log("Hello " +cardArray.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCard()
    {
        randomInt = Random.Range(0, cardArray.Count);
        randomCard = cardArray[randomInt];
        cardArray.Remove(randomCard);
        return randomCard;
    }
}

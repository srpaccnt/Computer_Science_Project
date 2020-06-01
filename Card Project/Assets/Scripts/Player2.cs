using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
   public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetPlayer2()
    {
        player2 = FindObjectOfType<Deck>().GetCard();

        player2.transform.localScale = new Vector3(-32.6f, 35f, -1.76f);
        player2.transform.localPosition = new Vector3(-223f, -474f, 0f);
        player2.transform.rotation = Quaternion.Euler(-2.2f, 1.7f, -0.7f);

    }
}

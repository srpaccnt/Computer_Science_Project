using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
   public GameObject cpuCard;
    List<GameObject> aDeck;
    // Start is called before the first frame update
   
    void Start()
    { int tempInt = Random.Range(0, 52);
        cpuCard = FindObjectOfType<Deck>().GetCard();


    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public GameObject GetCpu() {
        GameObject tempOb = Instantiate(cpuCard) as GameObject;
        tempOb.transform.localScale = new Vector3(39, 36f, 10f);
        tempOb.transform.localPosition = new Vector3(0, 4.5f, 0f);
        return tempOb;
    }
}

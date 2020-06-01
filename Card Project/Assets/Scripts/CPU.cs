using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
   public GameObject cpuCard;
    // Start is called before the first frame update
   
    void Start()
    { int tempInt = Random.Range(0, FindObjectOfType<Deck>().cardArray.Count-1);


    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public GameObject GetCpu() {
        cpuCard = FindObjectOfType<Deck>().GetCard();
        GameObject tempOb = Instantiate(cpuCard) as GameObject;
        tempOb.transform.localScale = new Vector3(39, 36f, 10f);
        tempOb.transform.localPosition = new Vector3(0, 3.5f, 0f);
        return tempOb;
    }
}

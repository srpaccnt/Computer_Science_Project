using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
   public GameObject cpuCard;
    // Start is called before the first frame update
    GameObject[] cardArray;
    GameObject c1, c2, c3, c4;
    GameObject aG;
    void Start()
    {
        int tempInt = Random.Range(0, 53);
        Transform testObject = FindObjectOfType<Deck>().transform.GetChild(tempInt);
        cpuCard = testObject.gameObject;
        aG = Instantiate(cpuCard) as GameObject;
        aG.transform.position = new Vector3(0.15f, 4.6f, -0.68F);
        aG.transform.localScale = new Vector3(30f, 32f, 10f);
        aG.transform.rotation = Quaternion.Euler(190F, -180F, 0F);

    }

    // Update is called once per frame
    void Update()
    {
       

    }

    public GameObject GetCpu() {
        return aG;
    }
}

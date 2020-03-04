﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySquare : MonoBehaviour
{
    public GameObject prefab;
    List<GameObject> cardArray;
    GameObject c1, c2, c3, c4;
    GameObject ib1,ib2;
    Button bf,bc;
    GameObject cpuCard;
    GameObject aG;
    // Start is called before the first frame update
    void Start()
    {
        int tempInt = Random.Range(0, 53);
        cardArray = new List<GameObject>();
        Transform testObject = FindObjectOfType<Deck>().transform.GetChild(tempInt);
        for (int i = 0; i <53; i++) {
            cardArray.Add(FindObjectOfType<Deck>().transform.GetChild(i).gameObject);
        }
        GameObject testObject2 = cardArray[tempInt];
        cardArray.Remove(testObject2);



        prefab = testObject2;
        cpuCard = FindObjectOfType<CPU>().GetCpu();
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void MakeSquare() {
        aG = Instantiate(prefab) as GameObject;
        aG.transform.position = new Vector3(0f, -2F,0F);
        aG.transform.localScale = new Vector3(42f, 36f, 10f);
        aG.transform.rotation = Quaternion.Euler(190F, 0F, 0F);

        GameObject b1 = GameObject.FindGameObjectWithTag("swap");
         ib1 = Instantiate(b1) as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
         bf = ib1.GetComponent<Button>();
        
        ib1.transform.SetParent(canvas.transform);
        ib1.transform.position = new Vector3(-81, -38, 0F);
        ib1.GetComponent<RectTransform>().sizeDelta = new Vector2(112, 30);
        ib1.GetComponent<RectTransform>().localPosition =new Vector3(-82f, -38f,0f);
        ib1.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        bf.GetComponentInChildren<Text>().text = "Continue";
        bf.onClick.AddListener(SwapCard);


        GameObject b2 = GameObject.FindGameObjectWithTag("continue");
        ib2 = Instantiate(b2) as GameObject;
        bc = ib2.GetComponent<Button>();

        ib2.transform.SetParent(canvas.transform);
        ib2.transform.position = new Vector3(-81, -38, 0F);
        ib2.GetComponent<RectTransform>().sizeDelta = new Vector2(112, 30);
        ib2.GetComponent<RectTransform>().localPosition = new Vector3(30f, -38f, 0f);
        ib2.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        bc.GetComponentInChildren<Text>().text = "Swap";
        bc.onClick.AddListener(Continue);
        Destroy(b1);

    }

   public void SwapCard() {

        bf = ib1.GetComponent<Button>();
        cpuCard = FindObjectOfType<CPU>().GetCpu();
      GameObject af = Instantiate(cpuCard) as GameObject;
        af.transform.rotation = Quaternion.Euler(0f, 180F, 0F);
        Destroy(cpuCard);


    }

    public void Continue() {
        cpuCard = FindObjectOfType<CPU>().GetCpu();
        Destroy(aG);
        int tempInt = Random.Range(0, cardArray.Count);
        GameObject swappedCard = cardArray[tempInt];
        swappedCard.transform.position = new Vector3(0f, -2F, 0F);
        swappedCard.transform.localScale = new Vector3(42f, 36f, 10f);
        swappedCard.transform.rotation = Quaternion.Euler(190F, 0F, 0F);

        GameObject af = Instantiate(cpuCard) as GameObject;
        af.transform.rotation = Quaternion.Euler(0f, 180F, 0F);
        Destroy(cpuCard);



    }




}

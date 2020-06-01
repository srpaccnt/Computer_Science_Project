using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MySquare : MonoBehaviour
{
    GameObject c1, c2, c3, c4;
    GameObject b1;
    GameObject ib1, ib2;
    GameObject tView;
    Button bf, bc;
    GameObject cpuCard;
    public GameObject aG;
    GameObject af;
    Deck deck;
   [SerializeField] int score;
    [SerializeField] int gameValueInt;
  [SerializeField]  int cpuValueInt;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioClip clickClip;



    List<GameObject> aDeck;
    Gamesession session;
    GameObject getCard;
    [SerializeField] Text cardValue;
    [SerializeField] Text cpuValue;
    // Start is called before the first frame update
    void Start()
    {
        tView = GameObject.Find("MyText");
        TextMeshPro tpro = GetComponent<TextMeshPro>();
        getCard = GameObject.Find("GetCard");
        score = int.Parse(tView.GetComponent<TextMeshProUGUI>().text);
       



    }


    // Update is called once per frame
    void Update()
    {
       
    }

    public void MakeSquare() {
        aDeck = FindObjectOfType<Deck>().cardArray;
        aG = FindObjectOfType<Deck>().GetCard();
        AudioSource.PlayClipAtPoint(clickClip, Camera.main.transform.position);


        if (aG == GameObject.Find("2Club"))
        {
            aG.tag = "2";
        }
       
            gameValueInt = Int32.Parse(aG.tag);
        
        aG.AddComponent<Rigidbody2D>();
        aG.AddComponent<BoxCollider2D>();


        aG.transform.position = new Vector3(0f, 1F, 0F);
        aG.transform.localScale = new Vector3(42f, 36f, 10f);
        aG.transform.rotation = Quaternion.Euler(190F, 0F, 0F);
        cardValue.text = "Value is " + aG.tag.ToString();

        b1 = GameObject.FindGameObjectWithTag("swap");
        ib1 = Instantiate(b1) as GameObject;
        GameObject canvas = GameObject.Find("Canvas");
        bf = ib1.GetComponent<Button>();




        ib1.transform.SetParent(canvas.transform);
        ib1.transform.position = new Vector3(-81, -38, 0F);
        ib1.GetComponent<RectTransform>().sizeDelta = new Vector2(112, 30);
        ib1.GetComponent<RectTransform>().localPosition = new Vector3(-82f, -40f, 0f);
        ib1.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        ib1.GetComponent<Image>().color = Color.green;
        ib1.GetComponentInChildren<Text>().fontSize = 40;
        RectTransform rt = ib1.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(250f, 200f);


        bf.GetComponentInChildren<Text>().text = "Continue";
        bf.onClick.AddListener(SwapCard);


        GameObject b2 = GameObject.FindGameObjectWithTag("continue");
        ib2 = Instantiate(b2) as GameObject;
      
        bc = ib2.GetComponent<Button>();


        ib2.transform.SetParent(canvas.transform);
        ib2.GetComponent<RectTransform>().sizeDelta = new Vector2(112, 30);
        ib2.GetComponent<RectTransform>().localPosition = new Vector3(200f, -40f, 0f);
        ib2.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        ib2.GetComponent<Image>().color = Color.yellow;
        ib2.GetComponentInChildren<Text>().fontSize = 40;
        RectTransform ib2Rt = ib2.GetComponent<RectTransform>();
        ib2Rt.sizeDelta = new Vector2(250, 200);
        bc.GetComponentInChildren<Text>().text = "Swap";
        bc.onClick.AddListener(Continue);
        Destroy(b1);
        Destroy(getCard);

    }

    public void SwapCard() {

        cpuCard = FindObjectOfType<CPU>().GetCpu();
         af = Instantiate(cpuCard) as GameObject;
    
       
            cpuValueInt = int.Parse(af.tag);
        

        Debug.Log(cpuValueInt + " " + gameValueInt);
        af.transform.rotation = Quaternion.Euler(0f, 180F, 0F);
        
        if (gameValueInt > cpuValueInt) {
            score++;
            tView.GetComponent<TextMeshProUGUI>().text = "" + score;
            AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);


        }
        else if (gameValueInt < cpuValueInt)
        {
            AudioSource.PlayClipAtPoint(loseClip, Camera.main.transform.position);
        }

        Destroy(b1);

        bc.onClick.RemoveAllListeners();
        bc.GetComponentInChildren<Text>().text = "Play Again?";
        bc.onClick.AddListener(PlayAgain);
        cpuValue.text = "Value is " + af.tag.ToString();
        Destroy(cpuCard);
        Destroy(ib1.gameObject);

       




    }

    public void Continue() {
        cpuCard = FindObjectOfType<CPU>().GetCpu();
        Destroy(aG);
        GameObject swappedCard = FindObjectOfType<Deck>().GetCard();
        Debug.Log("The tag is " + swappedCard.tag);
        Debug.Log("The CPU tag is " + cpuCard.tag);


        cpuValueInt = int.Parse(cpuCard.tag);
        
   
        
            gameValueInt = int.Parse(swappedCard.tag);

        if (gameValueInt > cpuValueInt)
        {
            score++;
            tView.GetComponent<TextMeshProUGUI>().text = "" + score;
            AudioSource.PlayClipAtPoint(winClip, Camera.main.transform.position);


        }
        else if (gameValueInt < cpuValueInt) {
            AudioSource.PlayClipAtPoint(loseClip, Camera.main.transform.position);
        }

        Debug.Log(cpuValueInt + " " + gameValueInt);

        swappedCard.transform.position = new Vector3(0f, -3F, 10F);
        swappedCard.transform.localScale = new Vector3(42f, 36f, 10f);
        swappedCard.transform.rotation = Quaternion.Euler(190F, 0F, 0F);
        cardValue.text = "Value is " + swappedCard.tag.ToString();

        af = Instantiate(cpuCard) as GameObject;
        af.transform.rotation = Quaternion.Euler(0f, 180F, 0F);
        cpuValue.text = "Value is " + af.tag.ToString();
        Destroy(cpuCard);
        Destroy(bf);
        Destroy(ib1.gameObject);
        Destroy(b1);
        bc.onClick.RemoveAllListeners();
        bc.GetComponentInChildren<Text>().text = "Play Again?";
        bc.onClick.AddListener(PlayAgain);



    }



    public void PlayAgain() {
        FindObjectOfType<Gamesession>().ChangeScore();
        Destroy(bf);
        Destroy(ib1);
        Destroy(b1);
        Destroy(bc);
        Destroy(ib2);

    }

    public int GetValue(){
        return gameValueInt;

}

    public int getCPUValue() {
        return cpuValueInt;
    }

    public void getCardClip() {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
    }



    public void QuitGame() {
        Application.Quit();
    }

}

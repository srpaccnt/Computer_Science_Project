using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamesession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int tempInt;
    GameObject anObject;
    int playerCount; 
    int cpuCount;
    public static bool sceneChanged = false;

    // Start is called before the first frame update
    void Start()
    {
        anObject = GameObject.Find("getCard");
        

    }

    private void Awake()
    {
        scoreText.text = tempInt.ToString();


        int gameStatusCount = FindObjectsOfType<Gamesession>().Length;
        if (gameStatusCount > 1&&sceneChanged==false)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            
        }
    }

    public void ResetGame()
    {
       

        int gameStatusCount = FindObjectsOfType<Gamesession>().Length;
       
     
        
            tempInt++;
            scoreText.text = tempInt.ToString();
        
        SceneManager.LoadScene(1);
        

    }

    public void ChangeScore() {
        cpuCount = FindObjectOfType<MySquare>().GetValue();
        playerCount = FindObjectOfType<MySquare>().getCPUValue();
        int gameStatusCount = FindObjectsOfType<Gamesession>().Length;
     
      
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }

    public int getTempInt() {
        return tempInt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

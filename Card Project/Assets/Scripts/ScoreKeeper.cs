using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myscore;
    GameObject myTemp;
    [SerializeField]int scoreCount=0;
    // Start is called before the first frame update
    void Start()
    {
        myscore = FindObjectOfType<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<Gamesession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(transform.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    public void GetScore() {
        scoreCount++;
        SceneManager.LoadScene(1);
        
  
        
    

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSinglePlayer() {
        Gamesession.sceneChanged = false;
        SceneManager.LoadScene("SampleScene");
        SceneManager.UnloadSceneAsync("Main Menu");


    }

    public void LoadMainMenu() {
        GameObject myObject = GameObject.Find("GameSession");
        Destroy(myObject);
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.LoadScene("Main Menu");

    }

    public void LoadMultiPlayer()
    {
        Gamesession.sceneChanged = false;
        SceneManager.LoadScene("MultiPlayer");
        SceneManager.UnloadSceneAsync("Main Menu");


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStage =1;
    public static GameManager Instance;
    void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this); ;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToNextScene()
    {
        Debug.Log(gameStage);
        SceneManager.LoadScene(gameStage);
    }

    public void GoMainScene()
    {
        Debug.Log(gameStage);
        SceneManager.LoadScene(gameStage);
    }
}

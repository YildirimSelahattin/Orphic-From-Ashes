using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStage =1;
    public static GameManager Instance;
    public GameObject[] dialogs;
    public GameObject LastPanel;
    void Awake()
    {

        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this); ;
        }
        if (gameStage == 4)
        {
            LastPanel.SetActive(true);
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

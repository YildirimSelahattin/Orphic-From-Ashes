using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameStage =1;
    public static GameManager Instance;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this); ;
        }

    }

    public void GoToNextScene()
    {
        Debug.Log(gameStage);
        SceneManager.LoadScene(gameStage);
    }

    public void GoMainScene()
    {   
        PlayerPrefs.DeleteAll();
        Debug.Log(gameStage);
        gameStage++;
        SceneManager.LoadScene(0);
    }
}

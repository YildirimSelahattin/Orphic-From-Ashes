using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOpenerMain : MonoBehaviour
{
    public GameObject[] dialogs;
    public GameObject LastPanel;
    public AudioSource AudioSource;
    public AudioClip c;
    
    void Start()
    {
        if(GameManager.Instance.gameStage < 4)
            dialogs[GameManager.Instance.gameStage].SetActive(true);
        else
        {
            LastPanel.SetActive(true);
            AudioSource.PlayOneShot(c);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOpenerMain : MonoBehaviour
{
    public GameObject[] dialogs;
    // Start is called before the first frame update
    void Start()
    {
        dialogs[GameManager.Instance.gameStage].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

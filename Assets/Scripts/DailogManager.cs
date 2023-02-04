using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DailogManager : MonoBehaviour
{
    public TextMeshProUGUI _textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    private void Start()
    {
        _textComponent.text = string.Empty;
        StartDailog();
    }

    void StartDailog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index])
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

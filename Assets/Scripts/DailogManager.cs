using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = lines[index];
            }
        }
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

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}

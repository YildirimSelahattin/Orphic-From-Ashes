using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLensFilter : MonoBehaviour
{
    public float trc = 0f;
    private Image filter;

    void Start()
   {
       filter = gameObject.GetComponent<Image>();
   }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            trc += 0.15f;
            filter.color = new Color(0,0,0,trc);
        }
    }
}

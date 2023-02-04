using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public int fireLevel;
    public float minParticleSize;
    public float maxParticleSize;
    public GameObject[] flameParent;
    public static FireManager Instance;
    float minMaxDistance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        minMaxDistance = (maxParticleSize - minParticleSize);
        ControlStartSize();
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void ChangeFireAmount(float percentage)
    {
        if (percentage>=0.66)
        {
            float difference = percentage - 0.66f;
            foreach (GameObject particle in flameParent)
            {
                var main = particle.GetComponent<ParticleSystem>().main;
                main.startSize = difference * minMaxDistance / 0.33f;
            }
        }
        else if (percentage >= 33)
        {
            //medium fire
            float difference = percentage - 0.66f;
            foreach (GameObject particle in flameParent)
            {
                var main = particle.GetComponent<ParticleSystem>().main;
                main.startSize = difference * minMaxDistance / 0.33f;
            }
        }
        
        else if (percentage >= 0)
        {
            //big fire
            float difference = percentage - 0.66f;
            foreach (GameObject particle in flameParent)
            {
                var main = particle.GetComponent<ParticleSystem>().main;
                main.startSize = difference * minMaxDistance / 0.33f;
            }
        }
    }
    public void ControlStartSize()
    {
        float startFireSize = 0;
        if(GameManager.Instance.gameStage == 1)
        {
            Debug.Log("3");
            startFireSize = 3;
        }
        else if (GameManager.Instance.gameStage ==2)
        {
            startFireSize = 2;
        }
        else if (GameManager.Instance.gameStage == 3)
        {
            startFireSize = 1;
        }

        foreach (GameObject particle in flameParent)
        {
            ParticleSystem instance = particle.GetComponent<ParticleSystem>();
            var main = instance.main;
            main.startSize = startFireSize;
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EyeLidManager : MonoBehaviour
{
    // Start is called before the first frame update 
    [SerializeField] GameObject UpLid;
    [SerializeField] GameObject DownLid;
    [SerializeField] float timeBetweenOpenClose;
    [SerializeField] float closedDuration;
    [SerializeField] GameObject blurred;
    void Start()
    {
        StartCoroutine(EyeOpenMove(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator EyeOpenMove(float waitingTime)
    {
        
        yield return new WaitForSeconds(waitingTime);
        UpLid.GetComponent<Image>().DOFade(0,2f);
        blurred.GetComponent<Image>().DOFade(0, 2.2F).SetEase(Ease.Linear);
        UpLid.transform.DOLocalMoveY(810, 2.2f);
        yield return new WaitForSeconds(0.2f);
        DownLid.GetComponent<Image>().DOFade(0,2f).SetEase(Ease.Linear);
        DownLid.transform.DOLocalMoveY(-810, 2F).OnComplete(() =>
        {
            //StartCoroutine(EyeCloseMove());
        });
    }

   public IEnumerator EyeCloseMove()
    {
        yield return new WaitForSeconds(timeBetweenOpenClose);
        blurred.GetComponent<Image>().DOFade(1, 2.2F);
        UpLid.transform.DOLocalMoveY(270, 2f);
        UpLid.GetComponent<Image>().DOFade(1, 2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        DownLid.GetComponent<Image>().DOFade(1, 2f).SetEase(Ease.Linear);
        DownLid.transform.DOLocalMoveY(-270, 2F).OnComplete(() =>
        {
            StartCoroutine(EyeOpenMove(closedDuration));
        });
    }
}

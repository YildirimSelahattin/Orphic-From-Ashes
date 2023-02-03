using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PhotoMover : MonoBehaviour
{

    [SerializeField] Vector3 aimedPos;
    [SerializeField] Vector3 aimedRot;
    [SerializeField] Transform originalTransform;
    // Start is called before the first frame update
    void Start()
    {
        ShowAllPhotos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAllPhotos()
    {
        transform.DOLocalMove(aimedPos,1f);
        transform.DOLocalRotate(aimedRot,1f);
    }
}

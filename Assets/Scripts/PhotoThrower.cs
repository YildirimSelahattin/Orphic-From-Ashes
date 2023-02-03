using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PhotoThrower : MonoBehaviour
{
    // Start is called before the first frame update
    int currentThrowPhotoIndex = 0;
    [SerializeField] Transform firePlace;
    public static PhotoThrower Instance;
    public  List<GameObject> photosList;
    [SerializeField] float notThrowedPhotoOffsetX = 3;
    [SerializeField] LayerMask touchableLayerOnlyPhotos;
    [SerializeField] float throwDuration;
    [SerializeField] Vector3 throwingPhotoFirstRotation;
    RaycastHit hit;
    Ray ray;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetButtonDown("Fire1"))//if player 
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity,touchableLayerOnlyPhotos)) // if it hit to a machine object
            {
                ThrowPhoto();
            }
        }
    }

    public void ThrowPhoto()
    {
        GameObject PhotoToThrow = photosList[0];
        photosList.Remove(PhotoToThrow);
        
        
        foreach (GameObject photo in photosList)
        {
            photo.transform.DOMoveX(photo.transform.position.z-notThrowedPhotoOffsetX, 0.5f).OnComplete(() =>
            {
                PhotoToThrow.transform.DOLocalRotate(throwingPhotoFirstRotation,0.2f).OnComplete(() =>
                {
                    StartCoroutine(RotatePhoto(PhotoToThrow));
                    MovePhoto(PhotoToThrow);
                    currentThrowPhotoIndex++;
                });
            
            });
        }
    }

    public IEnumerator RotatePhoto(GameObject photoToThrow)
    {
        yield return new WaitForSeconds(throwDuration / 3f);
        photoToThrow.transform.DOShakeRotation(throwDuration*2/3,90,2,90,true).SetEase(Ease.Linear);
    }
    public void MovePhoto( GameObject photoToThrow)
    {
        photoToThrow.transform.DOMove(firePlace.transform.position,throwDuration).SetEase(Ease.Linear);

    }
}

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
    public  GameObject photoParent;
    [SerializeField] float notThrowedPhotoOffsetX = 3;
    [SerializeField] LayerMask touchableLayerOnlyPhotos;
    [SerializeField] float throwDuration;
    [SerializeField] Vector3 throwingPhotoFirstRotation;
    [SerializeField] GameObject[] gameStagePhotoParents;
    RaycastHit hit;
    Ray ray;
    int photosStage = 0;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        photoParent = gameStagePhotoParents[GameManager.Instance.gameStage];
        photoParent.SetActive(true);
        GameManager.Instance.gameStage++;
        //Show only wanted photos
        

    }

    // Update is called once per frame
    void Update()
    {
        if(photosStage < 2)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Input.GetButtonDown("Fire1"))//if player 
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, touchableLayerOnlyPhotos)) // if it hit to a machine object
                {
                    if(photosStage == 0)
                    {
                        SeperatePhotos();
                    }
                    if (photosStage == 1)
                    {
                        ThrowPhoto();
                    }
                    photosStage++;
                }
            }
        }
    
    }

    public void ThrowPhoto()
    {
        GameObject PhotoToThrow = photoParent.transform.GetChild(0).gameObject;
        
        
        
        for(int i= 1; i < photoParent.transform.childCount; i++)
        {
            GameObject photo = photoParent.transform.GetChild(i).gameObject;
            photo.transform.DOMoveX(photo.transform.position.z - notThrowedPhotoOffsetX, 0.5f).OnComplete(() =>
            {
                PhotoToThrow.transform.DOLocalRotate(throwingPhotoFirstRotation, 0.2f).OnComplete(() =>
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
        photoToThrow.transform.DOMove(firePlace.transform.position, throwDuration).OnComplete(() =>
        {
            Debug.Log("as");
            GoToTheNextLevel();
        });

    }

    public void GoToTheNextLevel()
    {

        GameManager.Instance.GoToNextScene();
    }
    
    public void SeperatePhotos()
    {
        
        for (int i = 0; i < photoParent.transform.childCount; i++)
        {
            GameObject photo = photoParent.transform.GetChild(i).gameObject;
            photo.GetComponent<PhotoMover>().ShowAllPhotos();
        }
    }
}

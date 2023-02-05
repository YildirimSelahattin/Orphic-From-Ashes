using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InspectObjectController : MonoBehaviour
{
    public float distance;
    public Transform inspectArea;
    private Vector3 originalPos;
    private bool onInspect = false;
    private GameObject inspected;
    public FirstPersonController _fpsController;
    public CameraLensFilter cameraLensFilterScript;
    public LayerMask InspectLayer;
    public GameObject inspectText;
    public GameObject inspectOutText;
    public Camera cam;
    public GameObject[] dialogBoxes;
    public AudioSource _AudioSource;
    public AudioClip _aaaaaa;
    public int[] photoMaxHintArray = new int[] { 0, 5, 5, 5 };
    public int currentMaxHint;
    public int currentFindedHit=0;
    private Quaternion _itemOriginalPos;
    
    private void Start()
    {
        currentMaxHint = photoMaxHintArray[GameManager.Instance.gameStage];
    }
    public void Update()
    {
        Vector3 _fwd = cam.transform.TransformDirection(
            Vector3.forward);
        RaycastHit _hit;

        if (Physics.Raycast(cam.transform.position, _fwd, out _hit, distance, InspectLayer))
        {
            if (_hit.transform.tag == "InspectObject" && !onInspect)
            {
                inspectText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inspected = _hit.transform.gameObject;
                    originalPos = _hit.transform.position;
                    onInspect = true;

                    string itemName = _hit.transform.name;

                    _itemOriginalPos = _hit.transform.rotation;
                    
                    switch (itemName)
                    {
                        case "cat":
                            dialogBoxes[0].SetActive(true);
                            break;
                        case "tren":
                            dialogBoxes[1].SetActive(true);
                            break;
                        case "mum":
                            break;
                        case "ayi":
                            break;
                        case "mektup":
                            break;
                        case "kartpostal":
                            break;
                        case "takvim0":
                            break;
                        case "takvim1":
                            break;
                        case "takvim2":
                            break;
                        case "telefon":
                            break;
                        case "pasta":
                            break;
                        case "kapi":
                            _AudioSource.PlayOneShot(_aaaaaa);
                            onInspect = false;
                            break;
                    }

                    int temp = PlayerPrefs.GetInt(itemName, 0);
                    if (temp == 0)
                    {
                        //arttır
                        currentFindedHit++;
                        FireManager.Instance.ChangeFireAmount(currentFindedHit/currentMaxHint);
                        cameraLensFilterScript.DarkenScreen();
                        PlayerPrefs.SetInt(itemName, 1);
                    }

                    if (!_hit.transform.name.Equals("kapi"))
                        StartCoroutine(PickupItem());
                }
            }
        }
        else
        {
            inspectText.SetActive(false);
        }

        if (onInspect)
        {
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, inspectArea.position, 0.2f);
            inspectArea.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) *
                               Time.deltaTime * 125f);
        }
        else if (inspected != null)
        {
            inspected.transform.SetParent(null);
            inspected.transform.position = Vector3.Lerp(inspected.transform.position, originalPos, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && onInspect)
        {
            StartCoroutine(DropItem());
            onInspect = false;
        }

        IEnumerator PickupItem()
        {
            _fpsController.enabled = false;
            yield return new WaitForSeconds(0.2f);
            inspected.transform.SetParent(inspectArea);
            inspectText.SetActive(false);
            inspectOutText.SetActive(true);
        }

        IEnumerator DropItem()
        {
            inspected.transform.rotation = _itemOriginalPos;
            yield return new WaitForSeconds(0.2f);
            _fpsController.enabled = true;
            inspectOutText.SetActive(false);
        }
    }
}
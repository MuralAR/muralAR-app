using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCardsTweenManager : MonoBehaviour
{
    public LeanTweenType easeTypeText, easeTypeLogo, easeTypeBackdrop, easeTypeBanner, easeTypeButton;
    public GameObject titleScreenRef, bannerRef, backdropRef, mapRef, arRef, mapTextRef, arTextRef;
    public GameObject mapButton, arButton;
    public string sceneNameToOpen;

    void Start()
    {
        LeanTween.moveX(backdropRef.GetComponent<RectTransform>(), -100, 5).setEase(easeTypeBackdrop);
        LeanTween.scale(backdropRef, new Vector3(1.2f, 1.2f, 1.2f), 55).setEase(easeTypeBackdrop);
    }

    public void moveToMapTitleCard()
    {
        LeanTween.cancelAll();
        LeanTween.moveX(titleScreenRef, -3000, 1).setEase(easeTypeBackdrop);
        LeanTween.moveX(bannerRef.GetComponent<RectTransform>(), 0, 1).setEase(easeTypeBackdrop);
        LeanTween.moveX(backdropRef.GetComponent<RectTransform>(), -2800, 1.5f).setEase(easeTypeBackdrop);//.setOnComplete(slowMoveMapTitleCard);
        LeanTween.alpha(backdropRef.GetComponent<RectTransform>(), 0f, 1f).setOnComplete(popUpMapText);
        LeanTween.scale(mapRef, new Vector3(1.2f, 1.2f, 1.2f), 55).setEase(easeTypeBackdrop);
    }

    public void moveToARTitleCard()
    {
        LeanTween.cancelAll();
        LeanTween.scale(mapTextRef, new Vector3(0, 0, 0), 0.5f).setEase(easeTypeBackdrop);
        LeanTween.moveX(bannerRef.GetComponent<RectTransform>(), -2183, 1).setEase(easeTypeBackdrop);
        LeanTween.moveX(mapRef.GetComponent<RectTransform>(), -2800, 1.5f).setEase(easeTypeBackdrop);//.setOnComplete(slowMoveMapTitleCard);
        LeanTween.alpha(mapRef.GetComponent<RectTransform>(), 0f, 1f).setOnComplete(popUpARText);
        LeanTween.scale(arRef, new Vector3(1.2f, 1.2f, 1.2f), 55).setEase(easeTypeBackdrop);
    }

    public void slowMoveARTitleCard()
    {
        LeanTween.scale(mapRef, new Vector3(1.2f, 1.2f, 1.2f), 55).setEase(easeTypeBackdrop);
        //LeanTween.moveX(gameObject, -541.73f, 60).setEase(easeTypeBackdrop);
    }

    public void popUpMapText()
    {
        LeanTween.scale(mapTextRef, new Vector3(1, 1, 1), 0.5f).setEase(easeTypeBackdrop);
        mapButton.GetComponent<ButtonTweenLogic>().Start();
    }

    public void popUpARText()
    {
        LeanTween.scale(arTextRef, new Vector3(1, 1, 1), 0.5f).setEase(easeTypeBackdrop);
        arButton.GetComponent<ButtonTweenLogic>().Start();

    }

    public void openMainLevel()
    {
        SceneManager.LoadScene(sceneNameToOpen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

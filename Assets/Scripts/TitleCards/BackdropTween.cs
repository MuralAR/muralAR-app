using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackdropTween : MonoBehaviour
{
    public LeanTweenType easeType;
    public GameObject titleScreenRef;
    public GameObject bannerRef;
    public string sceneNameToOpen;

    void Start()
    {
        LeanTween.moveX(gameObject, 2341.73f, 60).setEase(easeType);
    }

    public void moveToMapTitleCard()
    {
        LeanTween.cancelAll();
        LeanTween.moveX(titleScreenRef, -3000, 1).setEase(easeType);
        LeanTween.moveX(bannerRef, 450, 1).setEase(easeType);
        LeanTween.moveX(gameObject, 200, 1.5f).setEase(easeType).setOnComplete(slowMoveMapTitleCard);
    }

    public void slowMoveMapTitleCard()
    {
        LeanTween.moveX(gameObject, -541.73f, 60).setEase(easeType);
    }

    public void moveToARTitleCard()
    {
        LeanTween.pauseAll();
        LeanTween.cancelAll();
        LeanTween.moveX(bannerRef, -1650, 1).setEase(easeType);
        LeanTween.moveX(gameObject, -1700, 1.5f).setEase(easeType).setOnComplete(slowMoveARTitleCard);
    }

    public void slowMoveARTitleCard()
    {
        LeanTween.moveX(gameObject, -2200, 10).setEase(easeType);
    }

    public void openScene()
    {
        SceneManager.LoadScene(sceneNameToOpen);
    }


    void Update()
    {
        
    }
}

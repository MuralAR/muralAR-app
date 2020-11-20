using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ARUIManager : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject mapImage;
    public GameObject magicIcon;
    public GameObject reasonBox;
    public GameObject distanceBox;

    public string reasonBoxText;
    private TMP_Text reasonBoxTMP;
    private TMP_Text locationBoxTMP;
    public GameObject moreInfoButton;
    public GameObject moreInfoBox;

    public bool videoPlayerState;
    private Dictionary<string, string> muralLocations = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        reasonBoxTMP = reasonBox.GetComponentInChildren<TMP_Text>();
        reasonBoxTMP.text = reasonBoxText;
        locationBoxTMP = distanceBox.GetComponentInChildren<TMP_Text>();
        ToggleVideoPlayer(true);
        SetMuralDistance();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleVideoPlayer(bool turnOn)
    {
        videoPlayerState = turnOn;
        if (videoPlayerState)
        {
            videoPlayer.SetActive(true);
            reasonBox.SetActive(true);
            moreInfoButton.SetActive(false);
            moreInfoBox.SetActive(false);
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
            distanceBox.SetActive(false);
        }
        else
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            moreInfoBox.SetActive(false);
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
            distanceBox.SetActive(false);
        }
    }

    public void OpenMap()
    {
        {
            mapImage.SetActive(true);
            magicIcon.SetActive(true);
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(false);
            moreInfoBox.SetActive(false);
            distanceBox.SetActive(false);
        }
    }

    public void CloseMap()
    {
        {
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            moreInfoBox.SetActive(false);
            distanceBox.SetActive(false);
        }
    }

    public void ToggleMoreInfo(bool turnOn)
    {
        if (turnOn)
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(false);
            moreInfoBox.SetActive(true);
        }
        else
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            moreInfoBox.SetActive(false);
        }
    }

    private void SetMuralDistance()
    {
        muralLocations.Add("icon1","Mural 1. You are 206 meters away");
        muralLocations.Add("icon2","Mural 2. You are 505 meters away");
        muralLocations.Add("icon3","Mural 3. You are 648 meters away");
    }
    
    private void CalculateDistance(string icon)
    {
        string distance =  muralLocations[icon];
        locationBoxTMP.text = distance;
    }
    
    public void OnClickedIcon(){ 
        string thisPosition = EventSystem.current.currentSelectedGameObject.name;
        CalculateDistance(thisPosition);
        distanceBox.SetActive(true);
    }
}
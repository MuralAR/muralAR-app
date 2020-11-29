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
    public GameObject infoBox;

    public string reasonBoxText;
    private TMP_Text reasonBoxTMP;
    private TMP_Text locationBoxTMP;
    private TMP_Text locationMoreInfoBoxTMP;

    public GameObject moreInfoButton;
    public GameObject moreInfoBox;

    public bool videoPlayerState;
    private Dictionary<string, string> muralLocations = new Dictionary<string, string>();

    private Dictionary<string, string> muralInfo = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        reasonBoxTMP = reasonBox.GetComponentInChildren<TMP_Text>();
        reasonBoxTMP.text = reasonBoxText;
        locationBoxTMP = distanceBox.GetComponentInChildren<TMP_Text>();
        locationMoreInfoBoxTMP = infoBox.GetComponentInChildren<TMP_Text>();
        ToggleVideoPlayer(true);
        SetMuralDistance();
        SetMuralInfo();
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
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 0f, 0.3f);
            moreInfoBox.SetActive(false);
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
            distanceBox.SetActive(false);
            infoBox.SetActive(false);
        }
        else
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 1f, 0.6f);
            moreInfoBox.SetActive(false);
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
            distanceBox.SetActive(false);
            infoBox.SetActive(false);
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
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 0f, 0.3f);
            moreInfoBox.SetActive(false);
            distanceBox.SetActive(false);
            infoBox.SetActive(false);
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
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 1f, 0.6f);
            moreInfoBox.SetActive(false);
            distanceBox.SetActive(false);
            infoBox.SetActive(false);
        }
    }

    public void ToggleMoreInfo(bool turnOn)
    {
        if (turnOn)
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(false);
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 0f, 0.3f);
            moreInfoBox.SetActive(true);
            LeanTween.alpha(moreInfoBox.GetComponent<RectTransform>(), 1f, 0.6f);
            LeanTween.scale(moreInfoBox, new Vector3(0.85f, 0.85f, 0.85f), 0.5f);
            LeanTween.moveY(moreInfoBox.GetComponent<RectTransform>(), 0, 0.5f);
        }
        else
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            LeanTween.alpha(moreInfoButton.GetComponent<RectTransform>(), 1f, 0.6f);
            //moreInfoBox.SetActive(false);
            LeanTween.alpha(moreInfoBox.GetComponent<RectTransform>(), 0f, 0.4f);
            LeanTween.scale(moreInfoBox, new Vector3(0, 0, 0), 0.3f);
            LeanTween.moveY(moreInfoBox.GetComponent<RectTransform>(), -700, 0.3f);
        }
    }
    
    private void CalculateDistance(string icon)
    {
        string distance = muralLocations[icon];
        locationBoxTMP.text = distance;
    }

    public void OnClickedIcon()
    {
        if (infoBox.activeSelf)
        {
            return;
        }

        string thisPosition = EventSystem.current.currentSelectedGameObject.name;
        distanceBox.GetComponent<Button>().onClick.AddListener(delegate { OnClickedMoreInfoMap(thisPosition); });
        CalculateDistance(thisPosition);
        distanceBox.SetActive(true);
        StartCoroutine(DistanceDelay());
    }

    IEnumerator DistanceDelay()
    {
        yield return new WaitForSeconds(2f);
        distanceBox.SetActive(false);
    }

    public void OnClickedMap()
    {
        distanceBox.SetActive(false);
        infoBox.SetActive(false);
    }

    private void OnClickedMoreInfoMap(String icon)
    {
        infoBox.SetActive(true);
        distanceBox.SetActive(false);
        locationMoreInfoBoxTMP.text = muralInfo[icon];
    }
    
    private void SetMuralDistance()
    {
        muralLocations.Add("icon1", "Mural 1. You are 206 meters away");
        muralLocations.Add("icon2", "Mural 2. You are 505 meters away");
        muralLocations.Add("icon3", "Mural 3. You are 648 meters away");
    }

    private void SetMuralInfo()
    {
        muralInfo.Add("icon1",
            "ARTIST - achesdub \nThe Last King of Ireland  \nHailing from Dublin, Aches has been creating work since the age of fifteen. Boasting an impressive repertoire of work, he has been invited to design and create original artwork for projects in countries such as Denmark, Ireland, Hungary, Spain, Sweden, Miami, Scotland, Austria, Switzerland, England and USA.");
        muralInfo.Add("icon2",
            "ARTIST - achesdub \nThe Last King of Ireland  \nHailing from Dublin, Aches has been creating work since the age of fifteen. Boasting an impressive repertoire of work, he has been invited to design and create original artwork for projects in countries such as Denmark, Ireland, Hungary, Spain, Sweden, Miami, Scotland, Austria, Switzerland, England and USA.");
        muralInfo.Add("icon3",
            "ARTIST - achesdub \nThe Last King of Ireland  \nHailing from Dublin, Aches has been creating work since the age of fifteen. Boasting an impressive repertoire of work, he has been invited to design and create original artwork for projects in countries such as Denmark, Ireland, Hungary, Spain, Sweden, Miami, Scotland, Austria, Switzerland, England and USA.");
    }

}
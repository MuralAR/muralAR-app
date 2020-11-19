using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class ARUIManager : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject mapImage;
    public GameObject magicIcon;
    public GameObject reasonBox;

    public string reasonBoxText;
    private TMP_Text reasonBoxTMP;


    public GameObject moreInfoButton;
    public GameObject moreInfoBox;

    public bool videoPlayerState;
    // Start is called before the first frame update
    void Start()
    {
        reasonBoxTMP = reasonBox.GetComponentInChildren<TMP_Text>();
        reasonBoxTMP.text = reasonBoxText;
        ToggleVideoPlayer(true);
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
        }
        else
        {
            videoPlayer.SetActive(false);
            reasonBox.SetActive(false);
            moreInfoButton.SetActive(true);
            moreInfoBox.SetActive(false);
            mapImage.SetActive(false);
            magicIcon.SetActive(false);
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
}
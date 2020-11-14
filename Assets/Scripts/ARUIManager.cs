using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class ARUIManager : MonoBehaviour
{
    public Color offColor, onColor;
    public GameObject videoPlayer;
    private VideoPlayer mVideoPlayer;
    private RawImage mRawImage;

    public bool turnOn = false;
    private bool oldVal = true;
    // Start is called before the first frame update
    void Start()
    {
        mVideoPlayer = videoPlayer.GetComponent<VideoPlayer>();
        mRawImage = videoPlayer.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(turnOn != oldVal) {
            oldVal = turnOn;
            ToggleVideoPlayer(turnOn);
        }
    }

    void ToggleVideoPlayer(bool turnOn)
    {
        if (turnOn)
        {
            mRawImage.color = offColor;
            mVideoPlayer.Play();
        }
        else
        {
            mRawImage.color = onColor;
            mVideoPlayer.Stop();
        }
    }
}

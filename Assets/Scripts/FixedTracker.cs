using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;

/**
* x = 10.5916
* y = 12.6483
*/





[RequireComponent(typeof(ARTrackedImageManager))]
public class FixedTracker : MonoBehaviour
{

    // public TMP_Text debugText;

    // Start is called before the first frame update
    public GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;
    public ARUIManager aRUIManager;
    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        foreach (GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.SetActive(false);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }
    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // debugText.text = "";
        TrackingState totalTrackingState = TrackingState.None;
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // debugText.text += "A-" + trackedImage.referenceImage.name + " : " + trackedImage.trackingState;
            UpdateImage(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // debugText.text += "U-" + trackedImage.referenceImage.name + " : " + trackedImage.trackingState + ", ";
            if (trackedImage.trackingState != TrackingState.None)
            {
                totalTrackingState = TrackingState.Tracking;
                UpdateImage(trackedImage);
            }
            else
            {
                RemoveImage(trackedImage);
            }
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            // debugText.text += "R-" + trackedImage.referenceImage.name + " : " + trackedImage.trackingState + ", ";
            RemoveImage(trackedImage);
        }

        if (totalTrackingState == TrackingState.Tracking) // At least 1 image tracking
        {
            if (aRUIManager.videoPlayerState) // if the vidPlayer is on, turn it off
            {
                aRUIManager.ToggleVideoPlayer(false);
            }
        }
        else // No image is tracking 
        {
            if (!aRUIManager.videoPlayerState) // if the vidPlayer is off, turn it on
            {
                aRUIManager.ToggleVideoPlayer(true);
            }
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;
        Quaternion rotation = trackedImage.transform.localRotation;

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;
        prefab.transform.rotation = rotation;
        prefab.SetActive(true);

        foreach (GameObject go in spawnedPrefabs.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false);
            }
        }
    }

    private void RemoveImage(ARTrackedImage trackedImage)
    {
        spawnedPrefabs[trackedImage.referenceImage.name].SetActive(false);
    }
}

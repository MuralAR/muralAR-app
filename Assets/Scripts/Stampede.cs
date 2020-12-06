using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stampede : MonoBehaviour
{
    public GameObject horse;
    public float startDelay, speedMin, speedMax;
    public int numberOfHorsesPerGroup, numberOfGroups;
    public bool loopStampede;
    public Vector3 stampedeDirection;

    public Vector3 minPos, maxPos;


    public Vector3 minViewable, maxViewable;

    public float elapsedTime, maxDistance;

    private List<List<GameObject>> horseGroups;

    private bool stampedeStarted = false;

    private List<GameObject> toDelete;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0;
        horseGroups = new List<List<GameObject>>();
        toDelete = new List<GameObject>();
        // prepopulate horseGroups
        for (int i = 0; i < numberOfGroups; i++)
        {
            List<GameObject> group = new List<GameObject>();
            //init group
            for (int j = 0; j < numberOfHorsesPerGroup; j++)
            {
                //init horse
                Vector3 pos = Vector3.zero;
                pos.Random(minPos, maxPos);
                pos += this.transform.position;
                GameObject newHorse = Instantiate(horse, pos, Quaternion.Euler(new Vector3(90, 0, 0)), this.transform);
                newHorse.SetActive(true);
                newHorse.GetComponent<Horse>().speed = Random.Range(speedMin, speedMax);
                group.Add(newHorse);
            }
            horseGroups.Add(group);
        }
        maxDistance = Vector3.Distance(transform.position, maxViewable);
    }

    // Update is called once per frame
    void Update()
    {
        AttemptStartOfStampede();
        UpdateTransparencies();
    }

    private void AttemptStartOfStampede()
    {
        if (!stampedeStarted)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > startDelay)
            {
                stampedeStarted = true;
                if (horseGroups.Count > 0)
                {
                    // start the stampede
                    foreach (List<GameObject> group in horseGroups)
                    {
                        foreach (GameObject horse in group)
                        {
                            horse.GetComponent<Horse>().isRunning = true;
                        }
                    }
                }
            }
        }
    }

    private void UpdateTransparencies()
    {
        if (stampedeStarted)
        {
            foreach (List<GameObject> group in horseGroups)
            {
                foreach (GameObject horse in group)
                {
                    float distance = Vector3.Distance(this.transform.position, horse.transform.position);
                    float alpha = distance / maxDistance;
                    if (alpha > 1)
                    {
                        if (loopStampede)
                        {
                            Vector3 pos = Vector3.zero;
                            pos.Random(minPos, maxPos);
                            pos += this.transform.position;
                            horse.transform.position = pos;
                        }
                        else
                        {
                            horse.SetActive(false);
                            horse.GetComponent<Horse>().isRunning = false;
                        }
                    }
                    else
                    {
                        Color c = horse.GetComponent<MeshRenderer>().material.color;
                        c.a = Mathf.Clamp(1 - alpha, 0, 1);
                        horse.GetComponent<MeshRenderer>().material.color = c;
                    }
                }
            }
        }
    }


}

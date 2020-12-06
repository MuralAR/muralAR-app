using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public bool isRunning = false;

    public float speed;

    private bool alreadyRunning = false;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            if (!alreadyRunning)
            {
                animator.SetBool("isRunning", true);
                alreadyRunning = true;
            }
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
        }
    }
}

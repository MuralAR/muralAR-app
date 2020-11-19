using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoTweening : MonoBehaviour
{
    public LeanTweenType easeType;
    public float scaleInto = 1;
    public float duration = 1;

    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(scaleInto, scaleInto, scaleInto), duration).setEase(easeType);
    }

}

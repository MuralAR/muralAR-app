using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTweenLogic : MonoBehaviour
{
    public GameObject swirl,swirl2, circle;

    // Start is called before the first frame update
    public void Start()
    {
        RotateSwirl();
        ScaleDownSwirl2();
        FadeOutCircle();
        FadeOutSwirl();
    }

    void RotateSwirl()
    {
        LeanTween.rotate(swirl.GetComponent<RectTransform>(), 350.0f, 2.0f).setEase(LeanTweenType.linear).setOnComplete(RotateSwirl);
    }
    void ScaleDownSwirl2()
    {
        LeanTween.scale(swirl2.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale * 0.05f, 1.0f).setEase(LeanTweenType.linear).setOnComplete(ScaleUpSwirl2);
    }
    void ScaleUpSwirl2()
    {
        LeanTween.scale(swirl2.GetComponent<RectTransform>(), gameObject.GetComponent<RectTransform>().localScale * 0.14f, 1.0f).setEase(LeanTweenType.linear).setOnComplete(ScaleDownSwirl2);
    }

    void FadeInCircle()
    {
        LeanTween.alpha(circle.GetComponent<RectTransform>(), 0.3f, 0.3f).setEase(LeanTweenType.linear).setOnComplete(FadeOutCircle);
    }

    void FadeOutCircle()
    {
        LeanTween.alpha(circle.GetComponent<RectTransform>(), 0.0f, 0.3f).setEase(LeanTweenType.linear).setOnComplete(FadeInCircle);
    }

    void FadeInSwirl()
    {
        LeanTween.alpha(swirl.GetComponent<RectTransform>(), 0.8f, 0.3f).setEase(LeanTweenType.linear).setOnComplete(FadeOutSwirl);
    }

    void FadeOutSwirl()
    {
        LeanTween.alpha(swirl.GetComponent<RectTransform>(), 0.4f, 0.6f).setEase(LeanTweenType.linear).setOnComplete(FadeInSwirl);
    }

    public void onPressed()
    {
        Destroy(gameObject);
        //LeanTween.cancelAll();
        //LeanTween.scale(circle.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        //LeanTween.alpha(circle.GetComponent<RectTransform>(), 0.0f, 0.4f).setEase(LeanTweenType.linear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

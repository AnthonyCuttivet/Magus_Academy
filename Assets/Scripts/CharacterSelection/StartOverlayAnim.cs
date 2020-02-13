using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StartOverlayAnim : MonoBehaviour
{

    Transform leftVBG;
    Transform rightVBG;
    Transform text;
    Transform goldenBG;

    public Camera m_camera;

    [Space]
    [Header("Anim Vars")]
    public float alphaValue;
    public float fadeDuration;
    public float moveDuration;
    public float shakeDuration;
    public float shakeStrength = 3;
    public int shakeVibrato = 10;
    public float shakeRandomness = 90;
    public float textFadeDuration = 1f;



    // Start is called before the first frame update
    void Start(){
        leftVBG = gameObject.transform.Find("LeftVBG");
        rightVBG = gameObject.transform.Find("RightVBG");
        text = gameObject.transform.Find("Text");
        goldenBG = gameObject.transform.Find("GoldenBg");

        StartOverlayAnimation();
        
    }

    public void StartOverlayAnimation(){
        Sequence s = DOTween.Sequence();
        s

            .Join(leftVBG.GetComponent<SpriteRenderer>().DOFade(alphaValue, fadeDuration))
            .Join(leftVBG.DOLocalMoveY(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Join(rightVBG.GetComponent<SpriteRenderer>().DOFade(alphaValue, fadeDuration))
            .Join(rightVBG.DOLocalMoveY(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Join(goldenBG.DOMoveX(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Append(text.GetComponent<SpriteRenderer>().DOFade(1,fadeDuration*10).SetLoops(int.MaxValue,LoopType.Yoyo));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

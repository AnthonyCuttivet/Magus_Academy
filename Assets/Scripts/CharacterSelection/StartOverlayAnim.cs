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

    Sequence s;

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

    [Space]
    [Header("Original Pos")]

    public Vector3 OP_LeftVBG;
    public Vector3 OP_RightVBG;
    public Vector3 OP_Text;
    public Vector3 OP_GoldenBG;

    void OnEnable(){
        s = DOTween.Sequence();
        leftVBG = gameObject.transform.Find("LeftVBG");
        rightVBG = gameObject.transform.Find("RightVBG");
        text = gameObject.transform.Find("Text");
        goldenBG = gameObject.transform.Find("GoldenBg");

        OP_LeftVBG = leftVBG.transform.position;
        OP_RightVBG = rightVBG.transform.position;
        OP_Text = text.transform.position;
        OP_GoldenBG = goldenBG.transform.position;

        PlayOverlayAnimation();
    }

    public void PlayOverlayAnimation(){
        SoundManager.instance.PlaySound("PressStart");
        s
            .Join(leftVBG.GetComponent<SpriteRenderer>().DOFade(alphaValue, fadeDuration))
            .Join(leftVBG.DOLocalMoveY(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Join(rightVBG.GetComponent<SpriteRenderer>().DOFade(alphaValue, fadeDuration))
            .Join(rightVBG.DOLocalMoveY(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Join(goldenBG.DOMoveX(0, moveDuration))
            .Append(m_camera.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness))

            .Append(text.GetComponent<SpriteRenderer>().DOFade(1,textFadeDuration).SetLoops(int.MaxValue,LoopType.Yoyo));

    }

    public void Back(){
        s.Kill();
        SetOriginalPos();
        gameObject.SetActive(false);
    }

    public void SetOriginalPos(){
        leftVBG.transform.position = OP_LeftVBG;
        leftVBG.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        rightVBG.transform.position = OP_RightVBG;
        rightVBG.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        text.transform.position = OP_Text;
        text.GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        goldenBG.transform.position = OP_GoldenBG;
    }

    // Update is called once per frame
    void Update(){

    }
}

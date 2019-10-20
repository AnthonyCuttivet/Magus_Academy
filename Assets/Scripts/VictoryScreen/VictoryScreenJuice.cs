using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VictoryScreenJuice : MonoBehaviour
{

    public GameObject characterArt;
    public GameObject dialogueBox;

    public float duration = 1.5f;

    private Vector3 characterPosition;
    private Vector3 dialogueBoxPosition;

    // Start is called before the first frame update
    void Start(){    
        PlayCharacterAnimation();
    }

    public void SetObjects(){
        characterPosition = characterArt.transform.position;
        dialogueBoxPosition = dialogueBox.transform.position;
        characterArt.transform.position = new Vector3(characterArt.transform.position.x - 1500, characterArt.transform.position.y, characterArt.transform.position.z);
        characterArt.transform.position = new Vector3(characterArt.transform.position.x + 1500, characterArt.transform.position.y, characterArt.transform.position.z);
    }

    public void PlayCharacterAnimation(){
        Sequence characterSequence = DOTween.Sequence();
        characterSequence.Append(characterArt.transform.DOMoveX((-459f + gameObject.transform.position.x), duration, true)).SetEase(Ease.InOutBack);
        characterSequence.Join(dialogueBox.transform.DOMoveX((354f + gameObject.transform.position.x), duration*2, true)).SetEase(Ease.InOutBack);
    }
}

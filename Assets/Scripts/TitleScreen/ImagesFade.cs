using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class ImagesFade : MonoBehaviour
{

    public GameObject floatingImages;
    public List<int> imagesIDs = new List<int>();
    public Dictionary<int,int> randomizedDic = new Dictionary<int, int>();
    public SpriteRenderer currentImage;
    public bool animStarted = false;
    public Vector3 baseImagePos;
    public int currentImageID = 0;


    [Space]
    [Header("Animation Vars")]
    public float fadeInDuration;
    public float fadeOutDuration;
    public float moveOffset;
    public float moveDuration;

    // Start is called before the first frame update
    void Start(){
        baseImagePos = floatingImages.transform.GetChild(0).position;
        for (int i = 0; i < floatingImages.transform.childCount; i++){
            imagesIDs.Add(i);
        }

        int id = 0;
        List<int> randomizedImages = Shuffle(imagesIDs);
        foreach(int i in randomizedImages){
            randomizedDic.Add(id,i);
            id++;
        }
    }

    // Update is called once per frame
    void Update(){
        if(animStarted == false){
            LoadNextImage();
            animStarted = true;
        }
    }

    public IEnumerator FadeOutImage(){
        yield return new WaitForSeconds(moveDuration - fadeOutDuration);
        Sequence s2 = DOTween.Sequence();
        s2.Join(currentImage.DOFade(0, fadeOutDuration)).
            AppendCallback(() => {
                currentImage.transform.position = baseImagePos;
                currentImageID++;
                LoadNextImage();
            });
        
    }

    public void LoadNextImage(){
        if(currentImageID == 8){currentImageID = 0;}
        currentImage = floatingImages.transform.GetChild(randomizedDic[currentImageID]).GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOutImage());
        Sequence s = DOTween.Sequence();
        s.
            Join(currentImage.DOFade(1, fadeInDuration)).
            Join(currentImage.transform.DOMoveX(currentImage.transform.position.x + moveOffset, moveDuration));
    }

    public List<int> Shuffle(List<int> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
        return ts;
    }
}

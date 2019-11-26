using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugIcons : MonoBehaviour
{

    public List<Sprite> icons = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDebugIcon(int player, int skin){
        gameObject.transform.GetChild(player).gameObject.GetComponent<SpriteRenderer>().sprite = icons[skin];
    }
}

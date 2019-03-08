using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Switch : MonoBehaviour {

    //public GameObject block;

    private Star star;
    public GameObject whiteBox;
    private PlayableDirector BridgeplayableDirector;
    private PlayableDirector SwitchDirector;

    private bool flg;
    

    // Use this for initialization
    void Start()
    {
        flg = false;
        star = GameObject.Find("StarPlayer").GetComponent<Star>();
        //whiteBox = GameObject.Find("whiteBox");
        //BridgeplayableDirector = GameObject.Find("whiteBox").GetComponent<PlayableDirector>();
        SwitchDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && flg == false && star.gamemode == 0)
        {
           
            flg = true;
            whiteBox.SetActive(true);
            SwitchDirector.Play();
            //BridgeplayableDirector.Play();

        }
    }
}

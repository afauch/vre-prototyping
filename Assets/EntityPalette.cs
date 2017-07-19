using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPalette : MonoBehaviour {

    public GameObject _page1;
    public GameObject _page2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowPage1()
    {
        _page2.SetActive(false);
        _page1.SetActive(true);
    }

    public void ShowPage2()
    {
        _page1.SetActive(false);
        _page2.SetActive(true);
    }

}

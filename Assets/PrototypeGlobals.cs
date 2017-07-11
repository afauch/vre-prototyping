using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeGlobals : MonoBehaviour {

    public static PrototypeGlobals _instance;

    public GameObject _originPlaceholder;

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

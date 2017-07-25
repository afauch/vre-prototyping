using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRootTransform : MonoBehaviour {

    public Transform _rootTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.position = _rootTransform.position;
        this.gameObject.transform.rotation = _rootTransform.rotation;

	}
}

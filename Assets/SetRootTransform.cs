using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRootTransform : MonoBehaviour {

    public GameObject _headObject;
    public float _YOffset;
    public float _forwardOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Update body rotation
        Transform _thisRotation = this.gameObject.transform;

        Vector3 _newRotation = new Vector3(
            0.0f,
            _headObject.transform.rotation.eulerAngles.y,
            0.0f
            );

        _thisRotation.eulerAngles = _newRotation;


        // Update body position
        this.gameObject.transform.position =
            new Vector3 (_headObject.gameObject.transform.position.x, _YOffset, _headObject.gameObject.transform.position.z) + 
            (this.gameObject.transform.forward * _forwardOffset);


    }
}

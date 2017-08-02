using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OpacityCollider : MonoBehaviour {

    public Collider _senseCollider = null;
    public VRE_Panel _parentPanel = null;

	// Use this for initialization
	void Start () {

        _senseCollider = GetComponent<Collider>();
        _parentPanel = GetComponentInParent<VRE_Panel>();

	}
	
	// Update is called once per frame
	void Update () {

		
	}

    private void OnTriggerEnter(Collider other)
    {

        // Debug.Log("Trigger enter:" + other.gameObject.name);
        _parentPanel.SetOpacity(0.2f);

    }

    private void OnTriggerExit(Collider other)
    {

        // Debug.Log("Trigger exit:" + other.gameObject.name);
        _parentPanel.SetOpacity(1.0f);

    }

}

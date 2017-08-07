using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_Pointer_Grab : MonoBehaviour {

    public VRTK_ControllerEvents _vrtkControllerEvents;
    public VRE_Pointer _vrePointer = null;

    private FixedJoint _currentJoint = null;

    // Use this for initialization
    void Start () {

        if(_vrePointer == null)
        {
            _vrePointer = this.gameObject.GetComponent<VRE_Pointer>();
        }

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);
        _vrtkControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {

        //
        if(_vrePointer._selection != null)
        {

            Grab();            

        }

    }

    void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log(_vrePointer._selection.name);
        if (_vrePointer._selection != null)
        {

            UnGrab();

        }

    }

    void Grab ()
    {

        // Parent the cursor to the hand
        _vrePointer._cursor.transform.SetParent(_vrtkControllerEvents.gameObject.transform);

        // Make the object non-kinematic
        _vrePointer._selection.GetComponent<Rigidbody>().isKinematic = false;

        _vrePointer._selection.transform.SetParent(_vrePointer._cursor.transform);

    }

    void UnGrab()
    {

        // Make the object non-kinematic
        _vrePointer._selection.GetComponent<Rigidbody>().isKinematic = true;
        _vrePointer._selection.transform.SetParent(VRE_Globals._instance._worldParent);
        _vrePointer._cursor.transform.SetParent(VRE_Globals._instance._worldParent);


    }


}

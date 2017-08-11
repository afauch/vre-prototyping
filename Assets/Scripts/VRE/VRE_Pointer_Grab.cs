using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_Pointer_Grab : MonoBehaviour {

    public VRTK_ControllerEvents _vrtkControllerEvents;
    public VRE_Pointer _vrePointer = null;

    public delegate void GrabDelegate();
    public event GrabDelegate _onGrab;
    public event GrabDelegate _onUngrab;

    private FixedJoint _currentJoint = null;
    public bool _showLaserOnTrigger = true;

    public bool _isGrabbing = false;

    // Use this for initialization
    void Start () {

        if(_vrePointer == null)
        {
            _vrePointer = this.gameObject.GetComponent<VRE_Pointer>();
        }

        // Make sure we're subscribed to the right events
        VRE_Globals._instance._onSetupChange += SubscribeEvents;
        SubscribeEvents();

    }

    // Assign Event Subscriptions
    private void SubscribeEvents()
    {

        Debug.Log("SubscribeEvents for VRE_Pointer_Grab called");

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();

        if (VRE_Globals._instance._isOculus) // Touch Handling
        {
            _vrtkControllerEvents.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerClicked);
            _vrtkControllerEvents.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerUnclicked);
        } else
        {
            _vrtkControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);
            _vrtkControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {



        //
        if(_vrePointer._selection != null)
        {

            if (_showLaserOnTrigger)
                _vrePointer._showLine = true;

            Grab();            

        }

    }

    void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {

        if (_vrePointer._selection != null)
        {

            if (_showLaserOnTrigger)
                _vrePointer._showLine = false;

            UnGrab();

        }

    }

    public void Grab ()
    {

        // Parent the cursor to the hand
        _vrePointer._cursor.transform.SetParent(_vrtkControllerEvents.gameObject.transform);

        // Make the object non-kinematic
        _vrePointer._selection.GetComponent<Rigidbody>().isKinematic = false;

        _vrePointer._selection.transform.SetParent(_vrePointer._cursor.transform);

        // Set the state
        _isGrabbing = true;

        // Delegate events
        if(_onGrab != null)
        {
            _onGrab();
        }

    }

    public void UnGrab()
    {

        // Make the object non-kinematic
        _vrePointer._selection.GetComponent<Rigidbody>().isKinematic = true;
        _vrePointer._selection.transform.SetParent(VRE_Globals._instance._worldParent);
        _vrePointer._cursor.transform.SetParent(VRE_Globals._instance._worldParent);

        // Set the state
        _isGrabbing = false;

        // Delegate events
        if (_onUngrab != null)
        {
            _onUngrab();
        }

    }


}

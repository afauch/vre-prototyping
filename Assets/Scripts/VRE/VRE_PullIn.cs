using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_PullIn : MonoBehaviour {

    public VRE_Pointer_Grab _vrePointerGrab;
    public Transform _destination;

	// Use this for initialization
	void Start () {

        // Subscribe to Grab events
        _vrePointerGrab._onGrab += DoGrab;
        _vrePointerGrab._onUngrab += DoUngrab;

        // Set state to hidden
        ToggleVisibility(false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DoGrab()
    {
        Debug.Log("Pull Button Heard Grab Event");

        // Change state to default
        ToggleVisibility(true);

    }

    public void DoUngrab()
    {
        Debug.Log("Pull Button Heard Ungrab Event");
        // Change state to default
        ToggleVisibility(false);

    }

    public void DoSelect()
    {
        Debug.Log("PullIn Clicked");


        if (_vrePointerGrab._isGrabbing)
        {

            // Trigger Haptic Event
            VRE_Utilities.TriggerHapticPulse(Hand.Right, 0.5f);

            // turn off the laser
            _vrePointerGrab._vrePointer.DoTriggerUnclicked(null, new VRTK.ControllerInteractionEventArgs());

            // Set cursor to 0,0,0 in controller
            GameObject g = _vrePointerGrab._vrePointer._selection;
            g.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(VRE_TweenHelper.TweenPositionWithEasing(g, g.transform.position, _destination.position, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));
            g.transform.SetParent(VRE_Globals._instance._worldParent);
            _vrePointerGrab.UnGrab();
            g.SetActive(true);

        }

    }

    
    void ToggleVisibility(bool visible)
    {

        foreach(Transform child in this.gameObject.transform)
        {
            child.gameObject.SetActive(visible);
        }

    }

    // Unsubscribe to events
    private void OnDestroy()
    {
        _vrePointerGrab._onGrab -= DoGrab;
        _vrePointerGrab._onUngrab -= DoUngrab;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullIn : MonoBehaviour {

    public VRE_Pointer_Grab _vrePointerGrab;
    public Transform _destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            g.SetActive(true);

        }

    }



}

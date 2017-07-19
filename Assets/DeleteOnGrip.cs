﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DeleteOnGrip : MonoBehaviour {

    VRTK_ControllerEvents _vrtkControllerEvents;
    VRTK_InteractGrab _vrtkInteractGrab;

    public AudioClip _deleteSound;

	// Use this for initialization
	void Start () {

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);

        _vrtkInteractGrab = _vrtkInteractGrab ?? this.gameObject.GetComponent<VRTK_InteractGrab>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    void DoGripPressed (object sender, ControllerInteractionEventArgs e)
    {

        GameObject g = _vrtkInteractGrab.GetGrabbedObject();
        if (g != null)
        {
            Debug.Log("Deleted: " + g.name);

            // VRTK_ControllerHaptics.TriggerHapticPulse(VRTK_ControllerReference.GetControllerReference(_hand), 1.0f, 1.0f, 1.0f);
            // VRTK_ControllerHaptics.TriggerHapticPulse(e.controllerReference, 1.0f, 1.0f, 1.0f);
            
            TransitionUtility.TriggerHapticsAndAudio(e.controllerReference.model, e.controllerReference, 1.0f, _deleteSound);

            GameObject.Destroy(g);

        }

    }
}

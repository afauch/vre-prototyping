using System.Collections;
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
            ObjectActions.TrashObject(g, e.controllerReference, _deleteSound);
        }

    }
}

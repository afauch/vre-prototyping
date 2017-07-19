using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DeleteOverShoulder : MonoBehaviour {

    public AudioClip _deleteSound;
    public SDK_BaseController.ControllerHand _hand;
    public DetectOverShoulder _detectOverShoulder;

	// Use this for initialization
	void Start () {

        // subscribe
        _detectOverShoulder.OnOverShoulder += DoOverShoulder;
        // Debug.Log(DetectOverShoulder._instance._onOverShoulder);

	}

    public void DoOverShoulder(Collider c)
    {

        // Debug.Log("DoOverShoulder called");

        // is this an interactable object?
        VRTK_InteractableObject vrtkInteractableObject = c.gameObject.GetComponent<VRTK_InteractableObject>();
        if(vrtkInteractableObject != null && vrtkInteractableObject.IsGrabbed())
        {
            ObjectActions.TrashObject(c.gameObject, VRTK_ControllerReference.GetControllerReference(_hand), _deleteSound);
        }

    }

}

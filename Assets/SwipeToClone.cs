using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SwipeToClone : MonoBehaviour {

    VRTK_InteractGrab _vrtkInteractGrab;

    public AudioClip _deleteSound;

    // Use this for initialization
    void Start()
    {
   
        _vrtkInteractGrab = _vrtkInteractGrab ?? this.gameObject.GetComponent<VRTK_InteractGrab>();

    }

    // Update is called once per frame
    void Update () {
		
	}


    // The ViveSwipeDetector.cs broadcasts this message
    void DoSwipeRight()
    {
        Debug.Log("I heard DoSwipeRight");

        // Are we holding anything?
        GameObject g = _vrtkInteractGrab.GetGrabbedObject();
        if (g != null)
        {
            CloneObject(g);
        }
    }

    void CloneObject(GameObject original)
    {
        Debug.Log("CloneObject called");

        // Clone the object
        GameObject clone = GameObject.Instantiate(original);

        clone.GetComponent<VRTK_InteractableObject>().ForceStopInteracting();
        clone.GetComponent<Rigidbody>().isKinematic = true;
        Object.Destroy(clone.GetComponent<FixedJoint>());

    }

}

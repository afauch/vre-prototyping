using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public static class ObjectActions {

    public static void TrashObject (GameObject g, VRTK_ControllerReference controllerReference, AudioClip clip)
    {

        Debug.Log("Deleted: " + g.name);
        TransitionUtility.TriggerHapticsAndAudio(controllerReference.model, controllerReference, 1.0f, clip);
        GameObject.Destroy(g);
    }
    
    public static void CloneObject (GameObject original)
    {
        Debug.Log("CloneObject called");

        // Clone the object
        GameObject clone = GameObject.Instantiate(original);

        clone.GetComponent<VRTK_InteractableObject>().ForceStopInteracting();
        clone.GetComponent<Rigidbody>().isKinematic = true;
        Object.Destroy(clone.GetComponent<FixedJoint>());

    }

}

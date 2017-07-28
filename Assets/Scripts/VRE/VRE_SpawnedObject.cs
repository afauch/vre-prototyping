using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_SpawnedObject : MonoBehaviour {

    public VRTK_ControllerEvents _vrtkControllerEvents;

    // Use this for initialization
    void Start () {

        _vrtkControllerEvents = VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);

    }

    private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log("DoTriggerUnclickedCalled from " + this.gameObject.name);
        this.gameObject.transform.SetParent(VRE_Globals._instance._worldParent);

        // Unsubscribe and destroy
        _vrtkControllerEvents.TriggerUnclicked -= new ControllerInteractionEventHandler(DoTriggerUnclicked);
        Destroy(this);

    }


}

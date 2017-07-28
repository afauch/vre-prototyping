using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_EntityButton : MonoBehaviour {

    public GameObject _entityToSpawn;
    // public VRTK_ControllerEvents _vrtkControllerEvents;


    private void Start()
    {


    }

    public void DoSelect()
    {

        SpawnInstance();

    }

    private void SpawnInstance()
    {
        GameObject instance = GameObject.Instantiate(_entityToSpawn);

        // get controller attach point
        // Rigidbody attachPoint = _vrtkControllerEvents.gameObject.GetComponent<VRTK_InteractGrab>().controllerAttachPoint;
        Rigidbody attachPoint = VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_InteractGrab>().controllerAttachPoint;

        instance.transform.position = attachPoint.gameObject.transform.position;


    }


}

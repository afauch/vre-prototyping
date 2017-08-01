using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_EntityButton : MonoBehaviour {

    public GameObject _entityToSpawn;
    public VRTK_ControllerEvents _vrtkControllerEvents;

    private GameObject _spawnedInstance = null;

    void Start()
    {

        //_vrtkControllerEvents = VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_ControllerEvents>();
        //_vrtkControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);

    }

    void Update()
    {

        // Debug.Log(_spawnedInstance.name);

    }

    public void DoSelect()
    {
        if(_entityToSpawn != null)
            SpawnInstance();

    }

    private void SpawnInstance()
    {
        _spawnedInstance = GameObject.Instantiate(_entityToSpawn);
        Debug.Log("SpawnedInstance = " + _spawnedInstance.name);

        // get controller attach point
        // Rigidbody attachPoint = _vrtkControllerEvents.gameObject.GetComponent<VRTK_InteractGrab>().controllerAttachPoint;
        Rigidbody attachPoint = VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_InteractGrab>().controllerAttachPoint;

        _spawnedInstance.transform.position = attachPoint.gameObject.transform.position;

        // Parent To Hand
        _spawnedInstance.transform.SetParent(attachPoint.transform);

        _spawnedInstance.AddComponent<VRE_SpawnedObject>();




    }

    //// Change Parent on Trigger Up
    //private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    //{

    //    if (_spawnedInstance != null)
    //    {

    //        Debug.Log("Dotriggerunclicked called");

    //        Debug.Log("DoTriggerUnclicked SpawnedInstance = " + _spawnedInstance.name);

    //        // _spawnedInstance.transform.SetParent(VRE_Globals._instance._worldParent);

    //    }

    //}


}

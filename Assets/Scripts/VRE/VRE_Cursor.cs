using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Cursor : MonoBehaviour {

    public static VRE_Cursor _instance;
    public GameObject _activeGameObject = null;

    void Awake()
    {
        _instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (VRE_StateManager._instance._verbose)
            Debug.Log("VRE_Cursor called OnTriggerEnter for " + other.gameObject);

        other.SendMessage("DoCursorEnter", SendMessageOptions.DontRequireReceiver);

        // Reassign _activeGameObject
        _activeGameObject = other.gameObject;

    }

    private void OnTriggerExit(Collider other)
    {

        Debug.Log("VRE_Cursor left " + _activeGameObject);

        if (VRE_StateManager._instance._verbose)
            Debug.Log("VRE_Cursor left " + _activeGameObject);

        other.SendMessage("DoCursorExit", SendMessageOptions.DontRequireReceiver);

        _activeGameObject = null;
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class PaletteObject : MonoBehaviour {

    private GameObject _spawnedObject;
    private GameObject _originPlaceholder;

    private bool _hasSpawned;

	// Use this for initialization
	void Start () {

        VRTK_InteractableObject vrtkInteractableObject = this.gameObject.GetComponent<VRTK_InteractableObject>();
        this.gameObject.AddComponent<VRTK_InteractableObject_UnityEvents>();
        VRTK_InteractableObject_UnityEvents vrtkInteractableObjectUnityEvents = this.gameObject.GetComponent<VRTK_InteractableObject_UnityEvents>();
            
            // GetComponent<VRTK_InteractableObject_UnityEvents>();

        vrtkInteractableObjectUnityEvents.OnGrab.AddListener(OnGrab);
        vrtkInteractableObjectUnityEvents.OnUngrab.AddListener(OnUngrab);

        _originPlaceholder = PrototypeGlobals._instance._originPlaceholder;

        _hasSpawned = false;

    }

    // Event Listeners

    void OnGrab (object o, InteractableObjectEventArgs e)
    {

        Debug.Log("Object grabbed: " + this.gameObject.name);
        if(!_hasSpawned)
            StartSpawn(e.interactingObject.gameObject);
    }

    void OnUngrab(object o, InteractableObjectEventArgs e)
    {

        Debug.Log("Object ungrabbed: " + this.gameObject.name);
        EndSpawn();

    }

    void StartSpawn(GameObject controller)
    {

        // Spawn another placeholder in its place
        GameObject newOriginal = GameObject.Instantiate(this.gameObject, this.gameObject.transform.parent);
        Renderer rO = newOriginal.GetComponent<Renderer>();
        rO.material.color = Color.green;


        // Parent the object to the hand
        this.transform.localScale *= 5.0f;
        Renderer r = this.GetComponent<Renderer>();
        r.material.color = Color.red;
        this.transform.SetParent(controller.transform);

        // this.GetComponent<Rigidbody>().isKinematic = true;

    }

    void EndSpawn()
    {

        _hasSpawned = true;

        // change transform to world space
        this.transform.SetParent(_originPlaceholder.transform);

        // make it grabbable
        // _spawnedObject.GetComponent<VRTK_InteractableObject>().isGrabbable = true;
    }

}

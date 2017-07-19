using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ContextMenu : MonoBehaviour {

    public AudioClip _cloneSound;
    public AudioClip _deleteSound;

    VRTK_ControllerEvents _vrtkControllerEvents;
    VRTK_InteractGrab _vrtkInteractGrab;

    bool _isDisplayed = false;

    public GameObject _contextMenu;
    public Transform _contextMenuSpawn;

    [HideInInspector] public RadialAction _selectedAction;

    // Use this for initialization
    void Start () {

        // Subscribe to Grip
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        _vrtkControllerEvents.GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

        _vrtkInteractGrab = _vrtkInteractGrab ?? this.gameObject.GetComponent<VRTK_InteractGrab>();

    }
	
	// Update is called once per frame
	void Update () {
	
        if(_isDisplayed)
        {
             //_contextMenu.transform.LookAt(Vector3.up);

        }

    }

    void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log("Grip Clicked");

        _contextMenu.transform.position = _contextMenuSpawn.position;
        _contextMenu.transform.rotation = _contextMenuSpawn.rotation;

        _contextMenu.SetActive(true);

        _isDisplayed = true;

    }

    void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Grip Unclicked");
        _contextMenu.SetActive(false);

        _isDisplayed = false;

        DoAction(_selectedAction, _vrtkInteractGrab.GetGrabbedObject(), e.controllerReference);

    }

    void DoAction(RadialAction action, GameObject grabbedObject, VRTK_ControllerReference controllerReference)
    {

        Debug.Log("DoAction called");

        switch (action)
        {
            case RadialAction.Clone:
                Debug.Log("Clone");
                ObjectActions.CloneObject(grabbedObject);
                break;
            case RadialAction.Delete:
                ObjectActions.TrashObject(grabbedObject, controllerReference, _deleteSound);
                Debug.Log("Delete");
                break;
            default:
                Debug.Log("No action");
                break;
        }
  

    }


}

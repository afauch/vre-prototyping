using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ContextDial : MonoBehaviour
{

    public AudioClip _cloneSound;
    public AudioClip _deleteSound;

    public Transform _origin;

    VRTK_ControllerEvents _vrtkControllerEvents;
    VRTK_InteractGrab _vrtkInteractGrab;

    bool _isDisplayed = false;

    public GameObject[] _options;
    public float[] _incrementValues;

    public GameObject _contextMenu;
    public Transform _contextMenuSpawn;

    // Dial Parameters
    private Vector3 _startEulerAngles;
    private float _startZ;
    
    [HideInInspector] public DialAction _selectedAction;

    // Use this for initialization
    void Start()
    {

        // Subscribe to Grip
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        _vrtkControllerEvents.GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

        _vrtkInteractGrab = _vrtkInteractGrab ?? this.gameObject.GetComponent<VRTK_InteractGrab>();

        InitIncrementSize();

    }

    // Update is called once per frame
    void Update()
    {

        if (_isDisplayed)
        {
            //_contextMenu.transform.LookAt(Vector3.up);
            CalculateSelection();
        }

    }

    void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log("Grip Clicked");

        _contextMenu.transform.position = _contextMenuSpawn.position;
        _contextMenu.transform.rotation = _contextMenuSpawn.rotation;
        Vector3 upRotation = _contextMenu.transform.rotation.eulerAngles;
        upRotation.z = Vector3.up.z;

        _contextMenu.SetActive(true);

        _startEulerAngles = _origin.rotation.eulerAngles;
        _startZ = _origin.rotation.eulerAngles.z;

        _isDisplayed = true;

    }

    void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Grip Unclicked");
        _contextMenu.SetActive(false);

        _isDisplayed = false;

        DoAction(_selectedAction, _vrtkInteractGrab.GetGrabbedObject(), e.controllerReference);

    }

    void InitIncrementSize()
    {


        // Divide up the space -90 to 90 based on the 
        // number of options
        float incrementSize = 180 / _options.Length;

        _incrementValues = new float[_options.Length + 1];

        for (int i = 0; i < _options.Length; i++)
        {
            _incrementValues[i] = (-90 + (incrementSize * i));
        }

        _incrementValues[_options.Length] = 180;

        for (int i = 0; i < _incrementValues.Length; i++)
        {

            Debug.Log(_incrementValues[i]);
        }

    }

    void CalculateSelection()
    {

        Vector3 currentEulerAngles = _origin.transform.rotation.eulerAngles;
        float currentZ = _origin.transform.rotation.eulerAngles.z;

        float deltaAngle = Mathf.DeltaAngle(_startZ, currentZ);
        deltaAngle *= -1.0f;
        Debug.Log(deltaAngle);

        GameObject selectedGameObject = null;

        // Select the right gameObject
        for(int i = 0; i < _options.Length; i++)
        {

            // are we above the base value for this option?
            if(deltaAngle > _incrementValues[i])
            {

                // are we less than the next one?
                if(deltaAngle < _incrementValues[i+1])
                {
                    // Yes - this is the option
                    selectedGameObject = _options[i];
                } else
                {
                    // No - move on to the next option and check
                    _options[i].SendMessage("DoHoverExit");
                    continue;
                }

            } else
            {
                _options[i].SendMessage("DoHoverExit");
                continue;
            }

        }

        selectedGameObject.SendMessage("DoHoverEnter");
        _selectedAction = selectedGameObject.GetComponent<DialUI>()._action;

        Debug.Log(selectedGameObject.name);


    }

    void DoAction(DialAction action, GameObject grabbedObject, VRTK_ControllerReference controllerReference)
    {

        Debug.Log("DoAction called");

        switch (action)
        {
            case DialAction.Clone:
                Debug.Log("Clone");
                ObjectActions.CloneObject(grabbedObject);
                break;
            case DialAction.Delete:
                ObjectActions.TrashObject(grabbedObject, controllerReference, _deleteSound);
                Debug.Log("Delete");
                break;
            default:
                Debug.Log("No action");
                break;
        }


    }

}

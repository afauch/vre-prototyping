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

    public GameObject _contextMenu;
    public Transform _contextMenuSpawn;

    // Dial Parameters
    public LayerMask _layerMask;
    public float _maxDistance = 2.0f;

    [Header("Pointer Appearance")]
    private LineRenderer _lr;
    public Material _lineMaterial;
    public Color _lineColor;
    public float _lineWidth = 0.01f;
    private RaycastHit _hitInfo;

    [HideInInspector] public DialAction _selectedAction;

    // Use this for initialization
    void Start()
    {

        // Subscribe to Grip
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        _vrtkControllerEvents.GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

        _vrtkInteractGrab = _vrtkInteractGrab ?? this.gameObject.GetComponent<VRTK_InteractGrab>();

        InitLineRenderer();

    }

    // Update is called once per frame
    void Update()
    {

        if (_isDisplayed)
        {
            //_contextMenu.transform.LookAt(Vector3.up);
            GenerateRaycast();
        } else
        {
            RenderLine(_lr, false);
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

    void GenerateRaycast ()
    {

        RenderLine(_lr, true);

    }

    void DoAction(DialAction action, GameObject grabbedObject, VRTK_ControllerReference controllerReference)
    {

        Debug.Log("DoAction called");

        //switch (action)
        //{
        //    case DialAction.Clone:
        //        Debug.Log("Clone");
        //        ObjectActions.CloneObject(grabbedObject);
        //        break;
        //    case DialAction.Delete:
        //        ObjectActions.TrashObject(grabbedObject, controllerReference, _deleteSound);
        //        Debug.Log("Delete");
        //        break;
        //    default:
        //        Debug.Log("No action");
        //        break;
        //}


    }


    void InitLineRenderer()
    {

        _lr = _origin.gameObject.AddComponent<LineRenderer>();
        Debug.Log(_lr);
        _lr.enabled = false;
        _lr.material = _lineMaterial;
        _lr.startColor = _lineColor;
        _lr.endColor = _lineColor;
        _lr.widthMultiplier = _lineWidth;
        _lr.startWidth = _lineWidth;
        _lr.endWidth = _lineWidth;


    }

    void RenderLine(LineRenderer lr, bool toggle)
    {
        // Debug.Log("RenderLine called");
        lr.enabled = toggle;

        if (lr.enabled)
        {



            Vector3[] linePositions = new Vector3[]
            {
                   _origin.transform.position,
                   (_origin.transform.forward)
            };
            lr.SetPositions(linePositions);

        }

    }

}

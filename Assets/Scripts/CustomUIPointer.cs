using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class CustomUIPointer : MonoBehaviour {

    public VRTK_ControllerEvents _vrtkControllerEvents;
    public GameObject _origin;
    public LayerMask _layerMask;
    public float _maxDistance = 100.0f;

    [Header("Pointer Appearance")]
    public GameObject _cursor;
    private LineRenderer _lr;
    public Material _lineMaterial;
    public Color _lineColor;
    public float _lineWidth = 0.01f;
    private RaycastHit _hitInfo;

	// Use this for initialization
	void Start () {

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);

        // Setup LineRenderer
        InitLineRenderer();

    }
	
	// Update is called once per frame
	void Update () {

        // Always be raycasting
        if (Physics.Raycast(_origin.transform.position, _origin.transform.forward, out _hitInfo, _maxDistance, _layerMask.value))
        {
            DoHitUI(_hitInfo);
        } else
        {
            RenderLine(_lr, false);
        }
		
	}


    void InitLineRenderer()
    {

        _lr = this.gameObject.AddComponent<LineRenderer>();
        Debug.Log(_lr);
        _lr.enabled = false;
        _lr.material = _lineMaterial;
        _lr.startColor = _lineColor;
        _lr.endColor = _lineColor;
        _lr.widthMultiplier = _lineWidth;
        _lr.startWidth = _lineWidth;
        _lr.endWidth = _lineWidth;

        // Init Cursor
        _cursor.transform.position = Vector3.zero;
        _cursor.SetActive(false);
    
    }

    void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Trigger Clicked");
    }

    void DoHitUI(RaycastHit hit)
    {
        // Debug.Log("Intersected 3D UI: " + hit.collider.gameObject.name);
        RenderLine(_lr, true);
 
    }

    void RenderLine(LineRenderer lr, bool toggle)
    {
        // Debug.Log("RenderLine called");
        lr.enabled = toggle;
        _cursor.SetActive(toggle);


        if (lr.enabled)
        {

            Vector3[] linePositions = new Vector3[]
            {
                   _origin.transform.position,
                   _hitInfo.point
            };
            lr.SetPositions(linePositions);

            // Set cursor position
            _cursor.transform.position = _hitInfo.point;

        }

    }


}

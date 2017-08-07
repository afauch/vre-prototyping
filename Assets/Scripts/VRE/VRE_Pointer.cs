﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_Pointer : MonoBehaviour {


    public VRTK_ControllerEvents _vrtkControllerEvents;
    public GameObject _origin;
    public LayerMask _layerMask;
    public float _maxDistance = 100.0f;


    [Header("Pointer Appearance")]
    public bool _showLine = true;
    public bool _showCursor = true;
    public GameObject _cursor;
    private LineRenderer _lr;
    public Material _lineMaterial;
    public Color _lineColor;
    public float _lineWidth = 0.01f;
    private RaycastHit _hitInfo;

    private bool _selectionIsClear = true;
    [HideInInspector] public GameObject _selection;

    // Use this for initialization
    void Start()
    {

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);
        _vrtkControllerEvents.TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);


        // Setup LineRenderer
        InitLineRenderer();

    }

    // Update is called once per frame
    void Update()
    {

        // Always be raycasting
        if (Physics.Raycast(_origin.transform.position, _origin.transform.forward, out _hitInfo, _maxDistance, _layerMask.value))
        {
            DoHitUI(_hitInfo);
        }
        else
        {

            ClearSelection();

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
        if (_hitInfo.collider != null)
            _hitInfo.collider.gameObject.SendMessage("DoSelect", SendMessageOptions.DontRequireReceiver);
    }

    void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("Trigger Unclicked");
        if(_hitInfo.collider != null)
            _hitInfo.collider.gameObject.SendMessage("DoTriggerUnclicked", SendMessageOptions.DontRequireReceiver);
    }

    void DoHitUI(RaycastHit hit)
    {
        // Debug.Log("Intersected 3D UI: " + hit.collider.gameObject.name);
        RenderLine(_lr, true);
        _selectionIsClear = false;
        _selection = hit.collider.gameObject;

    }

    void RenderLine(LineRenderer lr, bool toggle)
    {
        // Debug.Log("RenderLine called");

        if (toggle == true)
        {

            if (_showLine)
                lr.enabled = true;

            if (_showCursor)
                _cursor.SetActive(true);

        }
        else
        {
            lr.enabled = false;
            _cursor.SetActive(false);
        }

        Vector3[] linePositions = new Vector3[]
            {
                   _origin.transform.position,
                   _hitInfo.point
            };

        lr.SetPositions(linePositions);

        // Set cursor position
        _cursor.transform.position = _hitInfo.point;
        // _cursor.transform.rotation = _vrtkControllerEvents.gameObject.transform.rotation;

    }

    void ClearSelection()
    {

        if (!_selectionIsClear)
        {
            VRE_Cursor cursorComponent = _cursor.GetComponent<VRE_Cursor>();
            if (cursorComponent._activeGameObject != null)
            {
                cursorComponent._activeGameObject.SendMessage("DoCursorExit", SendMessageOptions.DontRequireReceiver);
            }
            cursorComponent._activeGameObject = null;
            _selectionIsClear = true;
            _selection = null;

        }

        RenderLine(_lr, false);

    }

}

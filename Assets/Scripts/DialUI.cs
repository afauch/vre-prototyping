using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialAction
{
    None,
    Clone,
    Delete
}

public class DialUI : MonoBehaviour
{

    public Material _hoverMaterial;
    private Material _defaultMaterial;
    private Material _currentMaterial;
    private Renderer _renderer;

    bool _isHovered = false;

    public DialAction _action;

    // Use this for initialization
    void Start()
    {

        _renderer = gameObject.GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void DoHoverEnter()
    {

        if (!_isHovered)
        {

            Debug.Log(this.gameObject.name + " DoHover called");
            _renderer.material = _hoverMaterial;
            TransitionUtility.TriggerHapticPulse(Hand.Right, 1.0f);
            _isHovered = true;

        }

    }

    public void DoHoverExit()
    {

        if (_isHovered)
        {

            _renderer.material = _defaultMaterial;
            _isHovered = false;

        }

    }
    
}

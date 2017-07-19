using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialAction
{
    Clone,
    Delete
}

public class Dial : MonoBehaviour
{

    public Material _hoverMaterial;
    private Material _defaultMaterial;
    private Material _currentMaterial;
    private Renderer _renderer;

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

    private void OnTriggerStay(Collider other)
    {
        _renderer.material = _hoverMaterial;

        // is there a ContextMenu component on this object?
        ContextDial cd = other.gameObject.GetComponentInParent<ContextDial>();
        if (cd != null)
        {
            // Debug.Log("ContextMenu component detected");
            cd._selectedAction = _action;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        _renderer.material = _defaultMaterial;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RadialAction
{
    Clone,
    Delete
}

public class RadialUI : MonoBehaviour {

    public Material _hoverMaterial;
    private Material _defaultMaterial;
    private Material _currentMaterial;
    private Renderer _renderer;

    public RadialAction _action;

	// Use this for initialization
	void Start () {

        _renderer = gameObject.GetComponent<Renderer>();
        _defaultMaterial = _renderer.material;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        _renderer.material = _hoverMaterial;

        // is there a ContextMenu component on this object?
        ContextMenu cm = other.gameObject.GetComponentInParent<ContextMenu>();
        if(cm != null)
        {
            // Debug.Log("ContextMenu component detected");
            cm._selectedAction = _action;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        _renderer.material = _defaultMaterial;
    }

}

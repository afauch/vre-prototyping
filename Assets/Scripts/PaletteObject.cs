using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class PaletteObject : MonoBehaviour {

    public VRTK_ControllerEvents _vrtkControllerEvents;
    public GameObject _objectToSpawn;

    public Color _hoverMaterialColor;
    public float _transitionTime = 0.3f;

    private Color _defaultMaterialColor;
    private Renderer _renderer;

    private Vector3 _defaultButtonScale;
    public float _hoverScaleMultiplier;

    private bool _isSelected = false;

    void Start()
    {

        // listen for controller events
        _vrtkControllerEvents.TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);

        _renderer = this.gameObject.GetComponent<Renderer>();
        _defaultMaterialColor = _renderer.material.color;

        _defaultButtonScale = this.gameObject.transform.localScale;

        // Reset object's orientation
        _objectToSpawn.transform.position = Vector3.zero;
        _objectToSpawn.transform.rotation = Quaternion.identity;

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ToolMenuButton" + gameObject.name + "OnTriggerStay called");
        // StartCoroutine(LerpHelper.ColorFade(this.gameObject, _hoverMaterialColor, 0.001f, "Quintic"));
        _renderer.material.color = _hoverMaterialColor;

        // Construct Vector3
        Vector3 hoverScale = new Vector3(_defaultButtonScale.x, _defaultButtonScale.y * _hoverScaleMultiplier, _defaultButtonScale.z);
        StartCoroutine(LerpHelper.LerpScaleWithEasing(this.gameObject, this.gameObject.transform.localScale, hoverScale, _transitionTime, "Quintic", false));

        TransitionUtility.TriggerHapticPulse(Hand.Right, 0.2f);

        _isSelected = true;

    }
    
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(LerpHelper.ColorFade(this.gameObject, _defaultMaterialColor, _transitionTime, "Quintic"));
        StartCoroutine(LerpHelper.LerpScaleWithEasing(this.gameObject, this.gameObject.transform.localScale, _defaultButtonScale, _transitionTime, "Quintic", false));
        Debug.Log("ToolMenuButton " + gameObject.name + "OnTriggerExit called");

        _isSelected = false;

        // _renderer.material = _defaultMaterial;
    }

    private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
    {

        if (this._isSelected)
        {
            Debug.Log(gameObject.name + " was clicked.");
            SpawnInstance();
        }
    }

    private void SpawnInstance()
    {
        GameObject instance = GameObject.Instantiate(_objectToSpawn);

        // get controller attach point
        Rigidbody attachPoint = _vrtkControllerEvents.gameObject.GetComponent<VRTK_InteractGrab>().controllerAttachPoint;

        instance.transform.position = attachPoint.gameObject.transform.position;


    }

}

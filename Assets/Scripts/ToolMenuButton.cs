using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMenuButton : MonoBehaviour {

    public Color _hoverMaterialColor;
    public float _transitionTime = 0.3f;

    private Color _defaultMaterialColor;
    private Renderer _renderer;

    private Vector3 _defaultButtonScale;
    public float _hoverScaleMultiplier;

    void Start()
    {
        _renderer = this.gameObject.GetComponent<Renderer>();
        _defaultMaterialColor = _renderer.material.color;

        _defaultButtonScale = this.gameObject.transform.localScale;

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
 
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(LerpHelper.ColorFade(this.gameObject, _defaultMaterialColor, _transitionTime, "Quintic"));
        StartCoroutine(LerpHelper.LerpScaleWithEasing(this.gameObject, this.gameObject.transform.localScale, _defaultButtonScale, _transitionTime, "Quintic", false));
        Debug.Log("ToolMenuButton " + gameObject.name + "OnTriggerExit called");
        // _renderer.material = _defaultMaterial;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Utilities : MonoBehaviour {

    public static VRE_Utilities _instance;

    void Awake()
    {
        _instance = this;
    }

    public void SetOpacity(GameObject g, float targetOpacity)
    {

        // For each child in transform
        foreach (Transform child in g.transform)
        {
            StartCoroutine(VRE_TweenHelper.OpacityFade(child.gameObject, targetOpacity, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, "_Color"));
            Debug.Log(child.gameObject.name);

        }

    }

    public void ChangeStates(VRE_IUIElement uiElement, VRE_StateType toStateType)
    {

        Debug.Log("VRE_Utilities ChangeStates called");

        // What's the current state?
        VRE_State currentState = uiElement._states[uiElement._currentStateType];
        VRE_State defaultState = uiElement._states[VRE_StateType.Default];
        VRE_State targetState = uiElement._states[toStateType];

        // Tween between all elements of the state

        // Position
        Vector3 targetPosition = uiElement._defaultTransform._localPosition + targetState._positionOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalPositionWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localPosition, targetPosition, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Rotation
        Vector3 targetRotation = uiElement._defaultTransform._localRotation.eulerAngles + targetState._rotationOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalRotationWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localRotation.eulerAngles, targetRotation, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Scale
        Vector3 targetScale = uiElement._defaultTransform._localScale + targetState._scaleOffset;
        StartCoroutine(VRE_TweenHelper.TweenLocalScaleWithEasing(uiElement._gameObject, uiElement._gameObject.transform.localScale, targetScale, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing, false));

        // Material
        if (targetState._material != null)
        {
            Material targetMaterial = targetState._material;
            StartCoroutine(VRE_TweenHelper.ColorFade(uiElement._gameObject, targetMaterial, VRE_Globals._instance._quickFade, VRE_Globals._instance._quickFadeEasing));
        }

        // finally change the UI Element's current state flag
        uiElement._currentStateType = toStateType;

    }


}

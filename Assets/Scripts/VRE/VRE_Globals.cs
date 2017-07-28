﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monobehaviour Globals Class
/// </summary>
public class VRE_Globals : MonoBehaviour {

    public static VRE_Globals _instance;

    public GameObject _leftHandAvatarModel;
    public GameObject _rightHandAvatarModel;

    public GameObject _rightHandControllerEvents;
    public GameObject _leftHandControllerEvents;

    public GameObject _uiTop;
    public GameObject _uiBottom;

    public Transform _uiTopTransform;
    public Transform _uiBottomTransform;

    public GameObject _toolBaseModel;
    public VRE_Pointer _pointer;

    [Header("Transition Defaults")]
    public float _quickFade;
    public string _quickFadeEasing;
    public float _longFade;
    public string _longFadeEasing;

    void Awake()
    {
        _instance = this;
    }

    private void Start()
    {

        // Parent UI elements to their correct transforms
        ApplyUIParentTransforms(_uiTop, _uiTopTransform);
        ApplyUIParentTransforms(_uiBottom, _uiBottomTransform);

    }


    private void ApplyUIParentTransforms(GameObject uiGameObject, Transform parentTransform)
    {

        uiGameObject.transform.SetParent(parentTransform);
        uiGameObject.transform.localPosition = Vector3.zero;
        uiGameObject.transform.localRotation = Quaternion.identity;

    }


}

public enum VRE_StateType
{
    Default,
    Hidden,
    Hover,
    Selected
}

public class VRE_TransformSnapshot
{

    public Vector3 _position;
    public Vector3 _localPosition;
    public Quaternion _rotation;
    public Quaternion _localRotation;
    public Vector3 _lossyScale;
    public Vector3 _localScale;

    public VRE_TransformSnapshot(Transform t)
    {

        _position = t.position;
        _localPosition = t.localPosition;
        _rotation = t.rotation;
        _localRotation = t.localRotation;
        _lossyScale = t.lossyScale;
        _localScale = t.localScale;

    }

}

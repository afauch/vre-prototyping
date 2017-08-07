using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monobehaviour Globals Class
/// </summary>
public class VRE_Globals : MonoBehaviour {

    public static VRE_Globals _instance;

    [Header("Hands")]
    public GameObject _leftHandAvatarModel;
    public GameObject _rightHandAvatarModel;
    public GameObject _rightHandControllerEvents;
    public GameObject _leftHandControllerEvents;

    [Header("UI - Top")]
    public GameObject _uiTop;
    public Transform _uiTopTransform;
    public VRE_Panel _toolPanel;

    [Header("UI - Bottom")]
    public GameObject _uiBottom;
    public Transform _uiBottomTransform;

    [Header("UI - Right Hand")]
    public VRE_ToolModel _toolModel;
    public Transform _uiToolTransform;

    [Header("General")]
    public Transform _worldParent;
    public VRE_Pointer _pointer;
    public GameObject _toolPointer;
    public GameObject _grabPointer;


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
        ApplyUIParentTransforms(_toolModel.gameObject, _uiToolTransform);

        // By default, tool base model is hidden
        

    }


    private void ApplyUIParentTransforms(GameObject uiGameObject, Transform parentTransform)
    {
        Debug.Log("Applying parent transform " + parentTransform.gameObject.name + "to" + uiGameObject.name);

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
    Selected,
    Locked
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

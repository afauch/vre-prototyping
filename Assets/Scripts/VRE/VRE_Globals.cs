using System.Collections;
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

    public float _fadeTime;

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

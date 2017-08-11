using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

/// <summary>
/// Monobehaviour Globals Class
/// </summary>
public class VRE_Globals : MonoBehaviour {

    public static VRE_Globals _instance;

    [Header("SDK")]
    public bool _isOculus;
    private VRTK_SDKSetup _sdkSetup = null;
    public delegate void SetupChangeDelegate();
    public event SetupChangeDelegate _onSetupChange;

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
    public VRE_Pointer _pointer;
    public GameObject _toolPointer;
    public GameObject _grabPointer;

    [Header("General")]
    public Transform _worldParent;

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
        

    }

    void Update()
    {
        CheckAssignSDK();
    }

    void CheckAssignSDK()
    {
        // Which SDK are we using?
        // Debug.Log("Loaded setup is: " + VRTK_SDKManager.instance.loadedSetup);
        VRTK_SDKSetup setupNow = VRTK_SDKManager.instance.loadedSetup;

        // If the setup has changed
        if (setupNow != _sdkSetup)
        {
            // Reassign the current setup
            _sdkSetup = setupNow;

            // Check if it's Oculus
            if (VRTK_DeviceFinder.GetHeadsetType() == VRTK.VRTK_DeviceFinder.Headsets.OculusRift || VRTK_DeviceFinder.GetHeadsetType() == VRTK.VRTK_DeviceFinder.Headsets.OculusRiftCV1)
            {
                Debug.Log("Confirmed that new setup is Oculus");
                _isOculus = true;
            } else
            {
                _isOculus = false;
            }

            // Call the delegates to resubscribe events
            if (_onSetupChange != null)
                _onSetupChange();

            // Debug
            Debug.Log("SDK Setup has changed.");

        }

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

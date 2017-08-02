using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristTurnToggle : MonoBehaviour {

    public Transform _handTransform = null;
    public GameObject _restingPanel;
    private VRE_Panel _restingPanelComponent;
    public GameObject _turnedPanel;
    private VRE_Panel _turnedPanelComponent;

    public bool _hide = true;
    public float _opacityAmount;

    private bool _isTurned = false;

	// Use this for initialization
	void Start () {
		
        if(_handTransform == null)
        {

            _handTransform = VRE_Globals._instance._leftHandAvatarModel.transform;

        }

        _restingPanelComponent = _restingPanel.GetComponent<VRE_Panel>();
        _turnedPanelComponent = _turnedPanel.GetComponent<VRE_Panel>();


    }

    // Update is called once per frame
    void Update () {

        float handYAngleRaw = _handTransform.localRotation.eulerAngles.y;

        // Debug
        // Debug.Log(handYAngleRaw);

        // Default is 330 deg
        if (handYAngleRaw > 0.0f && handYAngleRaw < 180.0f)
        {

            if (!_isTurned)
                TogglePanel(true);

        } else
        {
            if (_isTurned)
                TogglePanel(false);
        }
		
	}

    void TogglePanel(bool isTurned)
    {

        VRE_Utilities.TriggerHapticPulse(Hand.Left, 0.5f);

        Debug.Log("Toggle");

        if (_hide)
        {

            Debug.Log("Hide other panel");

            _restingPanel.SetActive(!isTurned);
            _turnedPanel.SetActive(isTurned);
            _isTurned = isTurned;


        }
        else
        {

            Debug.Log("Fade other panel");

            if (isTurned)
            {
                _restingPanelComponent.SetOpacity(_opacityAmount);
                _turnedPanelComponent.SetOpacity(1.0f);
                _isTurned = true;
            } else
            {
                _restingPanelComponent.SetOpacity(1.0f);
                _turnedPanelComponent.SetOpacity(_opacityAmount);
                _isTurned = false;
            }



        }


    }

}

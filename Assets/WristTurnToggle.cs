using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristTurnToggle : MonoBehaviour {

    public Transform _handTransform = null;
    public GameObject _restingPanel;
    public GameObject _turnedPanel;

    private bool _isTurned = false;

	// Use this for initialization
	void Start () {
		
        if(_handTransform == null)
        {

            _handTransform = VRE_Globals._instance._leftHandAvatarModel.transform;

        }

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

        _restingPanel.SetActive(!isTurned);
        _turnedPanel.SetActive(isTurned);
        _isTurned = isTurned;


    }

}

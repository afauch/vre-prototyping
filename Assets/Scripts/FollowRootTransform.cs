using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FollowRootTransform : MonoBehaviour {

    public Transform _rootTransform;

    private Transform _headsetTransform;
    private SDK_BaseHeadset _sdkBaseHeadset;

    public float _YOffset;
    public float _forwardOffset;

    // Use this for initialization
    void Start () {
 
        _headsetTransform = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.Headset);

	}
	
	// Update is called once per frame
	void Update () {

        _headsetTransform = VRTK_DeviceFinder.DeviceTransform(VRTK_DeviceFinder.Devices.Headset);
        // Debug.Log(_headsetTransform.gameObject.name);

        if (_headsetTransform != null)
        {

            // Update body rotation
            Transform _thisRotation = this.gameObject.transform;

            Vector3 _newRotation = new Vector3(
                0.0f,
                _headsetTransform.rotation.eulerAngles.y,
                0.0f
                );

            _thisRotation.eulerAngles = _newRotation;


            // Update body position
            this.gameObject.transform.position =
                new Vector3(_headsetTransform.position.x, _YOffset, _headsetTransform.position.z) +
                (this.gameObject.transform.forward * _forwardOffset);

        }


    }

}

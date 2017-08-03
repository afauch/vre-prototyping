using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_State : MonoBehaviour {

    public VRE_StateType _stateType;

    [Header("State Appearance")]
    public Material _material;
    public float _opacity = 1.0f;
    public Vector3 _positionOffset;
    public Vector3 _rotationOffset;
    public Vector3 _scaleOffset;

    [Header("Transition")]
    public bool _tweenMaterial;
    public bool _playAudio = false;
    public AudioClip _audioClip = null;
    public bool _triggerHaptics = false;
    public float _hapticStrength = 0.0f;




    void Start()
    {

        //if(_material = null)
        //{

        //    Renderer r = this.gameObject.GetComponent<Renderer>();
        //    if (r != null)
        //    {

        //        _material = r.material;

        //    }

        //}
                
    }


}

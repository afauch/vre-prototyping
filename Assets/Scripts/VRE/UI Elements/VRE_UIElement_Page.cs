using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_UIElement_Page : MonoBehaviour {

    public GameObject _gameObject = null;
    public VRE_StateType _currentStateType;
    public VRE_TransformSnapshot _defaultTransform;

    public Dictionary<VRE_StateType, VRE_State> _states;

    public int _pageIndex;


    private void Start()
    {

        // Subscribe to selection events
        if (_gameObject == null)
            _gameObject = this.gameObject;

        Debug.Log(" this page is " + _gameObject.name);

    }


    void OnSelect()
    {

        Debug.Log("OnSelect called from " + gameObject.name);

    }


    /// <summary>
    /// This should probably be a static function
    /// </summary>
    /// <param name="target"></param>
    public void SetOpacity(float target)
    {

        VRE_Utilities._instance.SetOpacity(_gameObject, target);

    }

}

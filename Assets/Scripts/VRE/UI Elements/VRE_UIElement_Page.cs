using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_UIElement_Page : MonoBehaviour, VRE_IUIElement {

    public GameObject _gameObject { get; set; }
    public VRE_StateType _currentStateType { get; set; }
    public VRE_TransformSnapshot _defaultTransform { get; set; }

    public Dictionary<VRE_StateType, VRE_State> _states { get; set; }

    public int _pageIndex;


    private void Start()
    {
        
        // Subscribe to selection events


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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_Page : MonoBehaviour, VRE_IUIElement {

    public VRE_State _currentState;
    public int _pageIndex;
    public GameObject _gameObject;

    private void Start()
    {
        
        // Subscribe to selection events


    }


    void OnSelect()
    {

        Debug.Log("OnSelect called from " + gameObject.name);

        SetOpacity(0.2f);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_UIElement_ButtonComponent : MonoBehaviour, VRE_IUIElement
{

    public bool _isContainer;

    public GameObject _gameObject { get; set; }
    public VRE_StateType _currentStateType { get; set; }
    public VRE_TransformSnapshot _defaultTransform { get; set; }

    public Dictionary<VRE_StateType, VRE_State> _states { get; set; }


    void Start()
    {

        _defaultTransform = new VRE_TransformSnapshot(this.transform);

        InitializeStates();

        // Assign GameObject
        if(_gameObject == null)
        {
            _gameObject = this.gameObject;
        }

    }


    /// <summary>
    /// Compile all the states 
    /// </summary>
    void InitializeStates()
    {

        _states = new Dictionary<VRE_StateType, VRE_State>();

        VRE_State[] thisStates = gameObject.GetComponents<VRE_State>();
        for(int i = 0; i < thisStates.Length; i++)
        {
            _states.Add(thisStates[i]._stateType, thisStates[i]);
        }

    }


    void DoCursorEnter()
    {
        if (VRE_StateManager._instance._verbose)
            Debug.Log("DoCursorEnter heard on " + this.gameObject.name);

        VRE_Utilities._instance.ChangeStates(this, VRE_StateType.Hover);
        VRE_Utilities.TriggerHapticPulse(Hand.Right, 0.8f);

    }

    void DoCursorExit()
    {
        if (VRE_StateManager._instance._verbose)
            Debug.Log("DoCursorExit called from " + this.gameObject.name);

        VRE_Utilities._instance.ChangeStates(this, VRE_StateType.Default);
        // VRE_Utilities.TriggerHapticPulse(Hand.Right, 0.05f);

    }

    void DoSelect()
    {
        if (VRE_StateManager._instance._verbose)
            Debug.Log("DoSelect called from " + this.gameObject.name);

        VRE_Utilities._instance.ChangeStates(this, VRE_StateType.Selected);

    }

    void ButtonAction()
    {

        

    }

    public void SetOpacity(float target)
    {
        
    }

}

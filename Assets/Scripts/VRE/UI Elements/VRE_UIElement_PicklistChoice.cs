using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_UIElement_PicklistChoice : MonoBehaviour, VRE_IUIElement
{

    public TextMesh _choiceText;
    [HideInInspector] public int _choiceIndex;
    [HideInInspector] public VRE_UIElement_Picklist _picklist;

    public GameObject _gameObject { get; set; }
    public VRE_TransformSnapshot _defaultTransform { get; set; }
    public VRE_StateType _currentStateType { get; set; }
    public Dictionary<VRE_StateType, VRE_State> _states { get; set; }

    public bool _triggerIsClicked;
    public bool _isActiveSelection;

    // Use this for initialization
    void Start () {

        InitializeUIComponent();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //
    // Typical UI behavior
    //

    /// <summary>
    /// Generic method for initializing this UI component
    /// </summary>
    void InitializeUIComponent()
    {

        _defaultTransform = new VRE_TransformSnapshot(this.transform);
        InitializeStates();

        // Assign GameObject
        if (_gameObject == null)
            _gameObject = this.gameObject;

    }


    /// <summary>
    /// Compile all the states 
    /// </summary>
    void InitializeStates()
    {

        _states = new Dictionary<VRE_StateType, VRE_State>();

        VRE_State[] thisStates = gameObject.GetComponents<VRE_State>();
        for (int i = 0; i < thisStates.Length; i++)
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

        _triggerIsClicked = true;
        _picklist.ChangeActiveChoice(_choiceIndex);

    }

    void DoTriggerUnclicked()
    {

        _triggerIsClicked = false;

    }

}

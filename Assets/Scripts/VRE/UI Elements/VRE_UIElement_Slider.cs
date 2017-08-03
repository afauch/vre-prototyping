using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_UIElement_Slider : MonoBehaviour, VRE_IUIElement
{

    public GameObject _gameObject { get; set; }
    public VRE_TransformSnapshot _defaultTransform { get; set; }
    public VRE_StateType _currentStateType { get; set; }
    public Dictionary<VRE_StateType, VRE_State> _states { get; set; }


    public Collider _hoverCollider;
    public Transform _sliderBottom;
    public Transform _sliderTop;
    public GameObject _levelMeter;
    public GameObject _hoverLevelMeter = null;

    public float _defaultLevel;
    public float _currentLevel;
    public float _currentHoverLevel;


    // Use this for initialization
    void Start () {

        InitializeUIComponent();


        if(_hoverLevelMeter == null)
        {
            _hoverLevelMeter = _levelMeter;
        }
           
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay(Collider other)
    {

        // Measure the distance between cursor and bottom
        float cursorToBottom = Vector3.Distance(other.gameObject.transform.position, _sliderBottom.position);

        // compare as ratio of distance from top to bottom
        float topToBottom = Vector3.Distance(_sliderTop.position, _sliderBottom.position);

        // Calculate the ratio
        _currentHoverLevel = cursorToBottom / topToBottom;

        Debug.Log(_currentHoverLevel);

        // Change the level of the _hoverLevelMeter gameObject
        if (_currentHoverLevel < 1.0f)
        {
            Vector3 hoverLevelScale = _hoverLevelMeter.transform.localScale;
            hoverLevelScale = new Vector3(hoverLevelScale.x, _currentHoverLevel, hoverLevelScale.z);
            _hoverLevelMeter.transform.localScale = hoverLevelScale;
        }

    }

    private void SelectLevel()
    {

        _currentLevel = _currentHoverLevel;

        // Change the level of the _levelMeter gameObject
        if (_currentLevel < 1.0f)
        {
            Vector3 levelScale = _levelMeter.transform.localScale;
            levelScale = new Vector3(levelScale.x, _currentLevel, levelScale.z);
            _levelMeter.transform.localScale = levelScale;
        }


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

        SelectLevel();

    }


}

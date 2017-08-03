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

    public float _defaultLevel = 0.5f;
    public float _currentLevel = 0.5f;
    public float _currentHoverLevel = 0.5f;

    private Vector3 _cursorPosition;
    private bool _triggerIsClicked = false;


    // Use this for initialization
    void Start () {

        InitializeUIComponent();


        if(_hoverLevelMeter == null)
        {
            _hoverLevelMeter = _levelMeter;
        }

        // Set to default level
        SetLevel(_defaultLevel);

		
	}
	
	// Update is called once per frame
	void Update () {


		
	}


    private void OnTriggerStay(Collider other)
    {

            _cursorPosition = other.gameObject.transform.position;

        // Measure the distance between cursor and bottom
        float cursorToBottom = Vector3.Distance(_cursorPosition, _sliderBottom.position);

        // compare as ratio of distance from top to bottom
        float topToBottom = Vector3.Distance(_sliderTop.position, _sliderBottom.position);

        if(VRE_StateManager._instance._verbose)
            Debug.Log(_currentHoverLevel);

        // Calculate the ratio
        _currentHoverLevel = cursorToBottom / topToBottom;

        if (_triggerIsClicked)
        {
            SetLevel();
        }
        else
        {
            SetHoverLevel();
        }

    }

    private void SetHoverLevel()
    {

        // Change the level of the _hoverLevelMeter gameObject
        if (_currentHoverLevel < 1.0f)
        {
            Vector3 hoverLevelScale = _hoverLevelMeter.transform.localScale;
            hoverLevelScale = new Vector3(hoverLevelScale.x, _currentHoverLevel, hoverLevelScale.z);
            _hoverLevelMeter.transform.localScale = hoverLevelScale;
        }
    }

    private void SetLevel()
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

    private void SetLevel (float level)
    {
        Vector3 levelScale = _levelMeter.transform.localScale;
        levelScale = new Vector3(levelScale.x, level, levelScale.z);
        _levelMeter.transform.localScale = levelScale;
    }


    // Regardless of mode, on DoSelect (i.e. trigger down) we want
    // to the level changing, so it's set on Trigger Unclick



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

        _triggerIsClicked = true;

    }

    void DoTriggerUnclicked()
    {

        _triggerIsClicked = false;

    }


}

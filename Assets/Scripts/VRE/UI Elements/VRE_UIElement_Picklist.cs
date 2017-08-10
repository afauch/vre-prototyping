using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_UIElement_Picklist : MonoBehaviour, VRE_IUIElement
{

    [Header("Picklist Properties]")]
    public GameObject _choicePrefab;
    public string[] _choiceStrings;
    public int _defaultChoiceIndex;
    private VRE_UIElement_PicklistChoice[] _choices;
    public VRE_UIElement_PicklistChoice _activeChoice;
    public TextMesh _activeChoiceText;
    public float _zOffset;

    public GameObject _gameObject { get; set; }
    public VRE_TransformSnapshot _defaultTransform { get; set; }
    public VRE_StateType _currentStateType { get; set; }
    public Dictionary<VRE_StateType, VRE_State> _states { get; set; }

    public bool _triggerIsClicked;
    [HideInInspector] public bool _isExpanded = false;

    // Use this for initialization
    void Start()
    {

        InitializeUIComponent();
        InitializeChoices();

    }


    private void InitializeChoices()
    {

        _choices = new VRE_UIElement_PicklistChoice[_choiceStrings.Length];

        for(int i = 0; i < _choiceStrings.Length; i++)
        {

            // Create a new GameObject
            GameObject g = GameObject.Instantiate(_choicePrefab);
            g.transform.SetParent(this.gameObject.transform);
            // Position it based on the Y Offset
            g.transform.localPosition = new Vector3(0.0f, 0.0f, ((i + 1) * _zOffset));
            g.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            g.transform.localRotation = Quaternion.identity;

            // Index the Choice component
            _choices[i] = g.GetComponent<VRE_UIElement_PicklistChoice>();
            _choices[i]._choiceIndex = i;
            // Set this as the picklist component
            _choices[i]._picklist = this;
            // Set the text based on the choice strings specified above
            _choices[i]._choiceText.text = _choiceStrings[i];
            // Disable
            g.SetActive(false);
            _isExpanded = false;

        }

        ChangeActiveChoice(_defaultChoiceIndex);

    }

    void ToggleExpanded(bool expand)
    {

        for(int i = 0; i < _choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(expand);
        }

        _isExpanded = !_isExpanded;


    }
	
    public void ChangeActiveChoice(int choiceIndex)
    {

        // Set the Active Choice text
        _activeChoiceText.text = _choices[choiceIndex]._choiceText.text;

        // Set active choice
        _activeChoice = _choices[choiceIndex];

        // Close the picklist
        ToggleExpanded(false);

    }

    // ==============================================================================================================
    // Typical UI behavior
    //

    /// <summary>
    /// Generic method for initializing this UI component
    /// </summary

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
        ToggleExpanded(!_isExpanded);

    }

    void DoTriggerUnclicked()
    {

        _triggerIsClicked = false;

    }



}

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

    public float _defaultLevel;
    public float _currentLevel;


	// Use this for initialization
	void Start () {


        

		
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
        float cursorRatio = cursorToBottom / topToBottom;

        Debug.Log(cursorRatio);

        // Change the level
        Vector3 levelScale = _levelMeter.transform.localScale;
        levelScale = new Vector3(levelScale.x, cursorRatio, levelScale.z);
        _levelMeter.transform.localScale = levelScale;
    }



}

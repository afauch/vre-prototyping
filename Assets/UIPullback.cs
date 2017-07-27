using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UIPullback : MonoBehaviour {

    VRTK_ControllerEvents _vrtkControllerEvents;

    public GameObject[] _UIGameObjects;
    public float _pullbackAmount;

    private float[] _defaultYPositions;
    private float[] _endYPositions;


    // Use this for initialization
    void Start()
    {

        // Subscribe to events
        _vrtkControllerEvents = _vrtkControllerEvents ?? this.gameObject.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);

        Debug.Log("Initializing Positions");
        _defaultYPositions = new float[_UIGameObjects.Length];
        _endYPositions = new float[_UIGameObjects.Length];


        // Initialize Positions
        for(int i = 0; i < _UIGameObjects.Length; i++)
        {
            _defaultYPositions[i] = _UIGameObjects[i].transform.localPosition.y;

            Debug.Log("_defaultYPositions-" + i + " = " + _defaultYPositions[i]);

            _endYPositions[i] = _UIGameObjects[i].transform.localPosition.y + _pullbackAmount;

            Debug.Log("_endYPositions-" + i + " = " + _endYPositions[i]);

        }




    }

    void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    {

        Debug.Log(e.buttonPressure);

        for(int i = 0; i < _UIGameObjects.Length; i++)
        {

            // Lerp position based on button pressure
            float _newY = Mathf.Lerp(_defaultYPositions[i], _endYPositions[i], e.buttonPressure);
            _UIGameObjects[i].transform.localPosition = new Vector3(
                _UIGameObjects[i].transform.localPosition.x,
                _newY,
                _UIGameObjects[i].transform.localPosition.z);

            // Debug.Log(g.name + (" will be moved."));
        }

    }

}

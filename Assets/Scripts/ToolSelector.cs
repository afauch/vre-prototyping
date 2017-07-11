using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolModeRevision
{
    v1,
    v2,
    v3
}

public enum LeftRight
{
    Left,
    Right
}

public class ToolSelector : MonoBehaviour {

    // Which mode are we in
    public ToolModeRevision _revision;
    [HideInInspector] public LeftRight _controller;

    public GameObject[] _toolModelsV1;
    public GameObject[] _toolModelsV2;
    public GameObject[] _toolModelsV3;

    [HideInInspector] public GameObject _toolLDefault;
    [HideInInspector] public GameObject _toolRDefault;

    public GameObject _lToolHolderParent;
    public GameObject _rToolHolderParent;
    public GameObject _toolHolderParent;


	// Use this for initialization
	void Start () {

        _toolHolderParent = _lToolHolderParent; // left by default
        Debug.Log(_toolHolderParent.gameObject.name);

        // Instantiate new tool
        switch (_revision)
        {
            case ToolModeRevision.v1:
                try
                {
                    _toolLDefault = GameObject.Instantiate(_toolModelsV1[0], _lToolHolderParent.transform);
                    _toolRDefault = GameObject.Instantiate(_toolModelsV1[1], _rToolHolderParent.transform);
                } catch
                {
                    Debug.Log("Error");
                }
                break;
            case ToolModeRevision.v2:
                try
                {
                    _toolLDefault = GameObject.Instantiate(_toolModelsV2[0], _lToolHolderParent.transform);
                    _toolRDefault = GameObject.Instantiate(_toolModelsV2[1], _rToolHolderParent.transform);
                }
                catch
                {
                    Debug.Log("Error");
                }
                break;
            case ToolModeRevision.v3:
                try
                {
                    _toolLDefault = GameObject.Instantiate(_toolModelsV3[0], _lToolHolderParent.transform);
                    _toolRDefault = GameObject.Instantiate(_toolModelsV3[1], _rToolHolderParent.transform);
                }
                catch
                {
                    Debug.Log("Error");
                }
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}


    public void SelectLeftController()
    {
        SelectController(LeftRight.Left);
    }

    public void SelectRightController()
    {
        SelectController(LeftRight.Right);
    }

    private void SelectController(LeftRight controller)
    {

        if(controller == LeftRight.Left)
        {
            _toolHolderParent = _lToolHolderParent;
        }

        if(controller == LeftRight.Right)
        {
            _toolHolderParent = _rToolHolderParent;
        }

    }

    public void SwitchToTool(int toolIndex)
    {
        // Destroy current tool
        foreach(Transform child in _toolHolderParent.transform)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new tool
        switch (_revision)
        {
            case ToolModeRevision.v1:
                GameObject.Instantiate(_toolModelsV1[toolIndex], _toolHolderParent.transform);
                break;
            case ToolModeRevision.v2:
                GameObject.Instantiate(_toolModelsV2[toolIndex], _toolHolderParent.transform);
                break;
            case ToolModeRevision.v3:
                GameObject.Instantiate(_toolModelsV3[toolIndex], _toolHolderParent.transform);
                break;
            default:
                break;
        }



    }

}

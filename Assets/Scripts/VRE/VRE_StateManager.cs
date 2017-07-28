using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_StateManager : MonoBehaviour {

    public static VRE_StateManager _instance;

    public bool _verbose = false;

    public bool _toolIsEquipped;

    public VRE_Tool[] _tools;
    public Dictionary<ToolType, VRE_Tool> _toolsByType;


    void Awake()
    {
        _instance = this;

        // Tool Initialization

    }

    private void Start()
    {

        // Set up for easy tool access
        _tools = gameObject.GetComponents<VRE_Tool>();
        _toolsByType = new Dictionary<ToolType, VRE_Tool>();
        for(int i = 0; i < _tools.Length; i++)
        {
            _toolsByType.Add(_tools[i]._toolType, _tools[i]);
        }

    }

    public void LoadTool(ToolType toolType)
    {



    }




}

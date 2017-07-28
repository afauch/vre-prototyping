using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_ToolButton : MonoBehaviour {

    public ToolType _toolType;

    void DoSelect()
    {

        VRE_StateManager._instance._toolsByType[_toolType].LoadTool();

    }

}

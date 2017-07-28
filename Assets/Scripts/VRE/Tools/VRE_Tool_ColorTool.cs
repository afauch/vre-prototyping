using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Tool_ColorTool : MonoBehaviour, VRE_ITool {

    public bool _laserDefaultOn { get; set; }
    public GameObject _token { get; set; }
    public VRE_ToolModel _toolModel { get; set; }

    public VRE_UIElement_Page[] _toolOptionPages { get; set; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface VRE_ITool {

    bool _laserDefaultOn { get; set; }
    GameObject _token { get; set; }
    VRE_ToolModel _toolModel { get; set; }

    VRE_Page[] _toolOptionPages { get; set; }

}

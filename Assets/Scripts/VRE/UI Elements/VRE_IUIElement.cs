using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public interface VRE_IUIElement {

    GameObject _gameObject { get; set; }
    VRE_TransformSnapshot _defaultTransform { get; set; }
    VRE_StateType _currentStateType { get; set; }
    Dictionary<VRE_StateType, VRE_State> _states { get; set; }

}

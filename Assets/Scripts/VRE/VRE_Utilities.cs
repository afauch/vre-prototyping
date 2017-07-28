using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Utilities : MonoBehaviour {

    public static VRE_Utilities _instance;

    void Awake()
    {
        _instance = this;
    }

    public void SetOpacity(GameObject g, float targetOpacity)
    {

        // For each child in transform
        foreach (Transform child in g.transform)
        {
            StartCoroutine(VRE_TweenHelper.OpacityFade(child.gameObject, targetOpacity, VRE_Globals._instance._fadeTime, "Linear", "_Color"));
            Debug.Log(child.gameObject.name);

        }

    }

}

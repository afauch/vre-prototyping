using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOverShoulder : MonoBehaviour {

    public static DetectOverShoulder _instance;

    public delegate void OverShoulder(Collider c);
    public event OverShoulder OnOverShoulder;

    void Awake()
    {
        _instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OverShoulder collision");
        if (OnOverShoulder != null)
        {
            OnOverShoulder(other);
        }
    }

}

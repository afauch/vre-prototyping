using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_ToolModel : MonoBehaviour {

    public GameObject _toolModel;
    public Transform _tokenSlot;

    void Start ()
    {
        Hide();
    }

    public void Hide()
    {
        _toolModel.SetActive(false);
    }

    public void ShowBaseModel()
    {
        _toolModel.SetActive(true);
    }

    public void ShowToken(GameObject g)
    {
        g.transform.SetParent(_tokenSlot);
        g.transform.localPosition = Vector3.zero;
        g.transform.localRotation = Quaternion.identity;
        g.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_ToolModel : MonoBehaviour {

    public GameObject _toolModel;
    public Transform _tokenSlot;
    public GameObject _currentToken;

    void Start ()
    {
        Hide();
    }

    void Update()
    {

        // Debug.Log("CurrentToken: " + _currentToken.name);

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

        Debug.Log("Equipping Token " + g.name);

        GameObject instance = GameObject.Instantiate(g);

        instance.transform.SetParent(_tokenSlot);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        instance.SetActive(true);

        _currentToken = instance;

    }

    public void DestroyToken()
    {

        Destroy(_currentToken);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTool : MonoBehaviour {

    public GameObject _toolParent;
    public ToolSelector _toolSelector;
    public GameObject _originPlaceholder;
    public LeftRight _lr;

    public bool _revertToDefault;
    private GameObject _toolDefault;

	// Use this for initialization
	void Start () {

        _toolDefault = _lr == LeftRight.Left ? _toolSelector._toolLDefault : _toolSelector._toolRDefault;

    }

    // Update is called once per frame
    void Update () {
    }

    public void StartDestroy ()
    {
        Debug.Log("DropTool Called");
        foreach(Transform child in _toolParent.transform)
        {
            child.SetParent(_originPlaceholder.transform);
            StartCoroutine(FallAndDestroy(child.gameObject));
        }

        if(_revertToDefault)
        {
            GameObject.Instantiate(_toolDefault, _toolParent.transform);
        }

    }

    public IEnumerator FallAndDestroy(GameObject g)
    {
        g.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(2.0f);
        Destroy(g.gameObject);
        yield return null;
    }

}

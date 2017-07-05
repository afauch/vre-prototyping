using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTool : MonoBehaviour {

    public GameObject _toolParent;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
    }

    public void StartDestroy ()
    {
        Debug.Log("DropTool Called");
        foreach(Transform child in _toolParent.transform)
        {
            StartCoroutine(FallAndDestroy(child.gameObject));
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

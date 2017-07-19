using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockToWorldSpace : MonoBehaviour {

    public GameObject _originPlaceholder;

    public void Dock()
    {
        Debug.Log("DOCK CALLED ON " + this.gameObject.name);
        this.gameObject.transform.SetParent(_originPlaceholder.transform);
        Debug.Log("Parent set to " + this.transform.parent.gameObject.name);
    }

}

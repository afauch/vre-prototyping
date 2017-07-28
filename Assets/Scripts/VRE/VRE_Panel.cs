using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Panel : MonoBehaviour {

    public VRE_UIElement_Page _currentPage;

    public void ChangePageTo(VRE_UIElement_Page page)
    {

        _currentPage._gameObject.SetActive(false);
        page._gameObject.SetActive(true);

    }

}

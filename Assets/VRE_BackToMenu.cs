using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_BackToMenu : MonoBehaviour {

    public VRE_Panel _panel;

    void DoSelect()
    {

        _panel.ChangePageTo(0);

    }   



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public enum ToolType
{
    Color,
    Material,
    Clone,
    Group,
    Stretch,
    Delete
}

public class VRE_Tool : MonoBehaviour {

    public ToolType _toolType;

    public bool _laserDefaultOn;
    public bool _grabEnabled;
    public GameObject _token;
    // public VRE_UIElement_Page[] _toolOptionPages;
    public int _toolPageIndex;

    public void LoadTool()
    {

        // Is the base model loaded onto the right hand?
        if (!VRE_StateManager._instance._toolIsEquipped)
        {
            // If not, load it
            VRE_Globals._instance._toolModel.ShowBaseModel();

        }

        // Add the token to the RH tool model
        VRE_Globals._instance._toolModel.ShowToken(_token);

        // Load up all pages in the panel
        // VRE_Globals._instance._toolPanel._pages = _toolOptionPages;
        // Change the panel to the correct page
        VRE_Globals._instance._toolPanel.ChangePageTo(_toolPageIndex);

        // Turn on the laser if necessary
        if(_laserDefaultOn)
            VRE_Globals._instance._toolPointer.GetComponent<VRTK_StraightPointerRenderer>().enabled = true;

        if (!_grabEnabled)
            VRE_Globals._instance._grabPointer.SetActive(false);

        VRE_StateManager._instance._toolIsEquipped = true;

    }


    void ToolPrimaryAction(GameObject recipient)
    {

    }

}

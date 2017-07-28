using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ToolType
{
    Color,
    Clone,
    Stretch,
    Physics
}

public class VRE_Tool : MonoBehaviour {

    public ToolType _toolType;
    public int _toolIndex;

    public bool _laserDefaultOn;
    public GameObject _token;
    public VRE_UIElement_Page[] _toolOptionPages;

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

        // Change the panel to the correct page
        VRE_Globals._instance._toolPanel.ChangePageTo(_toolOptionPages[0]);

        // Turn on the laser if necessary
        if(_laserDefaultOn)
        {
            // TODO: Turn on laser here
        }

        VRE_StateManager._instance._toolIsEquipped = true;

    }


    void ToolPrimaryAction(GameObject recipient)
    {

    }

}

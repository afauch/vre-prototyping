using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class VRE_StateManager : MonoBehaviour {

    public static VRE_StateManager _instance;

    public bool _verbose = false;

    public bool _toolIsEquipped;

    public VRE_Tool[] _tools;
    public Dictionary<ToolType, VRE_Tool> _toolsByType;

    public VRTK_ControllerEvents _vrtkControllerEvents;


    void Awake()
    {
        _instance = this;

        // Tool Initialization

    }

    private void Start()
    {

        // Subscribe to Grip Event
        _vrtkControllerEvents = VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_ControllerEvents>();
        _vrtkControllerEvents.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);

        // Set up for easy tool access
        _tools = gameObject.GetComponents<VRE_Tool>();
        _toolsByType = new Dictionary<ToolType, VRE_Tool>();
        for (int i = 0; i < _tools.Length; i++)
        {
            _toolsByType.Add(_tools[i]._toolType, _tools[i]);
        }

        // Disable Pointer
        // VRE_Globals._instance._rightHandControllerEvents.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;


    }

    private void Update()
    {
        // Debug.Log(_toolIsEquipped);
    }

    public void LoadTool(ToolType toolType)
    {



    }

    public void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {

        if (_toolIsEquipped)
        {
            DropTool();
        }

        _toolIsEquipped = false;

    }

    public void DropTool()
    {

        // Haptic Pulse
        VRE_Utilities.TriggerHapticPulse(Hand.Right, 0.5f);

        // Destroy Token Instance
        VRE_Globals._instance._toolModel.DestroyToken();

        // Reset Page
        VRE_Globals._instance._toolPanel.ChangePageTo(0);

        VRE_Globals._instance._toolPointer.GetComponent<VRTK_StraightPointerRenderer>().enabled = false;


    }




}

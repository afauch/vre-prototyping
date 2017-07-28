using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VRE_ScrollDirection
{
    Back,
    Forward
}

public class VRE_ScrollButton : MonoBehaviour {

    public VRE_UIElement_ButtonComponent _buttonComponent = null;
    public VRE_Panel _panel;
    private int _panelPageLength;
    public VRE_ScrollDirection _scrollDirection;

    private void Start()
    {

        if (_buttonComponent == null)
            _buttonComponent = gameObject.GetComponent<VRE_UIElement_ButtonComponent>();

        SetButtonStatesBasedOnPageLength();


    }

    private void SetButtonStatesBasedOnPageLength()
    {

        // Check the panel and see if there's anything to scroll
        _panelPageLength = _panel._pages.Length;
        if (_panelPageLength == 1) ;
        VRE_Utilities._instance.ChangeStates(_buttonComponent, VRE_StateType.Default);

    }

    public void DoSelect()
    {

        if(_scrollDirection == VRE_ScrollDirection.Back)
        {

            // is this the first page?
            if(_panel._currentPageIndex == 0)
            {
                Debug.Log("First page, nowhere to scroll.");
            } else
            {
                _panel.PageBack();
            }


        }

        if (_scrollDirection == VRE_ScrollDirection.Forward)
        {

            // is this the last page?
            if (_panel._currentPageIndex == (_panelPageLength - 1))
            {
                Debug.Log("Last page, nowhere to scroll.");
            } else
            {
                _panel.PageForward();
            }

        }


    }

}

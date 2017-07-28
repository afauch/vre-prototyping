using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRE_Panel : MonoBehaviour {

    // public VRE_UIElement_Page _defaultPage;
    [HideInInspector] public VRE_UIElement_Page _currentPage;
    public VRE_UIElement_Page[] _pages;
    public int _currentPageIndex;


    void Start()
    {

        InitializePages();

    }

    public void ChangePageTo(VRE_UIElement_Page page)
    {

        Debug.Log("ChangePageTo called");

        _currentPage._gameObject.SetActive(false);
        page._gameObject.SetActive(true);

        _currentPage = page;
        _currentPageIndex = page._pageIndex;

    }

    public void ChangePageTo(int pageIndex)
    {

        Debug.Log("ChangePageTo called");

        _currentPage._gameObject.SetActive(false);
        _pages[pageIndex]._gameObject.SetActive(true);

        _currentPage = _pages[pageIndex];
        _currentPageIndex = pageIndex;

    }


    public void PageForward()
    {

        _currentPage._gameObject.SetActive(false);
        _pages[_currentPageIndex + 1]._gameObject.SetActive(true);

        _currentPage = _pages[_currentPageIndex + 1];
        _currentPageIndex += 1;

    }

    public void PageBack()
    {

        _currentPage._gameObject.SetActive(false);
        _pages[_currentPageIndex - 1]._gameObject.SetActive(true);

        _currentPage = _pages[_currentPageIndex - 1];
        _currentPageIndex -= 1;

    }

    public void InitializePages()
    {

        // Run through all the pages and activate the first one
        for(int i = 0; i < _pages.Length; i++)
        {
            _pages[i]._gameObject.SetActive(false);
        }

        _pages[0]._gameObject.SetActive(true);


        _currentPage = _pages[0];
        _currentPageIndex = 0;


    }

}

using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    [SerializeField] private bool _onEnableOpenFirstPage = false;
    [SerializeField] private List<Page> _pages;
    [SerializeField] private SlideShowController _slideShowController;

    private void OnEnable()
    {
        if (_onEnableOpenFirstPage)
            OpenPage(0);
    }
    
    public void OpenPage(int pageIndex)
    {
        foreach (Page page in _pages)
        {   
            if(page.gameObject.activeInHierarchy)
                page.ClosePage();
        }

        _pages[pageIndex].gameObject.SetActive(true);
        _pages[pageIndex].OpnePage();

        if(_slideShowController != null) 
            _slideShowController.OpenSlideShow(pageIndex);
    }
}

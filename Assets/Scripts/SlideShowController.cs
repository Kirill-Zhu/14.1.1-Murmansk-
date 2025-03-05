using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShowController : MonoBehaviour
{
    [SerializeField] private Image _slideShowImage;

    [SerializeField] private List<Sprite> _page0;
    [SerializeField] private List<Sprite> _page1;
    [SerializeField] private List<Sprite> _page2;
    [SerializeField] private List<Sprite> _page3;
    [SerializeField] private List<Sprite> _page4;
    [SerializeField] private List<Sprite> _page5;
    [SerializeField] private List<Sprite> _page6;
    [SerializeField] private List<Sprite> _page7;
    [SerializeField] private List<Sprite> _page8;
    [SerializeField] private List<Sprite> _page9;
    [SerializeField] private List<Sprite> _page10;
    [SerializeField] private List<Sprite> _page11;
    [SerializeField] private List<Sprite> _page12;
    [SerializeField] private List<Sprite> _page13;
    [SerializeField] private List<Sprite> _page14;
    [SerializeField] private List<Sprite> _page15;
    [SerializeField] private List<Sprite> _page16;
    [SerializeField] private List<Sprite> _page17;
    [SerializeField] private List<Sprite> _page18;
    [SerializeField] private List<Sprite> _page19;
    [SerializeField] private List<Sprite> _page20;

    private List<List<Sprite>> _lists;
    private List<Sprite> _currentList;
    private Coroutine _coroutine;
    private int _currentSpirteIndex=0;
    private float _slideShowSpeed = 3f;
    private float _changeSlideSpeed=0.03f;
    private void Awake()
    {
        _lists = new List<List<Sprite>>(20);
        _lists.Add(_page0); 
        _lists.Add(_page1);
        _lists.Add(_page2);
        _lists.Add(_page3);
        _lists.Add(_page4);
        _lists.Add(_page5);
        _lists.Add(_page6);
        _lists.Add(_page7);
        _lists.Add(_page8);
        _lists.Add(_page9);
        _lists.Add(_page10);    
        _lists.Add(_page11);    
        _lists.Add(_page12);    
        _lists.Add(_page13);
        _lists.Add(_page14);
        _lists.Add(_page15);
        _lists.Add(_page16);
        _lists.Add(_page17);
        _lists.Add(_page18);
        _lists.Add(_page19);
        _lists.Add(_page20);

    }
    public void OpenSlideShow(int index)
    {

        StopAllCoroutines();

        if (_currentList != null)
            _currentList.Clear();
        
        _currentList = new List<Sprite>(_lists[index].Count);
        for(int i = 0; i < _lists[index].Count; i++)
        {
            _currentList.Add(_lists[index][i]);

        }

        
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
      
        _coroutine = StartCoroutine(StartSlideShow());

    }
    private IEnumerator StartSlideShow()
    {
        
        StartCoroutine(ChangeSprite());
        if (_currentList.Count < 2)
            yield break;

        yield return new WaitForSeconds(_slideShowSpeed);
        if(_currentList.Count >0)
            _coroutine = StartCoroutine(StartSlideShow());
        
    }
    private IEnumerator ChangeSprite()
    {
       

        if(_slideShowImage!=null)
        {
            for(float i = 20; i > 0;i--)
            {

                _slideShowImage.color = new Color(1, 1, 1,  i/20);
                yield return new WaitForSeconds(_changeSlideSpeed);

            }
        }
        _currentSpirteIndex++;
        try
        {         
            _slideShowImage.sprite = _currentList[_currentSpirteIndex];
           
            _slideShowImage.SetNativeSize();
        }
        catch 
        {
            _currentSpirteIndex = 0;
            _slideShowImage.sprite = _currentList[_currentSpirteIndex];
            _slideShowImage.SetNativeSize();
        }
        Debug.Log("Displa 2 current image index : "+  _currentSpirteIndex);
        
        if (_slideShowImage != null)
        {
            for (float i = 1; i < 21; i++)
            {

                _slideShowImage.color = new Color(1, 1, 1, i / 20);
                yield return new WaitForSeconds(_changeSlideSpeed);

            }
        }

    }
}

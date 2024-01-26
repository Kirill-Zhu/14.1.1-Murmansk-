using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

[RequireComponent(typeof(CanvasGroup))]
public class Page : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private float _speed = 0.15f;

    private Coroutine _coroutine;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    [ContextMenu("ClosePage")]
    public void ClosePage()
    {
        if(_coroutine != null )
            StopCoroutine(_coroutine );

        

        _coroutine = StartCoroutine(FadeOutAndClose());
        
    }
    [ContextMenu("OpenPage")]
    public void OpnePage()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(FadeIn());
    }
    private IEnumerator FadeOutAndClose() 
    {
        for (int i=0; i<20; i++)
        {
            if(_canvasGroup.alpha>0)            
                _canvasGroup.alpha -= _speed;
           
            yield return new WaitForSeconds(0.05f);
            
            if(_canvasGroup.alpha <= 0) 
                break;
                
        }
        
        if(_canvasGroup.alpha<0)
            _canvasGroup.alpha=0;

        StopCoroutine(_coroutine);
        _coroutine = null;
        this.gameObject.SetActive(false);

    }
    private IEnumerator FadeIn()
    {
        for (int i = 0; i < 20; i++)
        {
            if (_canvasGroup.alpha < 1)
                _canvasGroup.alpha += _speed;

            yield return new WaitForSeconds(0.05f);

            if (_canvasGroup.alpha >= 1)
                break;

        }

        if (_canvasGroup.alpha > 1)
            _canvasGroup.alpha = 1;

        StopCoroutine(_coroutine);
        _coroutine = null;
    }
}

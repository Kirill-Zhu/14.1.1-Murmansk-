using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerHandler : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;

    private void OnDisable()=>_scrollRect.normalizedPosition = new Vector2(0,1);
    
}

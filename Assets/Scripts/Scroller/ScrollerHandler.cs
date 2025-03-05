using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerHandler : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;

    private async void OnEnable() {
        await Task.Delay(50);
        _scrollRect.normalizedPosition = new Vector2(0, 1);
    }
    
}

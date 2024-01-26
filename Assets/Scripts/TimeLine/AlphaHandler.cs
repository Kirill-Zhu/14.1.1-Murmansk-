using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlphaHandler : MonoBehaviour
{
    [SerializeField] private Color _highlitedColor;
    [SerializeField] private Color _normalColor;
    [SerializeField] private float _alphaChangeRange = 100f;
    [SerializeField] private List<CanvasGroup> _canvasGroupList;
    private RectTransform _rectTransfrom;
    private Vector3 _position;
    private void Start()
    {
        _rectTransfrom = GetComponent<RectTransform>();
        _rectTransfrom.GetPositionAndRotation(out _position, out Quaternion rotation);
 
    }
  

    public void CahngeAlpha()
    {
        foreach (CanvasGroup canvasGroup in _canvasGroupList)
        {
            Vector3 tmpPos;
            canvasGroup.gameObject.GetComponent<RectTransform>().GetPositionAndRotation(out tmpPos, out Quaternion tmpRotation);
            float difference = Mathf.Abs(_position.x - Mathf.Abs(tmpPos.x));
            if (difference > _alphaChangeRange)
                continue;
            

            canvasGroup.alpha = Mathf.InverseLerp(_alphaChangeRange, 0, difference);
            
            if (difference < 60f)
            {
                canvasGroup.GetComponent<TextMeshProUGUI>().color = _highlitedColor;
                canvasGroup.GetComponent<TextMeshProUGUI>().fontSize = 96;
            }
            else
            {
                canvasGroup.GetComponent<TextMeshProUGUI>().color = _normalColor;
                canvasGroup.GetComponent<TextMeshProUGUI>().fontSize = 64;
            }

        }
    }
}

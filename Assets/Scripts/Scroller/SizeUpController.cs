using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeUpController : MonoBehaviour
{
    [SerializeField] private List<Sprite> _spriteList;
    [SerializeField] private Image _image;
    public void SizeUpImage(int index)
    {
        _image.sprite = _spriteList[index];
        _image.SetNativeSize();
    }
  
}

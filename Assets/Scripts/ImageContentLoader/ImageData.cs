using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImageData: MonoBehaviour
{
    public string imagePath;
    [SerializeField] private ImageManagerAlter _imageManager;
    private Button _button;
    
    private void Awake() {
        _button = GetComponent<Button>();
        _imageManager = transform.GetComponentInParent<ImageManagerAlter>();
        _button.onClick.AddListener(()=>_imageManager.SelectImage(this.gameObject));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageListenScale : MonoBehaviour
{
   public static ImageListenScale Instance { get; private set; }
    private Image _image;
    private void Start() {
        _image = GetComponent<Image>();

        Instance = this;
    }
    public void Shit() {

        _image.color = Color.red;
        Debug.Log("Shit");
    }
}

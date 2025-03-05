using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SliderHandleResizer : MonoBehaviour
{
    private Image _handleImage;

    private async void OnEnable() {
        await Task.Delay(50);
        Resieze();
    }
    public void Resieze() {
        _handleImage = GetComponent<Image>();
        _handleImage.SetNativeSize();
    }
}

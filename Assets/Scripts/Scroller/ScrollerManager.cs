using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerManagerNew : MonoBehaviour {

    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private List<Sprite> _contentSprites;
    [SerializeField] private Transform _contentTransform;
    [SerializeField] private GameObject _imagePrefab;

    private void Start() {
        InstantiateImages();
    }
    private void OnEnable() => _scrollRect.normalizedPosition = new Vector2(0, 1);

    [ContextMenu("Add Images")]
    private void InstantiateImages() {

        if (_contentSprites.Count ==0)
            return;


        for(int i =0; i < _contentSprites.Count; i++) {
            GameObject tmpObj = Instantiate(_imagePrefab,_contentTransform);
            tmpObj.transform.name = "Image " + transform.GetSiblingIndex();
            Image img = tmpObj.GetComponent<Image>();
            img.sprite = _contentSprites[i];
            img.SetNativeSize();
        }
    }
}

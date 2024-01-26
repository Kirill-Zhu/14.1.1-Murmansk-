using UnityEngine;
using TMPro;
[RequireComponent(typeof(TextMeshProUGUI))]
public class TextBoxHandler : MonoBehaviour
{
    [TextArea(2, 3)]
    [SerializeField] private string _onEnableText;
    private TextMeshProUGUI _textMesh;
    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }
    public void SetThisTextBoxAsActive()
    {
        if (_textMesh.text == _onEnableText)
            _textMesh.text = null;
      
        if (KeyBoardManager.Instance != null)
            KeyBoardManager.Instance.SetTextBox(_textMesh);
    }

    private void OnEnable() => _textMesh.text = _onEnableText;
    
}

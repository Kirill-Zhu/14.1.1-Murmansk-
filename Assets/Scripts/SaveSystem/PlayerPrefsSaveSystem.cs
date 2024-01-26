using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPrefsSaveSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    [ContextMenu("Save")]
    public void Save()
    {
        PlayerPrefs.SetString("Test KeyBorad", _textMesh.text);
        PlayerPrefs.Save();
        Debug.Log("Save Game");
    }
    [ContextMenu("Load")]
    public void LoadGame() {

        _textMesh.text = PlayerPrefs.GetString("Test KeyBorad");
        Debug.Log("Load Game");
    }
}

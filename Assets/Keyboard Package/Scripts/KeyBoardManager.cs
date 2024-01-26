
using TMPro;
using UnityEngine;

public class KeyBoardManager : MonoBehaviour
{
    public static KeyBoardManager Instance;
    [SerializeField] TextMeshProUGUI textBox;
  

    private void Awake()
    {
        if(Instance != null)
            Destroy(this.gameObject);
        else
            Instance = this;
              
        textBox.text = "";
    }

    public void DeleteLetter()
    {
        if (textBox.text.Length != 0)
        {
            textBox.text = textBox.text.Remove(textBox.text.Length - 1, 1);
        }
    }
    public void Space()
    {
        textBox.text += " ";    
    }
    public void AddLetter(string letter)
    {
        textBox.text = textBox.text + letter;
    }

    public void SetTextBox(TextMeshProUGUI textMesh)
    {
        textBox = textMesh;
    }
    public void SubmitWord()
    {
        //Стартовая версия кнопки Enter 
        //printBox.text = textBox.text;
        //textBox.text = "";
        // Debug.Log("Text submitted successfully!");

        // Enter - новая строка
        textBox.text += "\n";
      
    }
}

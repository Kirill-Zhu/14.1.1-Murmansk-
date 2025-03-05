using UnityEngine;
using System.IO;
using TMPro;
using System;
using System.Net.NetworkInformation;

public class JsonSaveSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _text;


    [ContextMenu("Save")]
    public void SaveToJson()
    {
        JsonSaveData data = new JsonSaveData();
        data.Name = _name.text;
        data.Text = _text.text;

        if (!Directory.Exists(Application.dataPath+ "/Pozhelaniya"))
            Directory.CreateDirectory(Application.dataPath + "/Pozhelaniya");

        string fileName = Application.dataPath + String.Format("/Pozhelaniya/ {0}", _name.text);
        string json = JsonUtility.ToJson(data,true);

        CheckName(ref fileName);
          
            
        File.WriteAllText(fileName, json);
    }

    private void CheckName(ref string name)
    {
        for(int i =2; i < 100; i++)
        {
            if (i == 2)
            {
                if (File.Exists(name))
                {
                    char[] chars = name.ToCharArray();
                    char downDefis = '_';
                    chars[chars.Length - 1] = downDefis;
                    name = new string(chars);
                    name += i;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (File.Exists(name))
                {
                    char[] chars = name.ToCharArray();
                    string number = Convert.ToString(i);
                    chars[chars.Length - 1] = number[0];
                    name = new string(chars);                    
                }
                else
                {
                    return;
                }
            }
        }

    }
}

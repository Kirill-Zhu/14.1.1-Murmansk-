using NaughtyAttributes;
using SFB;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ImageManagerAlter : MonoBehaviour
{

    [SerializeField] private string _fileName;
    public GameObject imagePrefab; // ������ ��� �����������
    public Transform scrollViewContent; // ��������� ��� ����������� � ScrollView

    public List<string> imagePaths = new List<string>(); // ������ ����������� �����������
    public GameObject selectedImage; // ��������� ����������� ��� ��������

  

    private async void Start()
    {
       await Task.Delay(200);
        LoadImages(); // ��������� ����������� ��� ������
    }
    private void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) LoadImage();

        if (Input.GetKeyDown(KeyCode.Delete)) RemoveSelectedImage();
    }
    [Button("Load Image")]
    public void LoadImage()
    {
        var extensions = new[] {
            new ExtensionFilter("Images", "jpg", "png", "jpeg")
        };
        // ��������� ������ ������ ������
        string[] paths = StandaloneFileBrowser.OpenFilePanel("������ ������ ��������", "", extensions, false);
        if (paths.Length > 0)
        {
            foreach (string path in paths)
            {
                AddImage(path); // ��������� �����������
            }
        }
    }

    private void AddImage(string path)
    {
        GameObject newImage = Instantiate(imagePrefab, scrollViewContent); // ������� ����� Image
        var imageComponent = newImage.GetComponent<Image>();

        // ��������� �������� �� �����
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // ��������� ���� � ����������� � ����������
        var imageData = newImage.AddComponent<ImageData>();
        imageData.imagePath = path;

        // ��������� ���� � ����������� � ������
        imagePaths.Add(path);
        SaveImages(); // ��������� ����
        imageComponent.SetNativeSize();
    }

    public void SelectImage(GameObject image)
    {
        // ����� �����������
        if (selectedImage != null)
        {
            // ������� ��������� � ����������� �����������
            selectedImage.GetComponent<Image>().color = Color.white;
        }

        selectedImage = image;
        // ����������, ��� ����������� ������� (��������, ������ ����)
        selectedImage.GetComponent<Image>().color = Color.yellow;
    }

    public void RemoveSelectedImage()
    {
        if (selectedImage != null)
        {
            string pathToRemove = selectedImage.GetComponent<ImageData>().imagePath;
            imagePaths.Remove(pathToRemove); // ������� ���� �� ������
            Destroy(selectedImage); // ������� ������ �� ScrollView
            selectedImage = null; // ���������� �����

            SaveImages(); // ��������� ���������
        }
    }

    private void SaveImages()
    {
        string path = Application.persistentDataPath + _fileName;
        File.WriteAllLines(path, imagePaths); // ��������� ���� � ��������� ����
    }

    private void LoadImages()
    {
        string path = Application.persistentDataPath  + _fileName;
        if (File.Exists(path))
        {
            string[] paths = File.ReadAllLines(path);
            foreach (string imgPath in paths)
            {
                AddImage(imgPath); // ��������� ����������� �� �����
            }
        }
    }
}

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
    public GameObject imagePrefab; // Префаб для изображений
    public Transform scrollViewContent; // Контейнер для изображений в ScrollView

    public List<string> imagePaths = new List<string>(); // Список загруженных изображений
    public GameObject selectedImage; // Выбранное изображение для удаления

  

    private async void Start()
    {
       await Task.Delay(200);
        LoadImages(); // Загружаем изображения при старте
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
        // Открываем диалог выбора файлов
        string[] paths = StandaloneFileBrowser.OpenFilePanel("Выбери нужную картинку", "", extensions, false);
        if (paths.Length > 0)
        {
            foreach (string path in paths)
            {
                AddImage(path); // Добавляем изображение
            }
        }
    }

    private void AddImage(string path)
    {
        GameObject newImage = Instantiate(imagePrefab, scrollViewContent); // Создаем новый Image
        var imageComponent = newImage.GetComponent<Image>();

        // Загружаем текстуру из файла
        byte[] fileData = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);
        imageComponent.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // Сохраняем путь к изображению в компоненте
        var imageData = newImage.AddComponent<ImageData>();
        imageData.imagePath = path;

        // Добавляем путь к изображению в список
        imagePaths.Add(path);
        SaveImages(); // Сохраняем пути
        imageComponent.SetNativeSize();
    }

    public void SelectImage(GameObject image)
    {
        // Выбор изображения
        if (selectedImage != null)
        {
            // Убираем выделение с предыдущего изображения
            selectedImage.GetComponent<Image>().color = Color.white;
        }

        selectedImage = image;
        // Отображаем, что изображение выбрано (например, меняем цвет)
        selectedImage.GetComponent<Image>().color = Color.yellow;
    }

    public void RemoveSelectedImage()
    {
        if (selectedImage != null)
        {
            string pathToRemove = selectedImage.GetComponent<ImageData>().imagePath;
            imagePaths.Remove(pathToRemove); // Удаляем путь из списка
            Destroy(selectedImage); // Удаляем объект из ScrollView
            selectedImage = null; // Сбрасываем выбор

            SaveImages(); // Сохраняем изменения
        }
    }

    private void SaveImages()
    {
        string path = Application.persistentDataPath + _fileName;
        File.WriteAllLines(path, imagePaths); // Сохраняем пути в текстовый файл
    }

    private void LoadImages()
    {
        string path = Application.persistentDataPath  + _fileName;
        if (File.Exists(path))
        {
            string[] paths = File.ReadAllLines(path);
            foreach (string imgPath in paths)
            {
                AddImage(imgPath); // Загружаем изображения из файла
            }
        }
    }
}

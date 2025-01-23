using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEnterName : MonoBehaviour
{
    public GameObject mainMenuButtons;
    public Button reset;
    public Button confirm;
    public TMP_InputField name;

    void Start()
    {
        reset.onClick.AddListener(Reset);
        confirm.onClick.AddListener(Confirm);
    }

    private void Reset()
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        name.text = "";
    }

    private void Confirm()
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        if(string.IsNullOrWhiteSpace(name.text.ToString()) || name.text.ToString().Contains(" ") || name.text.ToString().Count() > 12)
        {
            Reset();
        }
        else
        {
            SaveToFile(Application.persistentDataPath + "/saveName.xml", name.text.ToString());
            gameObject.SetActive(false);
            mainMenuButtons.SetActive(true);
            string test = LoadFromFile(Application.persistentDataPath + "/saveName.xml");
            Debug.Log(test);
        }
    }

    public void SaveToFile(string filePath, string content)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(string));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, content);
        }
    }

    public string LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(string));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (string)serializer.Deserialize(reader);
            }
        }
        else
        {
            gameObject.SetActive(true);
            return "";
        }
    }
}

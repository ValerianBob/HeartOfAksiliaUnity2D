using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _notificationText;

    public GameObject notification;

    private Image image;

    private Queue<string> _notifications = new Queue<string>();

    private float _alphaValue = 0.70588f;
    private float _alphaValueText = 1f;

    public static NotificationsController Instance { get; private set; }

    private void Start()
    {
        image = notification.GetComponent<Image>();
        AddNewMessage("Game Start!!!", "#008000");
    }

    private void Update()
    {
        if(_alphaValue == 0)
        {
            StopAllCoroutines();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewMessage(string message,string color)
    {
        StopAllCoroutines();
        _alphaValue = 0.70588f;
        _alphaValueText = 1f;
        SetTransparency(0.70588f);
        SetTextTransparency(1f);

        _notifications.Enqueue($"<color={color}>{message}</color>" + "\n");

        if(_notifications.Count > 6)
        {
            _notifications.Dequeue();
            _notificationText.text = "";
            foreach (var item in _notifications)
            {
                _notificationText.text += item;
            }
        }
        else
        {
            _notificationText.text = "";
            foreach (var item in _notifications)
            {
                _notificationText.text += item;
            }
        }

        StartCoroutine(WaitForThreeSeconds());
    }

    IEnumerator WaitForThreeSeconds()
    {
        yield return new WaitForSeconds(3f);

        StartCoroutine(ClearPanel());
        StartCoroutine(FadeOutText());
    }

    IEnumerator ClearPanel()
    {
        for (int i = 0; i < 50; i++)
        {
            _alphaValue -= 0.035294f;
            SetTransparency(_alphaValue);

            yield return new WaitForSeconds(0.075f);
        }
    }

    public void SetTransparency(float alpha)
    {
        Color color = image.color;        
        color.a = Mathf.Clamp01(alpha);  
        image.color = color;             
    }

    IEnumerator FadeOutText()
    {
        for (int i = 0; i < 50; i++)
        {
            _alphaValue -= 0.035294f;
            SetTextTransparency(_alphaValue);

            yield return new WaitForSeconds(0.075f);
        }
    }

    public void SetTextTransparency(float alpha)
    {
        Color color = _notificationText.color;
        color.a = Mathf.Clamp01(alpha); 
        _notificationText.color = color;     
    }

}

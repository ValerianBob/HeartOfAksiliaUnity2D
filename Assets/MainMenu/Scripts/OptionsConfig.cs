using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsConfig : MonoBehaviour
{
    public static OptionsConfig Instance;

    public float sound = 0.5f;
    public float cameraSize = 10f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

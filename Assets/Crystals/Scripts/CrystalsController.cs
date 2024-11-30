using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalsController : MonoBehaviour
{
    public static CrystalsController Instance { get; private set; }

    public int crystals;
    public int orangeCrystals;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}

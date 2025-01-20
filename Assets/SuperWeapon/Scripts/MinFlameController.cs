using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinFlameController : MonoBehaviour
{
    void Update()
    {
        Invoke(nameof(DeleteMinFlame), 0.2f);
    }

    private void DeleteMinFlame()
    {
        Destroy(gameObject);
    }
}

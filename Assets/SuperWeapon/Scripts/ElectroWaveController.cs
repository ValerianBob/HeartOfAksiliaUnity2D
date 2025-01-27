using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroWaveController : MonoBehaviour
{
    void Update()
    {
        Invoke(nameof(DeleteElectroWave), 0.2f);
    }

    private void DeleteElectroWave()
    {
        Destroy(gameObject);
    }
}

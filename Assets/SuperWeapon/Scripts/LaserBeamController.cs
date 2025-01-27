using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamController : MonoBehaviour
{
    void Update()
    {
        Invoke(nameof(DeleteLaserBeam), 0.2f);
    }

    private void DeleteLaserBeam()
    {
        Destroy(gameObject);
    }
}

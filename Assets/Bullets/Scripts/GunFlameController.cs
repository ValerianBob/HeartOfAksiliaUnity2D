using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlameController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public BerretaController berretaFlame;
    
    public ShotGunController shotGunController;

    public MacShotController macShotControllerFlame;

    public PechenegController pechenegController;

    public AKController ak;

    public GrozaController grozaController;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.enabled = false;
    }

    void LateUpdate()
    {
        if (berretaFlame.fire == true || macShotControllerFlame.fire == true)
        {
            transform.localPosition = new Vector3(0.7f, -0.13f, -2f);
        }
        else if (shotGunController.fire == true)
        {
            transform.localPosition = new Vector3(0.75f, -0.09f, -2f);
        }
        else if (pechenegController.fire == true)
        {
            transform.localPosition = new Vector3(1.2f, -0.075f, -2f);
        }
        else if (ak.fire == true)
        {
            transform.localPosition = new Vector3(0.95f, -0.13f, -2f);
        }
        else if (grozaController.fire == true)
        {
            transform.localPosition = new Vector3(0.777f, -0.118f, -2f);
        }

        if (berretaFlame.fire || shotGunController.fire || macShotControllerFlame.fire || pechenegController.fire || ak.fire || grozaController.fire)
        {
            spriteRenderer.enabled = true;
            Invoke(nameof(HideGunFlame), 0.1f);
        }
    }

    private void HideGunFlame()
    {
        spriteRenderer.enabled = false;

        berretaFlame.fire = false;
        shotGunController.fire = false;
        macShotControllerFlame.fire = false;
        pechenegController.fire = false;
        ak.fire = false;
        grozaController.fire = false;
    }
}



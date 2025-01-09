using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MineController : MonoBehaviour
{
    private ShopController shopController;

    private SpriteRenderer spriteRenderer;

    private Material mat;

    private Color color;
    public Color canNotBuildBlockColor;
    public Color canBuildColor;

    Vector3 mouseScreenPosition;
    Vector3 mouseWorldPosition;

    public bool isPlacing = true;
    private bool cantPlacHere = false;

    void Start()
    {
        shopController = GameObject.Find("Buildings").transform.GetChild(0).GetComponent<ShopController>();
        shopController.cantOpenWhilePlacingSuperWeapon = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;
    }

    void Update()
    {
        mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.nearClipPlane;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        if (isPlacing)
        {
            transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, -1);
        }

        if (Input.GetMouseButtonDown(1) && isPlacing && !cantPlacHere)
        {
            isPlacing = false;
            shopController.cantOpenWhilePlacingSuperWeapon = false;

            spriteRenderer = GetComponent<SpriteRenderer>();
            color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;

            SoundsController.Instance.PlayBuildsSound(0);
        }
    }

    public void ChangeBuildBlockColor(Color newColor)
    {
        mat = spriteRenderer.material;

        mat.color = new Color(newColor.r, newColor.g, newColor.b);

        spriteRenderer.material.color = new Color(newColor.r, newColor.g, newColor.b);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Build") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
        if (collision.gameObject.CompareTag("Kaylo") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
        if (collision.gameObject.CompareTag("Bush") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
        if (collision.gameObject.CompareTag("Rock") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
        if (collision.gameObject.CompareTag("Enemy") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
        if (collision.gameObject.CompareTag("Mine") && isPlacing)
        {
            cantPlacHere = true;
            ChangeBuildBlockColor(canNotBuildBlockColor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Build") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
        if (collision.gameObject.CompareTag("Kaylo") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
        if (collision.gameObject.CompareTag("Bush") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
        if (collision.gameObject.CompareTag("Rock") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
        if (collision.gameObject.CompareTag("Enemy") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
        if (collision.gameObject.CompareTag("Mine") && isPlacing)
        {
            cantPlacHere = false;
            ChangeBuildBlockColor(canBuildColor);
        }
    }
}

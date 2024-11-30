using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallForKill : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float alphaValue = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("CrystallClear");
    }


    private void Update()
    {
        if (alphaValue <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.up * 2.5f * Time.deltaTime);
    }

    IEnumerator CrystallClear()
    {
        for (int i = 0; i < 10; i++)
        {
            alphaValue -= 0.1f;

            SetAlpha(alphaValue);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void SetAlpha(float alphaValue)
    {
        alphaValue = Mathf.Clamp01(alphaValue);

        Color currentColor = spriteRenderer.color;

        Color newColor = new Color(currentColor.r, currentColor.g, currentColor.b, alphaValue);

        spriteRenderer.color = newColor;
    }
}

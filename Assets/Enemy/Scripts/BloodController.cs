using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float alphaValue = 1;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine("WaitForTwoSeconds");
    }

    private void Update()
    {
        if (alphaValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitForTwoSeconds()
    {
        yield return new WaitForSeconds(2f);

        StartCoroutine(BloodCleaner());
    }

    IEnumerator BloodCleaner()
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

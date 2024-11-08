using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalsCount : MonoBehaviour
{
    public TextMeshProUGUI crystalsText;

    private void Start()
    {
        StartCoroutine("CountCrystals");
    }

    private void Update()
    {
        crystalsText.text = CrystalsController.Instance.crystals.ToString();
    }

    private IEnumerator CountCrystals()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CrystalsController.Instance.crystals += 1;
        }
    }
}

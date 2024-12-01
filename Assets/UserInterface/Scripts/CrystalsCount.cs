using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CrystalsCount : MonoBehaviour
{
    public TextMeshProUGUI crystalsText;
    public TextMeshProUGUI orangeCrystalsText;

    private void Start()
    {
        StartCoroutine("CountCrystals");
    }

    private void Update()
    {
        crystalsText.text = CrystalsController.Instance.crystals.ToString();
        orangeCrystalsText.text = CrystalsController.Instance.orangeCrystals.ToString();
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CrystalsCount : MonoBehaviour
{
    public TextMeshProUGUI crystalsText;
    public TextMeshProUGUI orangeCrystalsText;

    public GameObject crystalImage;
    public int crystalsLen = 1;

    private void Start()
    {
        StartCoroutine("CountCrystals");
    }

    private void Update()
    {
        crystalsText.text = CrystalsController.Instance.crystals.ToString();
        orangeCrystalsText.text = CrystalsController.Instance.orangeCrystals.ToString();

        if (crystalsText.text.Length > crystalsLen)
        {
            crystalsLen += 1;
            crystalImage.transform.localPosition = new Vector3(crystalsText.transform.localPosition.x + 25 * crystalsLen,crystalImage.transform.localPosition.y,crystalImage.transform.localPosition.z);
        } 
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

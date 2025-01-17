using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CrystalsCount : MonoBehaviour
{
    public TextMeshProUGUI crystalsText;
    public TextMeshProUGUI orangeCrystalsText;

    public GameObject crystalUI;

    private int crystalsEarn = 2;

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
            CrystalsController.Instance.crystals += crystalsEarn;
            PlayerResult.Instance.BlueCrystalCollected += crystalsEarn;
            Instantiate(crystalUI, new Vector3(transform.position.x - 1, transform.position.y, -10f), crystalUI.transform.rotation);
        }
    }
}

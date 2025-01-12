using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MainResults : MonoBehaviour
{
    public ScrollRect scroll;
    public GameObject prefab;
    public GameObject container;
    public GameObject games;
    public GameObject infoAboutGame;
    public DateTime dateConvert;
    public TextMeshProUGUI textInfoAboutGame;
    public TextMeshProUGUI textInfoAboutGame2;
    public Button backToGames;
    public GameObject bacToGames;
    public GameObject bacToMenu;
   
    void Start()
    {
       LoadAllGameResult();
       backToGames.onClick.AddListener(BackToGames);
    }

    public void LoadAllGameResult()
    {
        int i = 0;

        RectTransform rect = container.GetComponent<RectTransform>();
        int height = 0;

        foreach (var game in PlayerResult.Instance.gameResults.gamesResults)
        {
            i++;
            GameObject instance = Instantiate(prefab);
            TextMeshProUGUI[] textComponents = instance.GetComponentsInChildren<TextMeshProUGUI>();
            Button button = instance.GetComponentInChildren<Button>();

            button.onClick.AddListener(() => WatchFullInfo(i-1));

            instance.transform.SetParent(container.transform, false);
            height += 180;
            dateConvert = DateTime.ParseExact(game.Date, "yyyy-MM-dd HH:mm:ss", null);

            textComponents[0].text = "Date: "+  (dateConvert.ToString("yyyy-MM-dd"));
            textComponents[1].text = "Kills:" + game.Kills.ToString();
            textComponents[2].text = "π " + i.ToString();
            textComponents[3].text = "Collected: " + (game.BlueCrystalCollected + game.OrangeCrystalCollected).ToString();
            Debug.Log(textComponents[0].text);
        }

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

    }

    public void WatchFullInfo(int number)
    {
        games.SetActive(false);
        infoAboutGame.SetActive(true);
        bacToMenu.SetActive(false);
        bacToGames.SetActive(true);

        textInfoAboutGame.text = ($"Time:{PlayerResult.Instance.gameResults.gamesResults[number].Time}\nDate:{PlayerResult.Instance.gameResults.gamesResults[number].Date}\nBlueCrystalCollected:{PlayerResult.Instance.gameResults.gamesResults[number].BlueCrystalCollected}\nOrangeCrystalCollected:{PlayerResult.Instance.gameResults.gamesResults[number].OrangeCrystalCollected}\nBlue—rystalsSpent:{PlayerResult.Instance.gameResults.gamesResults[number].Blue—rystalsSpent}\nOrange—rystalsSpent:{PlayerResult.Instance.gameResults.gamesResults[number].Orange—rystalsSpent}\n" +
            $"Kills:{PlayerResult.Instance.gameResults.gamesResults[number].Kills}\nKillsByTower:{PlayerResult.Instance.gameResults.gamesResults[number].KillsByTower}\nKillsByPlayer:{PlayerResult.Instance.gameResults.gamesResults[number].KillsByPlayer}\nKillsBeetleHeavy:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleHeavy}\nKillsBeetleLight:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleLight}\nKillsBeetleMedium:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleMedium}\n" +
            $"Wave:{PlayerResult.Instance.gameResults.gamesResults[number].Wave}\nBulletsFired:{PlayerResult.Instance.gameResults.gamesResults[number].BulletsFired}\nCountOfPlayerDead:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlayerDead}\nCountOfTowerHealedHP:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfTowerHealedHP}\nCountOfPlayerHealedHP:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlayerHealedHP}\nCountOfMainBaseDamage:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMainBaseDamage}\n");
        textInfoAboutGame2.text = ($"CountOfBoughtGuns:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfBoughtGuns}\nCountOfPlacedTowers:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlacedTowers}\nCountOfSimpleTurel:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfSimpleTurel}\nCountOfMedTent:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMedTent}\nCountOfEnergoTower:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfEnergoTower}\n" +
            $"CountOfMachineGunTuret:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMachineGunTuret}\nCountOfShotGunTuret:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfShotGunTuret}\nCountOfPiercingTuret:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPiercingTuret}\nCountOfCrystalFarming:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfCrystalFarming}\n");
    }

    public void BackToGames()
    {
        games.SetActive(true);
        infoAboutGame.SetActive(false);
        bacToMenu.SetActive(true);
        bacToGames.SetActive(false);
    }
}

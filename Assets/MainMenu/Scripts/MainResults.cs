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
    public TextMeshProUGUI userName;

    void Start()
    {
       LoadAllGameResult();
       backToGames.onClick.AddListener(BackToGames);
    }

    public void LoadAllGameResult()
    {
        int i = 0;

        userName.text = OptionsConfig.Instance.userName;

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
            height += 200;
            dateConvert = DateTime.ParseExact(game.Date, "yyyy-MM-dd HH:mm:ss", null);

            textComponents[0].text = "Date: "+  (dateConvert.ToString("yyyy-MM-dd"));
            textComponents[1].text = OptionsConfig.Instance.userName ;
            textComponents[2].text = "Kills:" + game.Kills.ToString() ;
            textComponents[3].text = "π";
            textComponents[4].text = i.ToString();
            textComponents[5].text = "Collected: " + (game.BlueCrystalCollected + game.OrangeCrystalCollected).ToString();
            Debug.Log(textComponents[0].text);
        }

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);

    }

    public void WatchFullInfo(int number)
    {
        SoundsController.Instance.PlayInGameMenuSound(1);
        games.SetActive(false);
        infoAboutGame.SetActive(true);
        bacToMenu.SetActive(false);
        bacToGames.SetActive(true);

        textInfoAboutGame.text = ($"Time:{PlayerResult.Instance.gameResults.gamesResults[number].Time}\nDate:{PlayerResult.Instance.gameResults.gamesResults[number].Date}\nBlue Crystals Collected:{PlayerResult.Instance.gameResults.gamesResults[number].BlueCrystalCollected}\nOrange Crystals Collected:{PlayerResult.Instance.gameResults.gamesResults[number].OrangeCrystalCollected}\nBlue —rystals Spent:{PlayerResult.Instance.gameResults.gamesResults[number].Blue—rystalsSpent}\nOrange —rystals Spent:{PlayerResult.Instance.gameResults.gamesResults[number].Orange—rystalsSpent}\n" +
            $"Kills:{PlayerResult.Instance.gameResults.gamesResults[number].Kills}\nKills By Tower:{PlayerResult.Instance.gameResults.gamesResults[number].KillsByTower}\nKills By Player:{PlayerResult.Instance.gameResults.gamesResults[number].KillsByPlayer}\nKills By Super Weapon{PlayerResult.Instance.gameResults.gamesResults[number].KillsBySuperWeapon}\nKills Beetle Heavy:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleHeavy}\nKills Beetle Light:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleLight}\nKills Beetle Medium:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleMedium}\n" +
            $"Kills Beetle Needl:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleNeedl}\nKills Beetle Mantis:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleMantis}\nKills Beetle Horns:{PlayerResult.Instance.gameResults.gamesResults[number].KillsBeetleHorns}\nTower Healed HP:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfTowerHealedHP}\nPlayer Healed HP:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlayerHealedHP}\n");
        textInfoAboutGame2.text = ($"Wave:{PlayerResult.Instance.gameResults.gamesResults[number].Wave}\nBullets Fired:{PlayerResult.Instance.gameResults.gamesResults[number].BulletsFired}\nPlayer Dead:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlayerDead}\nMain Base Damage:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMainBaseDamage}\nBought Super Weapons:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfBoughtSuperWeapon}\nBought Guns:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfBoughtGuns}\nPlaced Towers:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPlacedTowers}\nPlaced Simple Turel:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfSimpleTurel}\nPlaced Med Tent:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMedTent}\nPlaced Energo Tower:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfEnergoTower}\n" +
            $"Placed MachineGun Turet:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfMachineGunTuret}\nPlaced ShotGun Turet:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfShotGunTuret}\nPlaced Piercing Turet:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfPiercingTuret}\nPlaced Crystal Farming:{PlayerResult.Instance.gameResults.gamesResults[number].CountOfCrystalFarming}\n");
    }

    public void BackToGames()
    {
        SoundsController.Instance.PlayInGameMenuSound(0);
        games.SetActive(true);
        infoAboutGame.SetActive(false);
        bacToMenu.SetActive(true);
        bacToGames.SetActive(false);
    }
}

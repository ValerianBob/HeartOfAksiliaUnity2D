using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class PlayerResult : MonoBehaviour
{
    public GameResults gameResults;

    public static PlayerResult Instance;

    public string Time;//+

    public string Date;//+

    public int BlueCrystalCollected;//+

    public int OrangeCrystalCollected;//+

    public int Blue—rystalsSpent;//+

    public int Orange—rystalsSpent;//+

    public int Kills;//+

    public int KillsByTower;//+

    public int KillsByPlayer;//+

    public int KillsBeetleHeavy;//+

    public int KillsBeetleLight;//+

    public int KillsBeetleMedium;//+

    public int Wave;//+

    public int BulletsFired;//+

    public int CountOfPlayerDead;//+

    public int CountOfTowerHealedHP;//+

    public int CountOfPlayerHealedHP;//+

    public int CountOfMainBaseDamage;//+

    public int CountOfBoughtGuns;//+

    public int CountOfPlacedTowers;//+

    public int CountOfSimpleTurel;//+

    public int CountOfMedTent;//+

    public int CountOfEnergoTower;//+

    public int CountOfMachineGunTuret;//+

    public int CountOfShotGunTuret;//+

    public int CountOfPiercingTuret;//+

    public int CountOfCrystalFarming;//+

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            PrintInfo();
        }

    }

    public void PrintInfo()
    {
        Debug.Log($"Time:{Time}\nDate:{Date}\nBlueCrystalCollected:{BlueCrystalCollected}\nOrangeCrystalCollected:{OrangeCrystalCollected}\nBlue—rystalsSpent:{Blue—rystalsSpent}\nOrange—rystalsSpent:{Orange—rystalsSpent}\n" +
            $"Kills:{Kills}\nKillsByTower:{KillsByTower}\nKillsByPlayer:{KillsByPlayer}\nKillsBeetleHeavy:{KillsBeetleHeavy}\nKillsBeetleLight:{KillsBeetleLight}\nKillsBeetleMedium:{KillsBeetleMedium}\n" +
            $"Wave:{Wave}\nBulletsFired:{BulletsFired}\nCountOfPlayerDead:{CountOfPlayerDead}\nCountOfTowerHealedHP:{CountOfTowerHealedHP}\nCountOfPlayerHealedHP:{CountOfPlayerHealedHP}\nCountOfMainBaseDamage:{CountOfMainBaseDamage}\n" +
            $"CountOfBoughtGuns:{CountOfBoughtGuns}\nCountOfPlacedTowers:{CountOfPlacedTowers}\nCountOfSimpleTurel:{CountOfSimpleTurel}\nCountOfMedTent:{CountOfMedTent}\nCountOfEnergoTower:{CountOfEnergoTower}\n" +
            $"CountOfMachineGunTuret:{CountOfMachineGunTuret}\nCountOfShotGunTuret:{CountOfShotGunTuret}\nCountOfPiercingTuret:{CountOfPiercingTuret}\nCountOfCrystalFarming:{CountOfCrystalFarming}\n");
    }

    public void SaveGameResult(SaveData result)
    {
        gameResults.AddGameResult(result);
        Clear();
        gameResults.SaveToFile(Application.persistentDataPath + "/gameResults.xml");
    }

    public SaveData GetThisSaveData()
    {
        SaveData data = new SaveData
        {
            Time = this.Time,
            Date = this.Date,
            BlueCrystalCollected = this.BlueCrystalCollected,
            OrangeCrystalCollected = this.OrangeCrystalCollected,
            Blue—rystalsSpent = this.Blue—rystalsSpent,
            Orange—rystalsSpent = this.Orange—rystalsSpent,
            Kills = this.Kills,
            KillsByTower = this.KillsByTower,
            KillsByPlayer = this.KillsByPlayer,
            KillsBeetleHeavy = this.KillsBeetleHeavy,
            KillsBeetleLight = this.KillsBeetleLight,
            KillsBeetleMedium = this.KillsBeetleMedium,
            Wave = this.Wave,
            BulletsFired = this.BulletsFired,
            CountOfPlayerDead = this.CountOfPlayerDead,
            CountOfTowerHealedHP = this.CountOfTowerHealedHP,
            CountOfPlayerHealedHP = this.CountOfPlayerHealedHP,
            CountOfMainBaseDamage = this.CountOfMainBaseDamage,
            CountOfBoughtGuns = this.CountOfBoughtGuns,
            CountOfPlacedTowers = this.CountOfPlacedTowers,
            CountOfSimpleTurel = this.CountOfSimpleTurel,
            CountOfMedTent = this.CountOfMedTent,
            CountOfEnergoTower = this.CountOfEnergoTower,
            CountOfMachineGunTuret = this.CountOfMachineGunTuret,
            CountOfShotGunTuret = this.CountOfShotGunTuret,
            CountOfPiercingTuret = this.CountOfPiercingTuret,
            CountOfCrystalFarming = this.CountOfCrystalFarming
        };

        return data;
    }

    public void Clear()
    {
        Time = "";
        Date = "";
        BlueCrystalCollected = 0;
        OrangeCrystalCollected = 0;
        Blue—rystalsSpent = 0;
        Orange—rystalsSpent = 0;
        Kills = 0;
        KillsByTower = 0;
        KillsByPlayer = 0;
        KillsBeetleHeavy = 0;
        KillsBeetleLight = 0;
        KillsBeetleMedium = 0;
        Wave = 0;
        BulletsFired = 0;
        CountOfPlayerDead = 0;
        CountOfTowerHealedHP = 0;
        CountOfPlayerHealedHP = 0;
        CountOfMainBaseDamage = 0;
        CountOfBoughtGuns = 0;
        CountOfPlacedTowers = 0;
        CountOfSimpleTurel = 0;
        CountOfMedTent = 0;
        CountOfEnergoTower = 0;
        CountOfMachineGunTuret = 0;
        CountOfShotGunTuret = 0;
        CountOfPiercingTuret = 0;
        CountOfCrystalFarming = 0;
    }
}

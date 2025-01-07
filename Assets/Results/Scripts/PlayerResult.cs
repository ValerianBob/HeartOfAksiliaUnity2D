using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class PlayerResult : MonoBehaviour
{
    public GameResults _gameResults;

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
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    SaveToFile(Application.persistentDataPath + "/save.xml");
        //    Debug.Log(Application.persistentDataPath + "/save.xml");
        //}
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    LoadFromFile(Application.persistentDataPath + "/save.xml");
        //    Debug.Log(Application.persistentDataPath + "/save.xml");
        //}
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
        _gameResults.AddGameResult(result);
        _gameResults.SaveToFile(Application.persistentDataPath + "/gameResults.xml");
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

    //public void LoadFromFile(string filePath)
    //{
    //    if (!File.Exists(filePath))
    //    {
    //        Debug.LogError("‘‡ÈÎ ÌÂ Ì‡È‰ÂÌ: " + filePath);
    //        return;
    //    }

    //    XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
    //    using (StreamReader reader = new StreamReader(filePath))
    //    {
    //        SaveData data = (SaveData)serializer.Deserialize(reader);

    //        this.Time = data.Time;
    //         
    //        this.BlueCrystalCollected = data.BlueCrystalCollected;
    //        this.OrangeCrystalCollected = data.OrangeCrystalCollected;
    //        this.Blue—rystalsSpent = data.Blue—rystalsSpent;
    //        this.Orange—rystalsSpent = data.Orange—rystalsSpent;
    //        this.Kills = data.Kills;
    //        this.KillsByTower = data.KillsByTower;
    //        this.KillsByPlayer = data.KillsByPlayer;
    //        this.KillsBeetleHeavy = data.KillsBeetleHeavy;
    //        this.KillsBeetleLight = data.KillsBeetleLight;
    //        this.KillsBeetleMedium = data.KillsBeetleMedium;
    //        this.Wave = data.Wave;
    //        this.BulletsFired = data.BulletsFired;
    //        this.CountOfPlayerDead = data.CountOfPlayerDead;
    //        this.CountOfTowerHealedHP = data.CountOfTowerHealedHP;
    //        this.CountOfPlayerHealedHP = data.CountOfPlayerHealedHP;
    //        this.CountOfMainBaseDamage = data.CountOfMainBaseDamage;
    //        this.CountOfBoughtGuns = data.CountOfBoughtGuns;
    //        this.CountOfPlacedTowers = data.CountOfPlacedTowers;
    //        this.CountOfSimpleTurel = data.CountOfSimpleTurel;
    //        this.CountOfMedTent = data.CountOfMedTent;
    //        this.CountOfEnergoTower = data.CountOfEnergoTower;
    //        this.CountOfMachineGunTuret = data.CountOfMachineGunTuret;
    //        this.CountOfShotGunTuret = data.CountOfShotGunTuret;
    //        this.CountOfPiercingTuret = data.CountOfPiercingTuret;
    //        this.CountOfCrystalFarming = data.CountOfCrystalFarming;
    //    }
    //}
}

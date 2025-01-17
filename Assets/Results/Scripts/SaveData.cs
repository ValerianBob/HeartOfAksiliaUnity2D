using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
public class SaveData 
{
    public string Time;//+
    public string Date;//+
    public int BlueCrystalCollected;//+
    public int OrangeCrystalCollected;//+
    public int Blue—rystalsSpent;//+
    public int Orange—rystalsSpent;//+
    public int Kills;//+
    public int KillsByTower;//+
    public int KillsByPlayer;//+
    public int KillsBySuperWeapon;//+
    public int KillsBeetleHeavy;//+
    public int KillsBeetleLight;//+
    public int KillsBeetleMedium;//+
    public int KillsBeetleNeedl;//+
    public int KillsBeetleMantis;//+
    public int KillsBeetleHorns;//+
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
    public int CountOfBoughtSuperWeapon;//+
}

[Serializable]
public class GameResults
{
    public List<SaveData> gamesResults;

    public GameResults()
    {
        gamesResults = new List<SaveData>();
    }

    public void AddGameResult(SaveData result)
    {
        gamesResults.Add(result);
    }

    public void SaveToFile(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameResults));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, this);
        }
    }

    public static GameResults LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameResults));
            using (StreamReader reader = new StreamReader(filePath))
            {
                return (GameResults)serializer.Deserialize(reader);
            }
        }
        else
        {
            return new GameResults(); 
        }
    }
}
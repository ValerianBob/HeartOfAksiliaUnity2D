using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResult : MonoBehaviour
{
    public static PlayerResult Instance;

    public string Time;//+
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
    public int CountOfMachineGunTuret;
    public int CountOfShotGunTuret;
    public int CountOfPiercingTuret;
    public int CountOfCrystalFarming;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            PrintInfo();
        }
    }

    public void PrintInfo()
    {
        Debug.Log($"Time : {Time}\nBlueCrystalCollected:{BlueCrystalCollected}\nOrangeCrystalCollected:{OrangeCrystalCollected}\nBlue—rystalsSpent:{Blue—rystalsSpent}\nOrange—rystalsSpent:{Orange—rystalsSpent}\n" +
            $"Kills:{Kills}\nKillsByTower:{KillsByTower}\nKillsByPlayer:{KillsByPlayer}\nKillsBeetleHeavy:{KillsBeetleHeavy}\nKillsBeetleLight:{KillsBeetleLight}\nKillsBeetleMedium:{KillsBeetleMedium}\n" +
            $"Wave:{Wave}\nBulletsFired:{BulletsFired}\nCountOfPlayerDead:{CountOfPlayerDead}\nCountOfTowerHealedHP:{CountOfTowerHealedHP}\nCountOfPlayerHealedHP:{CountOfPlayerHealedHP}\nCountOfMainBaseDamage:{CountOfMainBaseDamage}\n" +
            $"CountOfBoughtGuns:{CountOfBoughtGuns}\nCountOfPlacedTowers:{CountOfPlacedTowers}\nCountOfSimpleTurel:{CountOfSimpleTurel}\nCountOfMedTent:{CountOfMedTent}\nCountOfEnergoTower:{CountOfEnergoTower}\n" +
            $"CountOfMachineGunTuret:{CountOfMachineGunTuret}\nCountOfShotGunTuret:{CountOfShotGunTuret}\nCountOfPiercingTuret:{CountOfPiercingTuret}\nCountOfCrystalFarming:{CountOfCrystalFarming}\n");
    }

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
}

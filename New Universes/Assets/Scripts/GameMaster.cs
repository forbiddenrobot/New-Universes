using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [Header("UI")]
    public static double coins;
    public TextMeshProUGUI coinsText;
    public static float coinsPerSec;
    public TextMeshProUGUI coinsPerSecText;

    public TextMeshProUGUI informationText;
    public GameObject informationPanel;

    private float moneyMade = 0;

    private void UpdateUI()
    {
        coinsText.text = "Coins: " + coins.ToString("F0");
        coinsPerSecText.text = "Coins Per Second: " + coinsPerSec;
    }

    private void Update()
    {
        coins += coinsPerSec * Time.deltaTime;
        UpdateUI();
        /*
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
        */
    }

    public static void SaveData()
    {
        PlayerPrefs.SetString("coins", coins.ToString());
        PlayerPrefs.SetFloat("coinsPerSec", coinsPerSec);
        PlayerPrefs.SetString("canBuyIce", BuyIce.canBuy.ToString());
        PlayerPrefs.SetFloat("MiningFacilityCost", Projects.miningFaciltyCost);
        PlayerPrefs.SetFloat("OilExportCost", Projects.oilExportCost);
        PlayerPrefs.SetFloat("CakeFactoryCost", Projects.cakeFactoryCost);
        PlayerPrefs.SetFloat("ComputerChipFactoryCost", Projects.computerChipCost);

        PlayerPrefs.SetFloat("IceExcavatorCost", Projects.iceExcavatorCost);
        PlayerPrefs.SetFloat("IceChunksExportationCost", Projects.iceChunksExportationCost);

        PlayerPrefs.SetInt("PlayerBulletDamage", ShipController.bulletDamage);

        float hour = System.DateTime.Now.Hour * 3600;
        float minute = System.DateTime.Now.Minute * 60;
        float second = System.DateTime.Now.Second;
        float totalTime = hour + minute + second;
        PlayerPrefs.SetFloat("Timeleft", totalTime);
    }

    public void LoadData()
    {
        string myDoubleStr = PlayerPrefs.GetString("coins", "0");
        coins = double.Parse(myDoubleStr);
        coinsPerSec = PlayerPrefs.GetFloat("coinsPerSec", 1.0f);
        if (coinsPerSec < 1)
        {
            coinsPerSec = 1;
        }
        string BuyIceString = PlayerPrefs.GetString("canBuyIce", "true");
        BuyIce.canBuy = bool.Parse(BuyIceString);
        Projects.miningFaciltyCost = PlayerPrefs.GetFloat("MiningFacilityCost", 10.0f);
        Projects.oilExportCost = PlayerPrefs.GetFloat("OilExportCost", 75.0f);
        Projects.cakeFactoryCost = PlayerPrefs.GetFloat("CakeFactoryCost", 1000.0f);
        Projects.computerChipCost = PlayerPrefs.GetFloat("ComputerChipFactoryCost", 1000000f);

        Projects.iceExcavatorCost = PlayerPrefs.GetFloat("IceExcavatorCost", 1200f);
        Projects.iceChunksExportationCost = PlayerPrefs.GetFloat("IceChunksExportationCost", 10000f);

        ShipController.bulletDamage = PlayerPrefs.GetInt("PlayerBulletDamage", 1);

        float hour = System.DateTime.Now.Hour * 3600;
        float minute = System.DateTime.Now.Minute * 60;
        float second = System.DateTime.Now.Second;
        float currentTime = hour + minute + second;
        float timeLeft = PlayerPrefs.GetFloat("Timeleft", currentTime);
        float timePassed = currentTime - timeLeft;
        if (timePassed <= 0)
        {
            Debug.Log("time passed is 0 or less");
        }
        else
        {
            if (timePassed >= 3600)
            {
                moneyMade = coinsPerSec * 3600;
                coins += moneyMade;
                coins += MiniGameMaster.moneyMadeMiniGame;
            }
            else
            {
                moneyMade = coinsPerSec * timePassed;
                coins += moneyMade;
                coins += MiniGameMaster.moneyMadeMiniGame;
            }

            MoneyMadeOffline();
        }

    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void Awake()
    {
        LoadData();
    }

    private void MoneyMadeOffline()
    {
        informationPanel.SetActive(true);
        if (MiniGameMaster.moneyMadeMiniGame > 0)
        {
            informationText.text = "You made " + moneyMade + " coins while you were away and " + MiniGameMaster.moneyMadeMiniGame + " coins from the mini game.";
        }
        else
        {
            informationText.text = "You made " + moneyMade + " coins while you were away";
        }
        Invoke("RemoveInformationPanel", 5f);
    }

    private void RemoveInformationPanel()
    {
        informationPanel.SetActive(false);
    }

    public void QuitGame()
    {
        SaveData();
        //Application.Quit();
    }

    public static void CloseAllWindows()
    {
        if (BuyIce.canBuy == false)
        {
            ProjectsIceToggle.iceUpgradePanel.SetActive(false);
        }
        ProjectsPrimordialToggle.primordialUpgradePanel.SetActive(false);
        MiniGameUpgradesToggle.MiniGameUpgradePanel.SetActive(false);
    }
}

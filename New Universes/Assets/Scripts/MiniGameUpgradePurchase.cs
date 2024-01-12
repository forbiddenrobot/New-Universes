using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameUpgradePurchase : MonoBehaviour
{
    [Header("Improved Guns")]
    [SerializeField] private GameObject improvedGunsButton;
    [SerializeField] private TextMeshProUGUI improvedGunsText;
    private float improvedGunsCost = 5000f;

    [Header("Photon Energizer")]
    [SerializeField] private GameObject photonEnergizerButton;
    [SerializeField] private TextMeshProUGUI photonEnergizerText;
    private float photonEnergizerCost = 500000f;

    bool BuyProject(float cost, string upgradeName)
    {
        if (GameMaster.coins >= cost)
        {
            GameMaster.coins -= cost;
            PlayerPrefs.SetString(upgradeName, "false");

            return (true);
        }
        else
            return (false);
    }

    private void UpdateButtonAviability()
    {
        double coins = GameMaster.coins;
        if (improvedGunsCost > coins)
        {
            improvedGunsButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            improvedGunsButton.GetComponent<Button>().interactable = true;
        }
        if (photonEnergizerCost > coins)
        {
            photonEnergizerButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            photonEnergizerButton.GetComponent<Button>().interactable = true;
        }
    }

    private void Update()
    {
        UpdateButtonAviability();
    }

    public void BuyImprovedGuns()
    {
        if(BuyProject(improvedGunsCost, "ImprovedGuns"))
        {
            ShipController.bulletDamage += 1;
            PlayerPrefs.SetString("PhotonEnergizer", "true");

        }

        UpdateButtons();
    }

    public void BuyPhotonEnergizer()
    {
        if (BuyProject(photonEnergizerCost, "PhotonEnergizer"))
        {
            ShipController.bulletDamage += 1;
        }

        UpdateButtons();
    }

    private void Awake()
    {
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if (bool.Parse(PlayerPrefs.GetString("ImprovedGuns", "true")) == true)
        {
            improvedGunsButton.SetActive(true);
        }
        else
        {
            improvedGunsButton.SetActive(false);
        }

        if (bool.Parse(PlayerPrefs.GetString("PhotonEnergizer", "false")) == true)
        {
            photonEnergizerButton.SetActive(true);
        }
        else
        {
            photonEnergizerButton.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projects : MonoBehaviour
{
    [Header("Mining Facilty")]
    [SerializeField] private TextMeshProUGUI miningFacilityText;
    [SerializeField] private float miningFacilityMult = 1.6f;
    public static float miningFaciltyCost = 10f;

    [Header("Oil Export")]
    [SerializeField] private TextMeshProUGUI oilExportText;
    [SerializeField] private float oilExportMult = 1.75f;
    public static float oilExportCost = 75f;

    [Header("Cake Factory")]
    [SerializeField] private TextMeshProUGUI cakeFactoryText;
    [SerializeField] private float cakeFactoryMult = 1.95f;
    public static float cakeFactoryCost = 1000f;

    [Header("Computer Chip Factory")]
    [SerializeField] private TextMeshProUGUI computerChipText;
    [SerializeField] private float computerChipMult = 2f;
    public static float computerChipCost = 1000000f;



    [Header("Ice Excavator")]
    [SerializeField] private TextMeshProUGUI iceExcavatorText;
    [SerializeField] private float iceExcavatorMult = 1.3f;
    public static float iceExcavatorCost = 1200f;

    [Header("Ice Chucks Exportation")]
    [SerializeField] private TextMeshProUGUI iceChunksExportationText;
    [SerializeField] private float iceChunksExportationMult = 1.35f;
    public static float iceChunksExportationCost = 10000f;

    float BuyProject(float cost, float mult, float increase)
    {
        if (GameMaster.coins >= cost)
        {
            GameMaster.coins -= cost;
            GameMaster.coinsPerSec += increase;
            cost *= mult;
            Mathf.Ceil(cost);
            return (cost);
        }
        return (cost);
    }

    private void Start()
    {
        UpdateButtonUI();
    }

    private void UpdateButtonUI()
    {
        miningFacilityText.text = "Mining Facility: +1 Coin Production " +
            "Cost: " + miningFaciltyCost.ToString("F0");

        oilExportText.text = "Oil Export: +5 Coin Production " +
            "Cost: " + oilExportCost.ToString("F0");

        cakeFactoryText.text = "Cake Factory: +10 Coin Production " +
           "Cost: " + cakeFactoryCost.ToString("F0");

        computerChipText.text = "Computer Chip Factory: +100 Coin Production " +
           "Cost: " + computerChipCost.ToString("F0");

        iceExcavatorText.text = "Ice Excavotor: +1 Coin Production" +
            "Cost: " + iceExcavatorCost.ToString("F0");

        iceChunksExportationText.text = "Ice Chunks Exportation: +10 Coin Production " +
            "Cost: " + iceChunksExportationCost.ToString("F0");
    }

    public void BuyMiningFacility()
    {
        miningFaciltyCost = BuyProject(miningFaciltyCost, miningFacilityMult, 1);
        UpdateButtonUI();
    }

    public void BuyOilExport()
    {
        oilExportCost = BuyProject(oilExportCost, oilExportMult, 5);
        UpdateButtonUI();
    }

    public void BuyCakeFactory()
    {
        cakeFactoryCost = BuyProject(cakeFactoryCost, cakeFactoryMult, 10);
        UpdateButtonUI();
    }

    public void BuyComputerChipFactory()
    {
        computerChipCost = BuyProject(computerChipCost, computerChipMult, 100);
        UpdateButtonUI();
    }

    public void BuyIceExcavator()
    {
        iceExcavatorCost = BuyProject(iceExcavatorCost, iceExcavatorMult, 1);
        UpdateButtonUI();
    }

    public void BuyIcChunksExportation()
    {
        iceChunksExportationCost = BuyProject(iceChunksExportationCost, iceChunksExportationMult, 10);
        UpdateButtonUI();
    }
}

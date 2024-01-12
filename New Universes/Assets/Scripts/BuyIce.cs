using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyIce : MonoBehaviour
{
    public static bool canBuy = true;

    [SerializeField] private GameObject icePlanetPanel;
    [SerializeField] private int icePlanetCost;

    [SerializeField] private GameObject orbit;

    private void Start()
    {
        if (canBuy == false)
        {
            Destroy(icePlanetPanel);
            orbit.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (GameMaster.coins >= icePlanetCost && canBuy == true)
        {
            canBuy = false;
            GameMaster.coins -= icePlanetCost;
            Destroy(icePlanetPanel);
            orbit.SetActive(true);
        }
    }
}

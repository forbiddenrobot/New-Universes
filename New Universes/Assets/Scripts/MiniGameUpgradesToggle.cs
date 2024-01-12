using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameUpgradesToggle : MonoBehaviour
{
    public static GameObject MiniGameUpgradePanel;
    [SerializeField] private GameObject miniGameUpgradePanel;

    private void Start()
    {
        MiniGameUpgradePanel = miniGameUpgradePanel;
    }

    private void OnMouseDown()
    {
        GameMaster.CloseAllWindows();
        MiniGameUpgradePanel.SetActive(!MiniGameUpgradePanel.activeSelf);
    }
}

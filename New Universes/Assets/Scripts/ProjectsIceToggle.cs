using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsIceToggle : MonoBehaviour
{
    public static GameObject iceUpgradePanel;
    [SerializeField] private GameObject iceUpgradePanelInspector;

    private void Start()
    {
        iceUpgradePanel = iceUpgradePanelInspector;
    }

    private void OnMouseDown()
    {
        GameMaster.CloseAllWindows();
        iceUpgradePanel.SetActive(!iceUpgradePanel.activeSelf);
    }
}

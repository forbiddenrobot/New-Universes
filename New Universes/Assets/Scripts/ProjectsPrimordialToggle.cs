using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectsPrimordialToggle : MonoBehaviour
{
    public static GameObject primordialUpgradePanel;
    [SerializeField] private GameObject primordialUpgradesPanelInspector;

    private void Start()
    {
        primordialUpgradePanel = primordialUpgradesPanelInspector;
    }

    private void OnMouseDown()
    {
        GameMaster.CloseAllWindows();
        primordialUpgradePanel.SetActive(!primordialUpgradePanel.activeSelf);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameMaster.CloseAllWindows();
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField]
    private List<UpgradeSO> upgrades;
    [SerializeField]
    private UpgradePanel upgradePanelPrefab;
    [SerializeField]
    private Transform upgradePanelParent;

    private void Awake()
    {
        foreach(var upgrade in upgrades)
        {
            var newPanel = Instantiate(upgradePanelPrefab, upgradePanelParent);
            newPanel.SetPanel(upgrade, this);
        }
    }

    public bool TryUpgrade(UpgradePanel upgradePanel)
    {
        UpgradeSO upgrade = upgradePanel.Upgrade;
        int currentLevel = UpgradeManager.Instance.GetCurrentLevel(upgrade);
        if (upgrade.MaxLevel <= currentLevel)
            return false;

        int currentCost = upgrade.GetLevelCost(currentLevel);

        if (!CoinManager.Instance.TryGetCoins(currentCost))
            return false;

        UpgradeManager.Instance.SetLevel(upgrade, (currentLevel + 1));

        return true;
    }
}

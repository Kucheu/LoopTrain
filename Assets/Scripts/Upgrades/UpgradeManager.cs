using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager
{
    #region Singleton
    public static UpgradeManager Instance
    {
        get => instance;
        set
        {
            if(instance != null)
            {
                Debug.LogError("Instance is already set!");
            }
            else
            {
                instance = value;
            }
        }
    }

    public Dictionary<UpgradeSO, int> GetAllUpgrades()
    {
        return upgradeLevels;
    }

    private static UpgradeManager instance;
    #endregion

    private Dictionary<UpgradeSO, int> upgradeLevels;

    public UpgradeManager()
    {
        upgradeLevels = new();
    }

    public int GetCurrentLevel(UpgradeSO upgrade)
    {
        return upgradeLevels.GetValueOrDefault(upgrade, 0);
    }

    public void SetLevel(UpgradeSO upgrade, int level)
    {
        if(upgradeLevels.ContainsKey(upgrade))
        {
            upgradeLevels[upgrade] = level;
        }
        else
        {
            upgradeLevels.Add(upgrade, level);
        }
    }
}

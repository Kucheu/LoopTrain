using UnityEngine;

public class UpgradesApplier : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (var upgrade in UpgradeManager.Instance.GetAllUpgrades())
        {
            upgrade.Key.Effect.Apply(upgrade.Value);
        }
    }
}

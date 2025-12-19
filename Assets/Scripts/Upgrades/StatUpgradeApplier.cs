using UnityEngine;

[CreateAssetMenu(fileName = "StatUpgradeApplier", menuName = "Kucheu/UpgradeSystem/StatUpgrade")]
public class StatUpgradeApplier : UpgradeApplier
{
    [SerializeField]
    private StatType statType;
    [SerializeField]
    private float statValueForLevel;

    public override void Apply(int level)
    {
        StatsManager.Instance.SetStat(statType, statValueForLevel * level);
    }
}
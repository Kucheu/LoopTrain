using UnityEngine;

[CreateAssetMenu(fileName = "NullUpgradeApplier", menuName = "Kucheu/UpgradeSystem/NullUpgradeApplier")]
public class NullUpgradeApplier : UpgradeApplier
{
    public override void Apply(int level)
    {
        Debug.LogError("NULL UPGRADE APPLIER");
    }
}
using UnityEngine;

public abstract class UpgradeApplier : ScriptableObject
{
    public abstract void Apply(int level);
}

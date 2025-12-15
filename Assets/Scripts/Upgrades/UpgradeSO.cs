using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeSO", menuName = "Scriptable Objects/UpgradeSO")]
public class UpgradeSO : ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private int maxLevel;
    [SerializeField]
    private int[] lvlCosts;
    [SerializeField]
    private string upgradeName;
    [SerializeField]
    private Sprite icon;

    public int ID => id;
    public int MaxLevel => maxLevel;
    public int[] LevelCosts => lvlCosts;
    public string UpgradeName => upgradeName;
    public Sprite Icon => icon;

    internal int GetLevelCost(int currentLevel)
    {
        return lvlCosts[currentLevel];
    }
}

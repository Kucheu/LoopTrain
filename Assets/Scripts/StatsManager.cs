using System;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviourSingleton<StatsManager>
{
    [SerializeField]
    private List<CardTypeMultiplier> multipliers;
    [SerializeField]
    private GameplayManager gameplayManager;

    public float MaxHp => maxHp;
    public float RegenHP => regenHP;
    public float DamageMultiplier => damage;

    private float maxHp = 1f;
    private float regenHP = 1f;
    private float damage = 1f;

    internal void SetStat(StatType statType, float value)
    {
        switch(statType)
        {
            case StatType.maxHp:
                maxHp += value;
                break;
            case StatType.regenHP:
                regenHP += value;
                break;
            case StatType.damage:
                damage += value;
                break;
            default:
                Debug.LogError("STAT IS NOT SET");
                break;
        }
    }

    public void SetStat(CardType type)
    {
        float additionalMultiplier = multipliers.Find(x => x.cardType == type).additionalMultiplier;
        switch(type)
        {
            case CardType.damageBoost:
                damage += additionalMultiplier;
                break;
            case CardType.hpBoost:
                maxHp += additionalMultiplier;
                foreach(var singleBase in gameplayManager.AllBases)
                {
                    singleBase.UpdateHealth();
                }
                break;
            case CardType.hpRegenBoost:
                regenHP += additionalMultiplier;
                break;
        }
    }

    [Serializable]
    struct CardTypeMultiplier
    {
        public CardType cardType;
        public float additionalMultiplier;
    }
}

public enum StatType
{
    maxHp = 0,
    regenHP = 1,
    damage = 2
}

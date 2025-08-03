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

using System;
using UnityEngine;

public class CoinManager
{
    #region Singleton
    public static CoinManager Instance
    {
        get => instance;
        set
        {
            if (instance != null)
            {
                Debug.LogError("Instance is already set!");
            }
            else
            {
                instance = value;
            }
        }
    }

    private static CoinManager instance;
    #endregion

    private int coinValue;

    public int CoinValue => coinValue;

    internal void AddCoind(int value)
    {
        coinValue += value;
    }

    public bool TryGetCoins(int valueToGet)
    {
        if (coinValue < valueToGet)
            return false;

        coinValue -= valueToGet;
        return true;
    }
}
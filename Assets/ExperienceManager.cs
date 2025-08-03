using System;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField]
    private CardManager cardManager;
    [SerializeField]
    private Slider expSlider;

    private int nextExperience = 10;
    private int currentExp = 0;

    private void OnEnable()
    {
        Enemy.Death += AddExp;
    }

    private void OnDisable()
    {
        Enemy.Death -= AddExp;
    }

    private void AddExp(Enemy obj)
    {
        currentExp += 2;
        if(currentExp >= nextExperience)
        {
            LevelUp();
        }
        ShowExp();
    }

    private void LevelUp()
    {
        cardManager.GetCardsOptions();
        currentExp -= nextExperience;
        nextExperience = (int)(nextExperience * 1.2f);
    }

    private void ShowExp()
    {
        expSlider.value = (float)currentExp / (float)nextExperience;
    }
}

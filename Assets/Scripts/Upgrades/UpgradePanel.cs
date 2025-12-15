using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UpgradePanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image upgradeImage;
    [SerializeField]
    private TextMeshProUGUI upgradeNameText;
    [SerializeField]
    private TextMeshProUGUI upgradeLevelText;

    private UpgradeMenu upgradeMenu;
    private UpgradeSO upgrade;

    public UpgradeSO Upgrade => upgrade;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (upgradeMenu.TryUpgrade(this))
            SetupVisuals();
    }

    public void SetPanel(UpgradeSO upgrade, UpgradeMenu upgradeMenu)
    {
        this.upgrade = upgrade;
        this.upgradeMenu = upgradeMenu;
        SetupVisuals();
    }

    private void SetupVisuals()
    {
        upgradeImage.sprite = upgrade.Icon;
        int currentLevel = UpgradeManager.Instance.GetCurrentLevel(upgrade);
        if (currentLevel >= upgrade.MaxLevel)
        {
            upgradeLevelText.text = "MAX";
            SetVisualAsMaxed();
        }
        else
        {
            upgradeLevelText.text = $"{currentLevel}/{upgrade.MaxLevel}";
            if(CoinManager.Instance.CoinValue >= upgrade.GetLevelCost(currentLevel))
            {
                SetVisualAsPossibleToClick();
            }
            else
            {
                SetVisualAsNotPossibleToClick();
            }
        }
        upgradeNameText.text = upgrade.UpgradeName;
    }

    private void SetVisualAsNotPossibleToClick()
    {
        upgradeImage.color = Color.gray;
    }

    private void SetVisualAsPossibleToClick()
    {
        upgradeImage.color = Color.white;
    }

    private void SetVisualAsMaxed()
    {
        upgradeImage.color = Color.yellow;
    }
}

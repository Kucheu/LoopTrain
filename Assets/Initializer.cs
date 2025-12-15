using UnityEngine;

public class Initializer : MonoBehaviour
{
    private void Awake()
    {
        //Check if already init
        if (UpgradeManager.Instance != null)
            return;
        //Its temporary solution
        

        UpgradeManager newUpgradeManager = new UpgradeManager();
        UpgradeManager.Instance = newUpgradeManager;

        CoinManager newCoinManager = new CoinManager();
        CoinManager.Instance = newCoinManager;
        CoinManager.Instance.AddCoind(50);
        //LOAD SAVE OR CREATE NEW

        //load upgrades
        //load coind
    }
}

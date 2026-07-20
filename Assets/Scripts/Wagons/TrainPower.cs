using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainPower : MonoBehaviour
{
    [SerializeField]
    private float cooldown;
    [SerializeField]
    private float powerTime;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private Slider powerSlider;
    [SerializeField]
    private TrainWagonMovement trainWagonMovement;

    private float currentTime;
    private PowerState powerState;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            EnableSpeed();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            EnableSlow();
        }
        else
        {
            DisablePower();
        }
    }

    /*
    private void Update()
    {
        if (gameplayManager.CurrentGameState != GameState.Playing)
            return;

        if(powerState == PowerState.off)
        {
            if(currentTime > cooldown)
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    EnableSpeed();
                    currentTime = powerTime;
                }
                else if(Input.GetKeyDown(KeyCode.S))
                {
                    EnableSlow();
                    currentTime = powerTime;
                }
            }
            else
            {
                currentTime += Time.deltaTime;
                powerSlider.value = currentTime / cooldown;
            }
        }
        else
        {
            currentTime -= Time.deltaTime;
            powerSlider.value = (currentTime / powerTime);
            if (currentTime <= 0)
            {
                currentTime = 0f;
                DisablePower();
            }
        }
    }
    */
    private void EnableSlow()
    {
        trainWagonMovement.SetTimeMultiplier(0.75f);
        powerState = PowerState.Slow;
    }

    private void EnableSpeed()
    {
        trainWagonMovement.SetTimeMultiplier(1.5f);
        powerState = PowerState.Fast;
    }

    private void DisablePower()
    {
        trainWagonMovement.SetTimeMultiplier(1f);
        powerState = PowerState.off;
    }

    private enum PowerState
    {
        off = 0,
        Slow = 1,
        Fast = 2
    }
}

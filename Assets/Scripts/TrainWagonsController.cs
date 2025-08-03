using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainWagonsController : MonoBehaviour
{
    [SerializeField]
    private WagonController testingPrefab;
    [SerializeField]
    private WagonController wagonPrefab;
    [SerializeField]
    private TrainWagonMovement TrainWagonMovement;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private WagonData firstWagon;

    List<WagonController> currentWagons;
    List<int> closeWagons;
    private WagonData currentAddingWagon;

    private void Awake()
    {
        currentAddingWagon = firstWagon;
        currentWagons = new();
        closeWagons = new();
        currentWagons.AddRange(GetComponentsInChildren<WagonController>());
    }

    private void OnEnable()
    {
        StartCoroutine(AddFirstWagonCoroutine());
    }

    private IEnumerator AddFirstWagonCoroutine()
    {
        yield return new WaitUntil(() => gameplayManager.CurrentGameState == GameState.Playing);
        AddWagonOnPosition(0);
    }

    private void Update()
    {
        if(gameplayManager.CurrentGameState == GameState.Building && Input.GetKeyDown(KeyCode.Mouse0) && closeWagons.Count == 2)
        {
            AddWagonOnPosition(closeWagons[1]);
        }
        SetWagonPositions();
        if(Input.GetKeyDown(KeyCode.E))
        {
            gameplayManager.ChangeGameState(GameState.Building);
        }
    }

    public void StartAddingWagon(WagonData wagonData)
    {
        currentAddingWagon = wagonData;
        gameplayManager.ChangeGameState(GameState.Building);
    }

    private void AddWagonOnPosition(int index)
    {
        WagonController newWagon = Instantiate(currentAddingWagon.WagonPrefab);
        currentWagons.Add(newWagon);
        int currentIndex = currentWagons.Count - 1;
        while(currentIndex > index)
        {
            currentWagons[currentIndex] = currentWagons[currentIndex - 1];
            currentIndex--;
        }
        currentWagons[index] = newWagon;
        gameplayManager.ChangeGameState(GameState.Playing);
    }

    private void SetWagonPositions()
    {
        if (gameplayManager.CurrentGameState == GameState.Building && CheckIfCloseEnought())
        {
            SetWagonsPositions2();
        }
        else
        {
            SetWagonsPositions();
            testingPrefab.SetPosition(Vector3.up * 9999, Quaternion.identity);
        }
    }

    private bool CheckIfCloseEnought()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0;
        closeWagons.Clear();
        for (int i = 0; i < currentWagons.Count; i++)
        {
            if(Vector3.Distance(GetWagonPosition(i), worldMousePosition) < 1.1f)
            {
                if(i == 0 && currentWagons.Count > 1 && Vector3.Distance(GetWagonPosition(1), worldMousePosition) >= 1.1f)
                {
                    closeWagons.Add(-1);
                }
                closeWagons.Add(i);
            }
        }
        if (closeWagons.Count == 1 && closeWagons[0] == currentWagons.Count - 1)
        {
            closeWagons.Add(currentWagons.Count);
        }
        return closeWagons.Count == 2;
    }

    private void SetWagonsPositions2()
    {
        for (int i = 0; i < currentWagons.Count; i++)
        {
            if(i <= closeWagons[0])
            {
                currentWagons[i].SetPosition(GetWagonPosition(i), GetWagonRotation(i));
            }
            else
            { 
                currentWagons[i].SetPosition(GetWagonPosition(i+1), GetWagonRotation(i));
            }
        }
        testingPrefab.SetPosition(GetWagonPosition(closeWagons[1]), GetWagonRotation(closeWagons[1]));
    }


    private void SetWagonsPositions()
    {
        for(int i = 0; i < currentWagons.Count; i++)
        {
            currentWagons[i].SetPosition(GetWagonPosition(i), transform.rotation);
        }
    }

    private Vector3 GetWagonPosition(int wagonIndex)
    {
        return TrainWagonMovement.GetPositionForWagon(wagonIndex);
    }

    private Quaternion GetWagonRotation(int wagonIndex)
    {
        return Quaternion.identity;
        Vector3 target;
        if(wagonIndex == 0)
        {
            target = transform.position;
        }
        else
        {
            target = currentWagons[wagonIndex - 1].transform.position;
        }
        Vector3 relativePos = target - currentWagons[wagonIndex].transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
}

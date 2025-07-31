using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainWagonsController : MonoBehaviour
{
    public bool isBuildingMode;

    [SerializeField]
    private WagonController testingPrefab;
    [SerializeField]
    private WagonController wagonPrefab;
    [SerializeField]
    private TrainWagonMovement TrainWagonMovement;

    List<WagonController> currentWagons;
    List<int> closeWagons;

    private void Awake()
    {
        currentWagons = new();
        closeWagons = new();
        currentWagons.AddRange(GetComponentsInChildren<WagonController>());
    }

    private void Update()
    {
        if(isBuildingMode && Input.GetKeyDown(KeyCode.Mouse0) && closeWagons.Count == 2)
        {
            AddWagonOnPosition(closeWagons[1]);
        }
    }

    private void AddWagonOnPosition(int index)
    {
        WagonController newWagon = Instantiate(wagonPrefab, transform);
        currentWagons.Add(newWagon);
        int currentIndex = currentWagons.Count - 1;
        while(currentIndex > index)
        {
            currentWagons[currentIndex] = currentWagons[currentIndex - 1];
            currentIndex--;
        }
        currentWagons[index] = newWagon;
        isBuildingMode = false;
    }

    private void FixedUpdate()
    {
        if (isBuildingMode && CheckIfCloseEnought())
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
            if(Vector3.Distance(GetWagonPosition(i), worldMousePosition) < 0.1f)
            {
                if(i == 0 && currentWagons.Count > 1 && Vector3.Distance(GetWagonPosition(1), worldMousePosition) >= 0.1f)
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

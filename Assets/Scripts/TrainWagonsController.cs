using System;
using System.Collections.Generic;
using UnityEngine;

public class TrainWagonsController : MonoBehaviour
{
    public bool isBuildingMode;

    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 entryOffset;
    [SerializeField]
    private WagonController testingPrefab;
    [SerializeField]
    private WagonController wagonPrefab;

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
        WagonController newWagon = Instantiate(wagonPrefab);
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
            if(Vector3.Distance(GetWagonPosition(i), worldMousePosition) < 1f)
            {
                if(i == 0 && currentWagons.Count > 1 && Vector3.Distance(GetWagonPosition(1), worldMousePosition) >= 1f)
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
                currentWagons[i].SetPosition(GetWagonPosition(i), transform.rotation);
            }
            else
            { 
                currentWagons[i].SetPosition(GetWagonPosition(i+1), transform.rotation);
            }
        }
        testingPrefab.SetPosition(GetWagonPosition(closeWagons[1]), transform.rotation);
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
        return entryOffset + transform.position + (offset * wagonIndex);
    }
}

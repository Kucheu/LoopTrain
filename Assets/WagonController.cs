using System;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    internal void SetPosition(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
    }
}

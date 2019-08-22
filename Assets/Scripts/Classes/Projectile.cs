using System;
using UnityEngine;
[Serializable]
public struct Projectile
{
    public GameObject projectilePrefab;
    [Tooltip("Strzały na minute"),Range(0f,300f)]
    public float rPM;
}

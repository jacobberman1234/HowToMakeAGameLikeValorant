using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGFX : MonoBehaviour
{
    #region Singleton

    public static ShootGFX instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject muzzleFlash;
    public Transform firePointOffScreen;
    public Transform firePointPlayer;
    public Vector3 angle = new Vector3(0, -90, 0);

    private Quaternion spawnAngle;

    private void Start()
    {
        spawnAngle = Quaternion.Euler(angle);
    }

    public void ShootGun()
    {
        Instantiate(muzzleFlash, firePointOffScreen.position, spawnAngle);
        Instantiate(muzzleFlash, firePointPlayer.position, spawnAngle);
    }
}

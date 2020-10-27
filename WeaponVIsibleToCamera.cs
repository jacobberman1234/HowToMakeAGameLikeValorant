using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVIsibleToCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponForCamera;

    public string weaponLayer = "Weapon";

    private void Awake()
    {
        weaponForCamera.layer = LayerMask.NameToLayer(weaponLayer);
    }
}

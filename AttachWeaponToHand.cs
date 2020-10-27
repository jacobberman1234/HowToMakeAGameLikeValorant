using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWeaponToHand : MonoBehaviour
{
    [SerializeField]
    private Transform hand;
    [SerializeField]
    private Transform weapon;
    
    private bool hasWeapon = true;

    private void Awake()
    {
        if(hasWeapon)
            weapon.transform.SetParent(hand);
    }

    private void Update()
    {
        
    }
}

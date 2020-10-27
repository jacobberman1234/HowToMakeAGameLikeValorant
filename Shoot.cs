using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool automatic;
    public float timer;
    public float fireRate = 0.2f;

    private ShootGFX _shootGFX;

    private void Start()
    {
        timer = fireRate;
        _shootGFX = ShootGFX.instance;
    }

    private void Update()
    {
        if (automatic)
        {
            if (Input.GetMouseButton(0))
            {
                timer += Time.deltaTime;
                if (timer >= fireRate)
                {
                    ShootGun();
                    timer = 0;
                }
            }
            
            if (timer < fireRate)
                timer += Time.deltaTime;

        }
        else
            if (Input.GetMouseButtonDown(0))
                ShootGun();
    }

    public void ShootGun()
    {
        _shootGFX.ShootGun();

        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo, 40))
            Debug.Log(hitInfo.collider.name);
    }
}

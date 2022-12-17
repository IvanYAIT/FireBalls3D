using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform firePoint;

    public static Action OnShoot;
    public static Action OnReload;

    private GameObject bullet;
    private int amountOfBullets;

    private int currentAmountOfBullets;

    public void Construct(GameObject bullet, int amountOfBullets)
    {
        this.bullet = bullet;
        this.amountOfBullets = amountOfBullets;
    }

    private void Start()
    {
        currentAmountOfBullets = amountOfBullets;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if(currentAmountOfBullets > 0)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            currentAmountOfBullets--;
            OnShoot?.Invoke();
        }
        else
        {
            OnReload?.Invoke();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject[] shells;
    public Transform spawnPoint;
    public GameObject shootEffect;

    private int currentShell;
    private GameObject shellPrefab;
    private float fireForce;
    private float reloadTime;
    private float reloadTimer;

    void Start()
    {
        currentShell = 0;
        SetShell();
    }

    void Update()
    {
        reloadTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && reloadTimer > reloadTime)
        {
            GameObject shell = Instantiate(shellPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

            Rigidbody shellRigidBody = shell.GetComponent<Rigidbody>();
            shellRigidBody.velocity = fireForce * spawnPoint.up;

            reloadTimer = 0;

        }
        if (Input.GetButtonDown("Fire2"))
        {
            currentShell++;
            if (currentShell >= shells.Length)
            {
                currentShell = 0;
            }
            SetShell();
        }
    }

    private void SetShell()
    {
        shellPrefab = shells[currentShell];
        Shell shell = shellPrefab.GetComponent<Shell>();
        fireForce = shell.fireforce;
        reloadTime = shell.reloadTime;
    }
}

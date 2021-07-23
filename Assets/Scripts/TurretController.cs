using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Transform player;
    private Coroutine shootCoroutine;

    public int health;
    public GameObject shellPrefab;
    public Transform turretSpawnPoint;
    public int rotationspeed;
    public float rechargeTime;
    public int fireForce;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            shootCoroutine = StartCoroutine(Shoot());
        }
    }

    public void GetHit(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
            StopCoroutine(shootCoroutine);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationspeed * Time.deltaTime);
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject shell = Instantiate(shellPrefab, turretSpawnPoint.position, turretSpawnPoint.rotation) as GameObject;
            Rigidbody shellRigidBody = shell.GetComponent<Rigidbody>();
            shellRigidBody.velocity = fireForce * turretSpawnPoint.forward;

            yield return new WaitForSeconds(rechargeTime);
        }
    }
}

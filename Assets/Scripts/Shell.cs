using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int damage;
    public float fireforce;
    public float reloadTime;
    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Enemy"))
        {
            coll.transform.parent.GetComponent<TurretController>().GetHit(damage);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float travelSpeed = 5f;
    public float damage = 10f;

    Vector3 travelDir;

    public void SetStats(Vector3 forwardVector, float projectileDamage, float projectileVelocity)
    {
        damage = projectileDamage;  travelSpeed = projectileVelocity;

        travelDir = forwardVector;

        Destroy(this.gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(travelDir * travelSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}

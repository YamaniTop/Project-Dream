using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centry : Sounds
{
    public GameObject bulletPrefab;
    public GameObject bulletReflect;
    public float bulletSpeed = 10f;
    public float reflectSpeed = 5f;
    public float fireRate = 1f;
    public Transform target;

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 5f / fireRate;
        }
    }

    void Shoot()
    {
        int minInt = 1;
        int maxInt = 3;
        int randomInt = UnityEngine.Random.Range(minInt, maxInt + 1);
        PlaySound(sound[0]);
        if (randomInt == 2)
        {

            GameObject bullet = Instantiate(bulletReflect, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();


            Vector3 direction = (target.position - transform.position).normalized;

            bulletRb.velocity = direction * bulletSpeed;
            Destroy(bullet, 5f);
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();


            Vector3 direction = (target.position - transform.position).normalized;

            bulletRb.velocity = direction * bulletSpeed;
            Destroy(bullet, 1f);
        }

        }
    }
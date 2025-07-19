using System.Collections;
using UnityEngine;

public class ArmControllerRifle : Sounds
{
    public float offset;
public GameObject bullet;
public Transform ShotPoint;
public float fireRate = 1f;
public float startTBS;
public static bool isCollect;
public int burstAmount = 5; 
public float burstInterval = 0.1f; 

private float timeBS;
private int bulletsShot = 0; 
private bool isBursting = false; 

void Update()
{
    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

    if (MoveISO.facing)
    {
        rotZ += 180f;
    }

    transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


    timeBS -= Time.deltaTime;

    if (timeBS <= 0f)
    {
        if (Input.GetMouseButton(0))
        {
            if (!SwitchPanel.isPanelActive && !isBursting)
            {
                StartCoroutine(FireBurst());
            }
        }
    }
}

IEnumerator FireBurst()
{
    isBursting = true;
    bulletsShot = 0;

    while (bulletsShot < burstAmount)
    {
        PlaySound(sound[0]);
        Instantiate(bullet, ShotPoint.position, transform.rotation);
        bulletsShot++;
        yield return new WaitForSeconds(burstInterval);
    }

    isBursting = false;
    timeBS = startTBS; 
}
}
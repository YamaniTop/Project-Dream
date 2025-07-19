using UnityEngine;
using System.Collections; 

public class ArmController : Sounds
{
    public float offset;
    public GameObject bullet;
    public Transform ShotPoint;
    public float fireRate = 1f; 
    public float startTBS;

    private float timeBS;

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
                if (!SwitchPanel.isPanelActive) 
                {
                    
                    PlaySound(sound[0]);
                    Instantiate(bullet, ShotPoint.position, transform.rotation);
                    timeBS = startTBS;
                }
            }
        }

    }
}
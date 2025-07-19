using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerX : MonoBehaviour
{
    public float offset;

    private float timeBS;
    public float startTBS;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        float rotationX = 0f; 

        if (MoveISO.facing)
        {
            rotationX += 180f; 
            transform.localEulerAngles = new Vector3(rotationX, 0f, rotZ + offset);
        }
        else 
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); 
        }


        
    }
    

}
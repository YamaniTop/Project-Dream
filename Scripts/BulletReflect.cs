using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReflect : MonoBehaviour
{

    public GameObject mother;
    void Start()
    {

    }
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up);
        if (hitinfo.collider != null)
        {

            if (hitinfo.collider.CompareTag("shield"))
            {
                Destroy(gameObject);
                Destroy(mother);
            }

        }
    }

}

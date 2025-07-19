using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyB : MonoBehaviour

{
    public LayerMask Hurt;
    public LayerMask Wall;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, Hurt);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}

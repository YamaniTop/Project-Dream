using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bulletPL : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask Hurt;
    public LayerMask Wall;
    public int damage;
    bool right = MoveISO.facing;
    public GameObject hand;
    private void Start()
    {
        

    }


    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, distance, Hurt);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }

            Destroy(gameObject);
            if (hitinfo.collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
        if (right == true)
        {
            
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if (right == false)
        {
            
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

}

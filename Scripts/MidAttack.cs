using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidAttack : MonoBehaviour
{
    public GameObject knife;
    private float timeBA;
    public float startTBA;
    public Transform attackPos;
    public LayerMask enemy;
    public float range;
    public int damage;
    //public Animator anim;
    private void Update()
    {
        if (timeBA <= 0)
        {
            
            if (Input.GetMouseButton(0))
            {
                //anim.SetTrigger("MidAt");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, range, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    Debug.Log("Log");
                    enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                    //Transform.Position = knife.transform.position * 0.5;
                }
            }
            timeBA = startTBA;
        }
        else {
            timeBA -= Time.deltaTime;
        
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, range);
    }
}

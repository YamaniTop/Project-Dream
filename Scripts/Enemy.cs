using System.Collections;
using UnityEngine;

public class Enemy : Sounds
{
    public int hp;
    public float deathDelay; 

    void Update()
    {
        if (hp <= 0)
        {
            StartCoroutine(Die()); 
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
    }

   
    IEnumerator Die()
    {
        PlaySound(sound[0]); 
        yield return new WaitForSeconds(deathDelay); 
        Destroy(gameObject); 
    }
}

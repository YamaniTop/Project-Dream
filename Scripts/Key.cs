using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Sounds
{
    public float delay;

    IEnumerator Collect()
    {
        PlaySound(sound[0]);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisionObject = other.gameObject;

        if (collisionObject.CompareTag("Player"))
        {
            StartCoroutine(Collect());
        }
    }
}

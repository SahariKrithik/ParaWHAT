using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperDie : MonoBehaviour
{
    public AudioSource trooperDeathSound;
    public SpriteRenderer trooperSprite;
    public Collider2D trooperCollider;
    public ParticleSystem BloodSplatter;
    
    private void Start()
    {
        trooperSprite = GetComponent<SpriteRenderer>();
        trooperCollider = GetComponent<Collider2D>();
       StartCoroutine(DieIfIdle());
    }

   
    public void Die()
    {
        trooperSprite.enabled = false;
        trooperCollider.enabled = false;
        BloodSplatter.Play();
        trooperDeathSound.Play();
        StartCoroutine(WaitForDeath());
    }

    IEnumerator WaitForDeath()
    {
        
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }

    IEnumerator DieIfIdle()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

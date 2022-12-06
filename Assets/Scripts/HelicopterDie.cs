using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterDie : MonoBehaviour
{
    [SerializeField] private GameObject explodePrefab;
    public AudioSource HelicopterDeathSound;
    public SpriteRenderer HelicopterSprite;
    public Collider2D HelicopterCollider;
    public ParticleSystem HelicopterExplosion;

    private void Start()
    {
        HelicopterSprite = GetComponent<SpriteRenderer>();
        HelicopterCollider = GetComponent<Collider2D>();
    }
    public void Die()
    {
        Turret.instance.heliActive = false;
        //score increment
        HelicopterSprite.enabled = false;
        HelicopterCollider.enabled = false;
        HelicopterExplosion.Play();
        HelicopterDeathSound.Play();
        StartCoroutine(WaitForDeath());
        
    }

    IEnumerator WaitForDeath()
    {

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Projectile instance;
    [SerializeField] public Rigidbody2D rbProjectile;
    [SerializeField] public float speed;
    
    
    


    private float cleanProjectileTimer = 2f;

    private void Awake()
    {
        instance = this;
        
    }
     void Start()
    {
        rbProjectile = GetComponent<Rigidbody2D>();
        StartCoroutine(CleanProjectile());
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Helicopter"))
        {
            Turret.instance.score += 5;
            Turret.instance.UpdateScore();
            other.transform.GetComponent<HelicopterDie>().Die();
            

           
        }
        if(other.gameObject.CompareTag("Trooper"))
        {
            Turret.instance.score += 2;
            Turret.instance.UpdateScore();
            other.transform.GetComponent<TrooperDie>().Die();
            

        }
        
        Destroy(gameObject);
    }

    
    public IEnumerator CleanProjectile() 
    {
        yield return new WaitForSeconds(cleanProjectileTimer);
        Destroy(gameObject);
    }
}

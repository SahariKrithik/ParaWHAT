using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrooperMovement : MonoBehaviour
{
    public float speed = 1f;
    public GameObject targetObject;
    private Transform target;
    
    void Start()
    {
        target = targetObject.transform;
    }

    
    void Update()
    {
        
    }
 
    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Floor"))
        {
          Turret.instance.TakeDamage(5);
        }
    }

    
    
       
           
           
        
    

}

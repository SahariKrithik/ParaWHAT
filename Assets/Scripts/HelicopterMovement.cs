using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public static HelicopterMovement instance;   
    public Transform[] startPosition;
    public Transform goalPosition;
    public float speed = 10f;
    public int nextPosIndex;
    [SerializeField] SpriteRenderer sprite;

    public GameObject soldierPrefab;
    public Transform solderPrefabSpawnPoint;



    void Start()
    {
        Turret.instance.heliActive = true;
        goalPosition = startPosition[0];
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(SpawnSoldier());
    }


    void Update()
    {

        Movement();
        
    }

    public void Movement()
    {
        if (transform.position == goalPosition.position)
        {
            
            
            nextPosIndex++;
            if (nextPosIndex >= startPosition.Length)
            {
                sprite.flipX = true;
                nextPosIndex = 0;
            }
            else
                sprite.flipX = false;
            goalPosition = startPosition[nextPosIndex];
            
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, goalPosition.position, speed * Time.deltaTime);
        }
    }

    IEnumerator SpawnSoldier()
    {
        float randomizerNumber;
        randomizerNumber = Random.Range(0.125f, 1.5f);
        yield return new WaitForSeconds(randomizerNumber);
        Instantiate(soldierPrefab,solderPrefabSpawnPoint.position,Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public static Turret instance;

    private Camera cam;

    [SerializeField,Range(1,100)] private float rotationSpeed = 9f;
    
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform spawnPoint;   
    public float shootTimer;
    private bool isShooting;

    public Vector3 mousePos;

    public AudioSource shootSound;

    public GameObject HelicopterPrefab;
    public bool heliActive;
    public Transform startPosition;

    public int score;
    public TMP_Text scoreText;

    public int damage;
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    
    

    private void Awake()
    {
        instance = this;
        cam = Camera.main;
    }

    void Start()
    {
        isShooting = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    
    void Update()
    {
        Movement();
        ShootProjectile();
        if (!heliActive)
        {
            SpawnHeli();
        }
        
    }

    public void Movement()
    {
        var mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = 0;

        var dir = mousePosition - transform.position;
        
        transform.up = Vector3.MoveTowards(transform.up, dir, rotationSpeed * Time.deltaTime);
    }

    public void ShootProjectile()
    {
        if(Input.GetMouseButtonDown(0) && !isShooting)
        {

            StartCoroutine(Shoot());
            shootSound.Play();
        }
    }

    public IEnumerator Shoot()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        isShooting = true;
        Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);//instantiating the projectile and spawning it in a desired location.
        Projectile.instance.rbProjectile.velocity = mousePos * Projectile.instance.speed;
        yield return new WaitForSeconds(shootTimer);
        isShooting = false; 

    }
    public void SpawnHeli()
    {
        Instantiate(HelicopterPrefab,startPosition.position, Quaternion.identity);
    }

    public void UpdateScore()
    {
        
        scoreText.text = "Score : " + score;
    }

    public void TakeDamage(int damage)//call this function in any other script and pass a integer value as damage taken.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            MainSceneSettings.instance.GameOver();
        }
    }
}

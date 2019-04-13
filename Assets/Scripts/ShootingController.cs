using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform spawnLocation;
    public Rigidbody2D bullet;

    [Header("Bullet params")]
    public float Force = 10f;
    public float Damage;

    public float ShootingTime = 1f;

    float shootingTimer;

  
    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = ShootingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shootingTimer >= ShootingTime)
        {
            Shoot();
        }
        shootingTimer += Time.deltaTime;
    }

    private void Shoot()
    {
        Rigidbody2D shot = Instantiate(bullet, spawnLocation.position, Quaternion.identity) as Rigidbody2D;
        LevelManager.instance.PlayShooting();
        shot.velocity = Force * spawnLocation.right;
        shootingTimer = 0;
    }

   
}

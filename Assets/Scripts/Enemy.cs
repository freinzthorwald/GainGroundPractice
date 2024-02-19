using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public EnemyScriptableObject enemyData;
    [SerializeField]
    public GameObject ProjectilePrefab;
    private ProjectileScriptableObject projectileData;
    private float fireRange;
    private float fireRate;
    private float health;
    private float timeToShoot;

    // Start is called before the first frame update
    void Start()
    {
        this.projectileData = enemyData.ProjectileData;
        this.health = enemyData.Health;
        this.fireRange = enemyData.FireRange;
        this.fireRate = enemyData.FireRate;
        timeToShoot = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        float seconds = Time.deltaTime;
        timeToShoot -= seconds;
        ChangeDirection();
        if(timeToShoot < 0)
        {
            Shoot();
            timeToShoot += fireRate;
        }
    }

    private void Shoot()
    {
        
        GameObject projectileObject = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Init(projectileData, false);
        Physics.IgnoreCollision(projectile.GetComponent<SphereCollider>(), gameObject.GetComponent<BoxCollider>());
    }

    private GameObject GetClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestObject = null;
        float shortestDistance = 10000;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if(distance < shortestDistance)
            {
                shortestDistance = distance;
                closestObject = player;
            }
        }
        return closestObject;
    }

    private void ChangeDirection()
    {
        GameObject player = GetClosestPlayer();
        float forwardDirection = transform.rotation.z;
        transform.LookAt(player.transform);
    }
}

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
        ChangeDirection();
        DetermineShooting();
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
        if(player != null)
        {
            transform.LookAt(player.transform);
        }
    }

    private void DetermineShooting()
    {
        float seconds = Time.deltaTime;
        timeToShoot = timeToShoot < 0 ? timeToShoot : timeToShoot - seconds; /*Originally had this as just -= but thinking about it this check would prevent the game from crashing if the player left the game running for a bajillion years */
        GameObject player = GetClosestPlayer();
        float distance = Mathf.Abs(transform.position.x - player.transform.position.x +  transform.position.y - player.transform.position.y);
        Debug.Log("Distance " + distance + " and TimeToShoot = " + timeToShoot);
        if (timeToShoot < 0 && distance < fireRange)
        {
            Debug.Log("Shooting" + timeToShoot);
            Shoot();
            timeToShoot = fireRate; /* += Would give this a more consistent rate but the difference should be neglible overall. Also won't matter given the previous assignment. */
        }
    }

    private void Shoot()
    {
        GameObject projectileObject = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Init(projectileData, false);
        Physics.IgnoreCollision(projectile.GetComponent<SphereCollider>(), gameObject.GetComponent<BoxCollider>());
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed;
    [SerializeField]
    public ProjectileScriptableObject ProjectileA;
    [SerializeField]
    public ProjectileScriptableObject ProjectileB;
    [SerializeField]
    public GameObject ProjectilePrefab;
    private Dictionary<(int, int), Vector3> directions = new()
    {
        {(-1, -1), new Vector3(0, 225, 0)},
        {(-1, 0), new Vector3(0, 270, 0)},
        {(-1, 1), new Vector3(0, 315, 0)},
        {(0, -1), new Vector3(0, 180, 0)},
        {(0, 1), new Vector3(0, 0, 0)},
        {(1, -1), new Vector3(0, 135, 0)},
        {(1, 0), new Vector3(0, 90, 0)},
        {(1, 1), new Vector3(0, 45, 0)}
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 newDirection, float time)
    {
        Vector3 direction = directions[((int)newDirection.x, (int)newDirection.z)];
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(direction));
        transform.Translate(Vector3.forward * MoveSpeed * time);
    }

    public void Shoot(bool IsShotA)
    {
        float forwardDirection = transform.rotation.z;
        GameObject projectileObject = Instantiate(ProjectilePrefab, transform.position, transform.rotation);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Init(IsShotA ? ProjectileA : ProjectileB, true);
        Physics.IgnoreCollision(projectile.GetComponent<SphereCollider>(), gameObject.GetComponent<BoxCollider>());
    }
}

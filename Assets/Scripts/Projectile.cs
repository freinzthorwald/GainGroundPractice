using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private bool IsHero; //For now, this will denote whether or not it can hit an enemy or a player
    private float ForwardVelocity;
    private float VerticalVelocity;
    private float VerticalDrop;
    private float LifeSpan;
    private float CurrentLife;

    public void Init(ProjectileScriptableObject data, bool isHero)
    {
        this.ForwardVelocity = data.ForwardVelocity;
        this.VerticalVelocity = data.VerticalVelocity;
        this.VerticalDrop = data.VerticalDrop;
        this.LifeSpan = data.LifeSpan;
        this.IsHero = isHero;
        CurrentLife = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float seconds = Time.deltaTime;
        transform.Translate(Vector3.forward * seconds * ForwardVelocity + (new Vector3(0, this.VerticalVelocity, 0) * seconds));
        this.VerticalVelocity -= this.VerticalDrop;
        CurrentLife += seconds;
        if(CurrentLife > LifeSpan)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
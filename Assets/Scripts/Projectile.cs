using System;
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
        this.VerticalVelocity = GetInitialVerticalVelocity(data.VerticalVelocity);
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
        if(other.gameObject.GetComponent<Enemy>() != null)
        {
            if(IsHero)
            {
                Destroy(other.gameObject);
            }
        }
        else if(other.gameObject.GetComponent<Player>() != null)
        {
            if(!IsHero)
            {
                Destroy(other.gameObject);
            }
        }
        Destroy(gameObject);
    }

    //TODO: This isn't going to work as intended. Enemies shouldn't have to rotate into the ground to face a player to shoot closer to them.
    //This also still overshoots, just not as bad as before.
    private float GetInitialVerticalVelocity(float verticalVelocity)
    {
        float modifier = ((90 - transform.rotation.eulerAngles.x * 2) / 90);
        return modifier * verticalVelocity;
    }
}
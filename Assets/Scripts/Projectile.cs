﻿using UnityEngine;
using System.Collections;

// describes how the projectile it's attached to should behave
// gives speed and damage values
public class Projectile : MonoBehaviour 
{
    // how fast this projectile should move
    public float speed = 1f;

    // how much damage this projectile should deal
    public int damage = 1;

    // This code handles how the projectile should act if it collides with something
    void OnTriggerEnter(Collider other)
    {
        // ignore the collision if the layers of the projectile and the collider are the same
        // NOTE: This makes it really important to set layers correctly when making prefabs!
        if (this.gameObject.layer == other.gameObject.layer) return;

        //Debug.Log("Bullet Collision Detected!");
        
        // Check to see whether the other collider has a health component
        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }
}

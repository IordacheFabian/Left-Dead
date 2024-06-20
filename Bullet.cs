using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int bulletDamage;
    
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            print("hit " + collision.gameObject.name + "!");

            CreateBulletImpactEffect(collision);
            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            print("hit a wall");

            CreateBulletImpactEffect(collision);
            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Beer"))
        {
            print("we hit a beer bottle");
            
            collision.gameObject.GetComponent<BeerBottle>().Shatter();
            // collision.gameObject.GetComponent<CapsuleCollider>().radius = 0;
            // collision.gameObject.GetComponent<CapsuleCollider>().height = 0;
            // collision.gameObject.GetComponent<CapsuleCollider>().center = Vector3.zero;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<Enemy>().isDead == false)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            }

            CreateBloodSprayEffect(collision);
            
            Destroy(gameObject);
        }
    }

    private void CreateBulletImpactEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
            );
        
        hole.transform.SetParent(objectWeHit.gameObject.transform);
    }

    private void CreateBloodSprayEffect(Collision objectWeHit)
    {
        ContactPoint contact = objectWeHit.contacts[0];

        GameObject bloodSprayEffect = Instantiate(GlobalReferences.Instance.bloodSprayEffect,
            contact.point,
            Quaternion.LookRotation(contact.normal));
        
        bloodSprayEffect.transform.SetParent(objectWeHit.gameObject.transform);
    }
}

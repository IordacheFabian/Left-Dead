using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    private Animator animator;
    private NavMeshAgent agent;

    public bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            int randomValue = Random.Range(0, 2);

            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

            isDead = true;
            
            // Dead Sound
            SoundManager.Instance.ZombieChannel2.PlayOneShot(SoundManager.Instance.zombieDeath);

            GetComponent<CapsuleCollider>().enabled = false;

            StartCoroutine(DestroyEnemy());
        }
        else
        {
            animator.SetTrigger("DAMAGE");
            
            // Hurt Sound
            SoundManager.Instance.ZombieChannel2.PlayOneShot(SoundManager.Instance.zombieHurt);
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);
    }
}

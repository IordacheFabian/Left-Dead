using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class MedBox : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI playerHealthUI;
    private Animator anim;
    
    public static MedBox Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void Heal()
    {
        if (Player.HP < 100)
        {
            anim.SetTrigger("Open");
            
            int playerCurrentHealth = Player.HP;

            int heal = Mathf.Abs(playerCurrentHealth - health);

            Player.HP += heal;
            if (Player.HP > 100)
            {
                heal = Player.HP - heal;
                Player.HP = 100;
            }

            playerHealthUI.text = $"Health: {Player.HP}";

            health -= heal;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

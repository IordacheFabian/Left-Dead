using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    
    [Header("Shooting Channel")]
    public AudioSource ShootingChannel;
    public AudioClip P92Shot;
    public AudioClip Ak47Shot;
    public AudioSource reloadSoundP92;
    public AudioSource reloadSoundAk47;
    public AudioSource emptySoundP92;

    [Header("Throwables Channel")]
    public AudioSource throwablesChannel;
    public AudioClip grenadeSound;

    [Header("Zombie Channel")]
    public AudioSource ZombieChannel;
    public AudioSource ZombieChannel2;
    public AudioClip zombieWalking;
    public AudioClip zombieChase;
    public AudioClip zombieAttack;
    public AudioClip zombieHurt;
    public AudioClip zombieDeath;


    [Header("Player Channel")] 
    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDie;
    
    public AudioClip gameOverMusic;
    
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

    public void PlayShootingSound(Weapon.WeaponModel weapon)
    {
        switch (weapon)
        {
            case Weapon.WeaponModel.Pistol92:
                ShootingChannel.PlayOneShot(P92Shot);
                break;
                
            case Weapon.WeaponModel.AK47:
                ShootingChannel.PlayOneShot(Ak47Shot);
                break;
            
        }
    }
    public void PlayReloadSound(Weapon.WeaponModel weapon)
    {
        switch (weapon)
        {
            case Weapon.WeaponModel.Pistol92:
                reloadSoundP92.Play();
                break;
            
            case Weapon.WeaponModel.AK47:
                reloadSoundAk47.Play();
                break;
            
        }
    }
}

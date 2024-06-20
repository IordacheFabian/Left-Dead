using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set; }

    public Weapon hoveredWeapon = null;

    [FormerlySerializedAs("hoveredAmmoBox")] public AmmoBox hoveredAmmoBox = null;

    [FormerlySerializedAs("hoveredMedBox")]
    public MedBox hoveredMedBox = null;

    public Throwable hoveredThrowble;

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

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            GameObject objectHitByRaycast = hit.transform.gameObject;

            //weapon
            if (objectHitByRaycast.GetComponent<Weapon>() &&
                objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false) 
            {
                if (hoveredWeapon)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled = false;
                }
                
                
                hoveredWeapon = objectHitByRaycast.gameObject.GetComponent<Weapon>();
                hoveredWeapon.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickUpWeapon(objectHitByRaycast.gameObject);
                }
            }
            else
            {
                if (hoveredWeapon)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled = false;
                }
            }
            
            //ammobox
            if (objectHitByRaycast.GetComponent<AmmoBox>())
            {
                if (hoveredAmmoBox)
                {
                    hoveredAmmoBox.GetComponent<Outline>().enabled = false;
                }
                
                hoveredAmmoBox = objectHitByRaycast.gameObject.GetComponent<AmmoBox>();
                hoveredAmmoBox.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickupAmmo(hoveredAmmoBox);
                    Destroy(objectHitByRaycast.gameObject);
                }
            }
            else
            {
                if (hoveredAmmoBox)
                {
                    hoveredAmmoBox.GetComponent<Outline>().enabled = false;
                }
            }
            
            // Heal
            if (objectHitByRaycast.GetComponent<MedBox>())
            {
                if (hoveredMedBox)
                {
                    hoveredMedBox.GetComponent<Outline>().enabled = false;
                }

                hoveredMedBox = objectHitByRaycast.gameObject.GetComponent<MedBox>();
                hoveredMedBox.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    MedBox.Instance.Heal();
                }
            }
            else
            {
                if (hoveredMedBox)
                {
                    hoveredMedBox.GetComponent<Outline>().enabled = false;
                }
            }

            // Throwble
            if (objectHitByRaycast.GetComponent<Throwable>())
            {
                if (hoveredThrowble)
                {
                    hoveredThrowble.GetComponent<Outline>().enabled = false;
                }
                
                hoveredThrowble = objectHitByRaycast.gameObject.GetComponent<Throwable>();
                hoveredThrowble.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickUpThrowable(hoveredThrowble);
                }
            }
            else
            {
                if (hoveredThrowble)
                {
                    hoveredThrowble.GetComponent<Outline>().enabled = false;
                }
            }
        }
    }
}

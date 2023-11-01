    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    int playerAmmo;
    int playerMaxAmmo;
    float bulletCooldown;//timer to stop player from overcoming reload rate by spamming the mouse click
    float reloadTimer; //timer for reloading
    float reloadTime;//time for reload
    public float fireRate = 1f;
    public Transform firePoint; // the point where the bullets will be spawned
    public GameObject bulletPrefab; // the bullet prefab to be spawned
    [SerializeField] GameObject reloadBar;
    [SerializeField] GameObject reloadText;
    [SerializeField] TMPro.TextMeshProUGUI ammoText;

    void Start()
    {
        //sanity check for reload bar
        if (reloadBar == null)
        {
            reloadBar = GetComponent<GameObject>();
        }

        playerMaxAmmo = 6;
        playerAmmo = playerMaxAmmo;
        reloadBar.SetActive(false);
        reloadText.SetActive(false);

    }
    void Update()
    {
        if (Input.GetButton("Fire1")) // if the left mouse button is pressed
        {
            if (bulletCooldown <=0 && playerAmmo > 0 && reloadTimer <=0)
            {
                Shoot(); // call the Shoot function
                bulletCooldown = fireRate;
            }
            bulletCooldown -= Time.deltaTime;  
        }
        if (Input.GetButtonUp("Fire1")) //start reload as soon as mouse button is released
        {
            reloadTime = 0.5f;
            reloadTimer = reloadTime;
            bulletCooldown = 0.5f;
        }

        if (reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            ReloadBar(reloadTimer, reloadTime);
            playerAmmo = 6;
            AmmoText();
        }
        if (reloadTimer < 0)
        {
            reloadText.SetActive(false);
        }    
        

    }

    void Shoot()
    {
        // spawn a new bullet at the fire point 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        playerAmmo--;
        AmmoText();
    }
    //function to update reload bar
    void ReloadBar(float reloadTimer, float reloadTime)
    {
        reloadBar.SetActive(true); //show the reload bar
        reloadText.SetActive(true); //show the reload text
        float reloadPercent = reloadTimer / reloadTime;
        if (reloadPercent < 0)
        {
            reloadPercent = 0f;
        }
        reloadBar.transform.localScale = new Vector3(reloadPercent, 1f, 1f); //change the localScale of the x-axis to show the change in the bar
    }

    //function to update ammo text
    void AmmoText()
    {
        ammoText.text = "Ammo: " + playerAmmo.ToString();
    }
}
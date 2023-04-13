using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    private bool bulletHit;
    public float rayLength;
    public Transform playerGun;
    public Vector3 aimingOffset;
    private Vector3 normalGunPos;
    public GameObject crosshair;
    public Quaternion normalRotation;
    public float minXAim;
    public float maxXAim;
    public float minYAim;
    public float maxYAim;
    private Vector3 aimDispersion;
    private bool aiming;
    private int ammo;
    public int magSize;
    public float reloadDelay;
    private float reloadTimer;
    public TMP_Text ammoText;
    public int allAmmo;
    private bool reload = false;
    public Animator gunAnimator;
    private bool canShoot = true;
    public float shootDelay;
    private bool reloadAnimationStart;

    
    void Start() {
        normalGunPos = playerGun.localPosition;
        reloadTimer = reloadDelay;
        ammo = magSize;
        ammoText.text = "AMMO: " + ammo + "/" + allAmmo;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && ammo > 0 && canShoot) {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && ammo < 10) {
            reload = true;
            gunAnimator.SetTrigger("Reload");
        }
        

        if (Input.GetKeyDown(KeyCode.Mouse1)) {

            playerGun.localPosition = normalGunPos + aimingOffset;

            crosshair.SetActive(false);
            aiming = true;

        } else if (Input.GetKeyUp(KeyCode.Mouse1)){

            playerGun.localPosition = normalGunPos;
            playerGun.localRotation = normalRotation;
            crosshair.SetActive(true);
            aiming = false;

        }
        if (reload && reloadTimer > 0) {
            reloadTimer -= Time.deltaTime;
            canShoot = false;

        } else if (reloadTimer <= 0 && allAmmo >= magSize - ammo) {
            Reload();
            reload = false;
            reloadTimer = reloadDelay;
            ammoText.text = "AMMO: " + ammo + "/" + allAmmo;
            canShoot = true;
        }

        if (ammo == 0) {
            reload = true;
        }
    }

    void Shoot(){
        gunAnimator.SetTrigger("Shoot");

        if (!aiming) {
            aimDispersion.x = Random.Range(minXAim, maxXAim);
            aimDispersion.y = Random.Range(minYAim, maxYAim);
            aimDispersion.z = 0;

        } else {
            aimDispersion = Vector3.zero;
        }


        RaycastHit hit;

        
        bulletHit = Physics.Raycast(transform.position + aimDispersion, transform.up, out hit, rayLength);

        if (bulletHit) {
            Debug.Log("You shot an enemy; Time: " + Time.time + "; Object: " + hit.collider.gameObject.name);
            bulletHit = false;
        }

        ammo--;
        ammoText.text = "AMMO: " + ammo + "/" + allAmmo;
        canShoot = false;
        StartCoroutine(ShootDelayCoroutine());
    }

    void Reload() {
        allAmmo -= magSize - ammo;
        ammo = magSize;
        ammoText.text = "AMMO: " + ammo + "/" + allAmmo;
        gunAnimator.SetTrigger("BackReload");
        reload = false;
    }

    IEnumerator ShootDelayCoroutine() {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}

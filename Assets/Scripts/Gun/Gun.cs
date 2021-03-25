using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireSpeed = 15f;
    public float impactForce = 30f;
    public int maxAmmo = 10;
    public float reloadTime = 3f;
    private int currentAmmo;
    private bool isReloading = false;
    private GameObject CamObject;
    private Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impact;
    private float nextTimeToFire = 0f;

    public Animator animator;
    public PlayerMouvement pM;

    public GameObject reloadingText;
    public Text currentAmmoCounter;

    private void Start()
    {
        CamObject = GameObject.FindGameObjectWithTag("Camera");
        fpsCam = CamObject.GetComponent<Camera>();
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        //recharge si appuie sur R
        if (Input.GetKey(KeyCode.R) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }
        //return si on recharge
        if (isReloading)
            return;
        
        //si plus de balle, recharge
        if(currentAmmo <= 0)
        {

            StartCoroutine(Reload());
            return;
        }
        //lance shoot si appuie sur clic gauche
        if (Input.GetButton("Fire1") && !pM.isRunning)
        {
            animator.SetBool("Shoot", true);
            Shoot();
        }
        else
        {
            animator.SetBool("Shoot", false);
        }

        if (Input.GetButton("Fire2"))
        {
            animator.SetBool("Scope", true);
        }
        else
        {
            animator.SetBool("Scope", false);
        }

        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Move(y, x);

        if (pM.isRunning)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        currentAmmoCounter.text = currentAmmo.ToString();

    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadingText.SetActive(true);

        animator.SetBool("Scope", false);
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
        reloadingText.SetActive(false);
    }

    void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            muzzleFlash.Play();

            currentAmmo--;

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Enemy target = hit.transform.GetComponent<Enemy>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                if (!hit.collider.gameObject.CompareTag("Player"))
                {
                    GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 0.7f);
                }
            }
            nextTimeToFire = Time.time + 1f / fireSpeed;
        }

    }

    private void Move(float y, float x)
    {
        animator.SetFloat("VelY", y);
        animator.SetFloat("VelX", x);
    }

}

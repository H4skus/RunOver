using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStat : MonoBehaviour
{
    public PistolObject pistol;
    public bool canShoot;
    public float beetweenAttack;
    public ItemType ammo;
    public GameObject pos;
    EventText eventText;
    ParticleSystem muzzle;
    public AudioSource[] shoot;
    //public bool isZoomed = true;
    //public int zoom = 20;
    //public int normal = 60;
    //public float smooth = 5;

    private Animator anim;
    private float zoomAnimTime;
    public float ZoomAnimTime => zoomAnimTime;

    private void Start()
    {
        beetweenAttack = 0;
        ammo = pistol.ammoType;
        pos = GameObject.Find("PlayerCam");
        eventText = GameObject.Find("Ui").GetComponentInChildren<EventText>();
        muzzle = GameObject.Find("MuzzleFlash").GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        eventText.MagazineSize(pistol.MagazineSize);
        eventText.ReserveAmmo(pistol.ReserveAmmo);
        if (pistol.NextAttack >= beetweenAttack)
        {
            beetweenAttack += Time.deltaTime;
        }
        else
        {
            canShoot = true;
        }

    }

    public void Fire()
    {
        if (canShoot && pistol.ReserveAmmo > 0)
        {
            muzzle.Play();
            shoot[0].Play();
            RaycastHit hit;
            if (Physics.Raycast(pos.transform.position, pos.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(pos.transform.position, pos.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.tag);
                if (hit.transform.tag == "Enemy")
                {
                    hit.transform.gameObject.GetComponent<EnemyController>().TakeDamage(pistol.Damage);
                }
                else if (hit.transform.tag == "Box")
                {
                    hit.transform.gameObject.GetComponent<DestroyableBox>().TakeDamage(pistol.Damage);
                }
            }
            pistol.ReserveAmmo--;
            beetweenAttack = 0;
            canShoot = false;
        }
        else if (pistol.ReserveAmmo <= 0)
        {
            shoot[1].Play();
        }

    }

    public void Reload()
    {
        shoot[2].Play();
        pistol.ReserveAmmo = pistol.MagazineSize;
    }

    private void SetZoomInTime()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "ZoomIn")
            {
                zoomAnimTime = clip.length;
                return;
            }
        }
    }

    public void ZoomIn(bool zoomIn)
    {
        anim.SetBool("ZoomedIn", zoomIn);
    }
}

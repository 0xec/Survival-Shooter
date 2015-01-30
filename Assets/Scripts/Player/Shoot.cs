using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject gunBarrelEnd;
    public float rate = 0.2f;

    private bool isShooting = false;
    private Light gunLightEffect;
    private ParticleSystem gunParticleEffect;
    private LineRenderer gunBulletEffect;
    private int layerMask = 0;
    private float timeDelta = 0;



	void Start () {
        gunLightEffect = gunBarrelEnd.GetComponent<Light>();
        gunParticleEffect = gunBarrelEnd.GetComponent<ParticleSystem>();
        gunBulletEffect = gunBarrelEnd.GetComponent<LineRenderer>();
        layerMask = LayerMask.GetMask("Shootable");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (timeDelta < rate)
        {
            gunLightEffect.enabled = false;
            gunBulletEffect.enabled = false;
        }
        else
        {
            if (PlatformInput.GetFire())
            {
                
            }
            else
            {
                isShooting = false;
            }
            timeDelta = 0;
        }

        timeDelta += Time.deltaTime;
    }

    void Fire()
    {
        isShooting = true;
        gunParticleEffect.Play();
        gunLightEffect.enabled = isShooting;
        DrawBullet();
    }

    void StopFire()
    {

    }

    void DrawBullet()
    {
       // Vector3 offsetFix = new Vector3(0.42f, 0.35f, 0);
        Ray shootRay = new Ray();
       
        gunBulletEffect.SetPosition(0, gunBarrelEnd.transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        RaycastHit shootHit;
        if (Physics.Raycast(shootRay, out shootHit, 100, layerMask))
        {
            gunBulletEffect.SetPosition(1, shootHit.point);
            gunBulletEffect.enabled = true;
        }
    }
}

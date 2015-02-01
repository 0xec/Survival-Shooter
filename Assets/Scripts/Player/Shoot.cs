using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{

    public GameObject gunBarrelEnd;
    public GameObject bullet;
    public float rate = 0.2f;

    private float timer = 0.0f;
    private Light gunLightEffect;
    private ParticleSystem gunParticleEffect;
    private LineRenderer gunBulletEffect;
    private int layerMask = 0;

    void Start() {
        gunLightEffect = gunBarrelEnd.GetComponent<Light>();
        gunParticleEffect = gunBarrelEnd.GetComponent<ParticleSystem>();
        gunBulletEffect = gunBarrelEnd.GetComponent<LineRenderer>();
        layerMask = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if (PlatformInput.GetFire()) {
            if (timer >= rate) {
                Fire();
                Test();
            }

            if (timer > 0.1f) {
                StopFire();
            }
        } else {
            StopFire();
        }

        DrawBullet();
    }

    void Fire() { 
        gunParticleEffect.Play();
        gunLightEffect.enabled = true;
    //    gunBulletEffect.enabled = true;
        DrawBullet();
        timer = 0.0f;
    }

    void StopFire() {
        gunLightEffect.enabled = false;
        gunBulletEffect.enabled = false;
    }

    void DrawBullet() {

        Ray shootRay = new Ray();

        gunBulletEffect.SetPosition(0, gunBarrelEnd.transform.position);

        shootRay.origin = gunBarrelEnd.transform.position;
        shootRay.direction = transform.forward;

        RaycastHit shootHit;
        if (Physics.Raycast(shootRay, out shootHit, 100, layerMask))
        {
            // Quaternion q = new Quaternion();
            // q.SetFromToRotation(gunBarrelEnd.transform.position, shootHit.point);

            gunBulletEffect.SetPosition(1, shootHit.point);
        }
    }

    void Test()
    {
        Ray shootRay = new Ray();
        shootRay.origin = gunBarrelEnd.transform.position;
        shootRay.direction = transform.forward;

        RaycastHit shootHit;
        if (Physics.Raycast(shootRay, out shootHit, 100, layerMask))
        {
            Vector3 playerToMouse = shootHit.point - transform.position;

            playerToMouse.y = 0;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            Instantiate(bullet, gunBarrelEnd.transform.position, newRotatation);

        }


    }
}

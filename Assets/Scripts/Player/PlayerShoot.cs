using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{

    public GameObject gunBarrelEnd;
    public GameObject bullet;
    public float rate = 0.2f;

    private float timer = 0.0f;
    private Light gunLightEffect;
    private ParticleSystem gunParticleEffect;
    private LineRenderer gunBulletEffect;
    private int layerMask = 0;
    private PlayerHealth playerHealth;
    private float attackTimer = 0.0f;
    void Start() {
        gunLightEffect = gunBarrelEnd.GetComponent<Light>();
        gunParticleEffect = gunBarrelEnd.GetComponent<ParticleSystem>();
        gunBulletEffect = gunBarrelEnd.GetComponent<LineRenderer>();
        layerMask = LayerMask.GetMask("Shootable");
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (playerHealth.health <= 0)
            return;

        timer += Time.deltaTime;
        attackTimer += Time.deltaTime;
        if (PlatformInput.GetFire()) {
            if (timer >= rate) {
                Fire();
                //Bullet2();
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
        gunBulletEffect.enabled = true;
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
        shootRay.direction = gunBarrelEnd.transform.forward;

        Debug.DrawRay(shootRay.origin, shootRay.direction * 100);

        RaycastHit shootHit;
        if (Physics.Raycast(shootRay, out shootHit, 100, layerMask)) {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth && gunBulletEffect.enabled && attackTimer > rate) {
                enemyHealth.OnAttack();
                attackTimer = 0;
            }
            gunBulletEffect.SetPosition(1, shootHit.point);
        } else {
            gunBulletEffect.SetPosition(1, shootRay.origin + shootRay.direction * 100);
        }
    }

    void Bullet2() {
        Ray shootRay = new Ray();
        shootRay.origin = gunBarrelEnd.transform.position;
        shootRay.direction = transform.forward;

        RaycastHit shootHit;
        if (Physics.Raycast(shootRay, out shootHit, 100, layerMask)) {
            Vector3 playerToMouse = shootHit.point - transform.position;

            playerToMouse.y = 0;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
            Instantiate(bullet, gunBarrelEnd.transform.position, newRotatation);

        }


    }
}

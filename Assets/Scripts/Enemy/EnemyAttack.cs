using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float power = 10.0f;
    public float attackRate = 1.0f;
    private float attackTimeDelay = 0;
    private GameObject player;
    private PlayerHealth playerHealth;
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float dis = Vector3.Distance(transform.position, player.transform.position);
        bool attack = dis < 2.0f;
        if (attack && attackTimeDelay <= 0) {
            playerHealth.Damage(power);
            attackTimeDelay = attackRate;
        } else {
            attackTimeDelay -= Time.deltaTime;
        }
    }
}

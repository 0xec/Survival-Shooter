using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public float      enemyRate = 3.0f;
    private float     timeDelay = 0.0f;

    private EnemyManager enemyManager = null;
    // Use this for initialization
    void Start() {
        enemyManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (timeDelay > enemyRate && enemyManager.enemyCount < 100) {
            Instantiate(enemy, transform.position, transform.rotation);
            timeDelay = 0.0f;
            enemyManager.enemyCount++;
        }

        timeDelay += Time.deltaTime;
    }
}

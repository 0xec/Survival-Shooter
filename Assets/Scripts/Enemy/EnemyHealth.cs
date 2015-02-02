using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;
    public int score = 10;
    private ScoreManager scoreManager = null;
    private Animator animator;
    private EnemyManager enemyManager = null;
    void Start() {
        animator = GetComponent<Animator>();
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        enemyManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (health <= 0) {
            animator.SetTrigger("Die");
            scoreManager.score += score;
            score = 0; // 防止重复添加
            
        }
    }

    //void OnTriggerEnter(Collider other) {
    //    //if (other.gameObject.tag == "Bullet") {
    //    //    health -= 10;
    //    //}
    //}

    public void OnAttack()
    {
        health -= 10;
    }

    // 通过动画事件调用过来
    void EventDead()
    {
        enemyManager.enemyCount--;
        DestroyObject(gameObject);
    }
}

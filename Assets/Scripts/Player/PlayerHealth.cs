using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    // Use this for initialization
    public float health = 100.0f;
    public UI.Slider healthSlider;
    public UI.Button restartButton;
    public UI.Image damageImage;
    private Animator animator;
    private MissionManager mission;
    private Color flashColor = new Color(1.0f, 0.0f, 0.0f, 0.3f);


    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        healthSlider.value = (int)health;
        if (health <= 0)
        {
            damageImage.enabled = false;
            animator.SetTrigger("Die");
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, 4.0f * Time.deltaTime);
        }
    }

	public void Damage(float power)
    {
        damageImage.color = flashColor;
        health -= power;
    }
}

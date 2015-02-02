using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public UI.Text scoreText = null;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        scoreText.text = "Score: " + score.ToString();
    }
}

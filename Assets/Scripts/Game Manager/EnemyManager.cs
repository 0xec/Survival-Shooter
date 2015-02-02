using UnityEngine;
using System.Collections;
using UI = UnityEngine.UI;

public class EnemyManager : MonoBehaviour {

    public int enemyCount = 0;
    public UI.Text text = null;
    float deltaTime = 0.0f;
    float fps = 0.0f;
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Enemy Count: " + enemyCount.ToString();
        deltaTime += Time.deltaTime;
        deltaTime /= 2.0f;
        fps = 1.0f / deltaTime;
        text.text += ", FPS: " + fps.ToString();
    }
}

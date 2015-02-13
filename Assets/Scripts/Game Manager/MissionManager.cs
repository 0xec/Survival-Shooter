using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public void ReloadMission()
    {
		Debug.Log ("Reload Level");
        Application.LoadLevel(Application.loadedLevel);
    }
}

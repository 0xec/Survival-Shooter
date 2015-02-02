using UnityEngine;
using System.Collections;

public class MissionManager : MonoBehaviour {

	public void ReloadMission()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

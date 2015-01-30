using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    private LineRenderer lineRender = null;
	// Use this for initialization
	void Start () {
        lineRender = GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Ray cameraRay = Camera.main.ScreenPointToRay(PlatformInput.GetTargetPosition());
        print(cameraRay.origin);
        print(cameraRay.direction);
        lineRender.SetPosition(0, cameraRay.origin);
        lineRender.SetPosition(1, cameraRay.direction);
    }
}

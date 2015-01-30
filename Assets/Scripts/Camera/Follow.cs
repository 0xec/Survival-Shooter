using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public GameObject playerObject = null;
    private Vector3 positionOffset;
	// Use this for initialization
	void Start () {
        positionOffset = transform.position - playerObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + positionOffset, 0.2f);
    }
}

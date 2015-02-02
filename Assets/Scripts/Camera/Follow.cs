using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public GameObject playerObject = null;
    private Vector3 positionOffset;
  //  private Transform playerTransform;
	// Use this for initialization
	void Start () {
        positionOffset = transform.position - playerObject.transform.position;
   //     playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.Lerp(transform.position, playerObject.transform.position + positionOffset, 0.2f);

   //     Vector3 v = (playerTransform.position - transform.position);
   //     Debug.DrawRay(transform.position, v);

   //     RaycastHit hit;
   //     if (Physics.Raycast(new Ray(transform.position, v), out hit))
   //     {
			//if (hit.collider.tag != "Player") {
   //         	print(hit.collider.name);
   //             GameObject obj = hit.collider.gameObject;
   //             obj.renderer.material.shader = Shader.Find("Transparent/Bumped Specular");
   //         }
   //     }
    }
}

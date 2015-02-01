using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    public float bulletSpeed = 20.0f;
    public GameObject effect;

    // Use this for initialization
    void Start() {
        DestroyObject(gameObject, 5.0f);

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Shootable")
        {
           // DestroyObject(other.gameObject);
        }
        DestroyObject(gameObject);
        GameObject g = Instantiate(effect, transform.position, Quaternion.identity) as GameObject;
        DestroyObject(g, 1.0f);
    }

}

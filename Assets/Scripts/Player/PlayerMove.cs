using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 6.0f;

    private Animator animator = null;
    private int floorMask;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start() {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();

        PlatformInput.Init();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (playerHealth.health <= 0)
            return;

        //float x = PlatformInput.GetAxis("Horizontal");
        //float z = PlatformInput.GetAxis("Vertical");
        Vector3 v = PlatformInput.GetMoveDirection();
		        // 移动角色
        Movement(v.x, v.y);
        Rotate();
        UpdateAnimateState(v.x, v.y);
    }

    void Movement(float x, float z) {
        Vector3 movement = new Vector3(x, 0, z);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        //transform.Translate(movement, Space.World);
        rigidbody.MovePosition(transform.position + movement);
    }

    void Rotate() {
        // 第三人称
#if UNITY_ANDROID
        Vector3 v = PlatformInput.GetTargetPosition();
     //   Debug.Log(transform.position);
		if (v == Vector3.zero)
			v = transform.up;

        Vector3 playerToMouse = new Vector3(v.x, 0, v.y);
        Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);
        rigidbody.MoveRotation(newRotatation);
#else
        Ray cameraRay = Camera.main.ScreenPointToRay(PlatformInput.GetTargetPosition());
        RaycastHit floorHit;

        if (Physics.Raycast(cameraRay, out floorHit, 100, floorMask)) {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rigidbody.MoveRotation(newRotatation);
            // transform.rotation = newRotatation;
        }
#endif
    }

    void UpdateAnimateState(float x, float z) {
        float delta = Mathf.Abs(x) + Mathf.Abs(z);
        animator.SetBool("IsMoving", delta != 0);
    }
}

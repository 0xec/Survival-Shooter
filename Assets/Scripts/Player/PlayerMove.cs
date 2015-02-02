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
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (playerHealth.health <= 0)
            return;

        float x = PlatformInput.GetAxis("Horizontal");
        float z = PlatformInput.GetAxis("Vertical");

        // 移动角色
        Movement(x, z);
        Rotate();
        UpdateAnimateState(x, z);
    }

    void Movement(float x, float z) {
        Vector3 movement = new Vector3(x, 0, z);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        //transform.Translate(movement, Space.World);
        rigidbody.MovePosition(transform.position + movement);
    }

    void Rotate() {
        // 第三人称


        Ray cameraRay = Camera.main.ScreenPointToRay(PlatformInput.GetTargetPosition());
        RaycastHit floorHit;

        if (Physics.Raycast(cameraRay, out floorHit, 100, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;

            playerToMouse.y = 0;
            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            rigidbody.MoveRotation(newRotatation);
            // transform.rotation = newRotatation;
        }
    }

    void UpdateAnimateState(float x, float z) {
        float delta = Mathf.Abs(x) + Mathf.Abs(z);
        animator.SetBool("IsMoving", delta != 0);
    }
}

using UnityEngine;
using System.Collections;

public class PlatformInput : MonoBehaviour
{
    private static Joystick leftController;
    private static Joystick rightController;
    public static void Init() {

        GameObject obj = GameObject.FindGameObjectWithTag("LeftJoystick");
        if (obj)
            leftController = obj.GetComponent<Joystick>();

        obj = GameObject.FindGameObjectWithTag("RightJoystick");
        if (obj)
            rightController = obj.GetComponent<Joystick>();
    }
    public static Vector3 GetMoveDirection() {
        Vector3 v = new Vector3(0, 0, 0);
#if UNITY_ANDROID
        if (leftController) {
            v = leftController.position;
        }
#else
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        v = new Vector3(x, z, 0);
#endif
        return v;
    }

    public static Vector3 GetTargetPosition() {
        Vector3 v = new Vector3(0, 0, 0);
#if UNITY_ANDROID
        v = rightController.position;
#else
        v = Input.mousePosition;
#endif
        return v;
    }

    public static bool GetFire() {
#if UNITY_ANDROID
        return true;
#else
        return Input.GetButton("Fire1");
#endif
    }
}

using UnityEngine;
using System.Collections;

public class PlatformInput : MonoBehaviour
{
    private static Joystick leftController;
    private static Joystick rightController;
    public static void Init()
    {
        leftController = GameObject.FindGameObjectWithTag("LeftJoystick").GetComponent<Joystick>() ;
        rightController = GameObject.FindGameObjectWithTag("RightJoystick").GetComponent<Joystick>();
    }
    public static Vector3 GetMoveDirection() {
#if UNITY_ANDROID
       
        return leftController.position;
#else
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, 0, z);
#endif
    }

    public static Vector3 GetTargetPosition() {
#if UNITY_ANDROID
        return rightController.position;
#else
        return Input.mousePosition;
#endif

    }

    public static bool GetFire() {
#if UNITY_ANDROID
        return true;
#else
        return Input.GetButton("Fire1");
#endif
    }
}

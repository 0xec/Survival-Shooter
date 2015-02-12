using UnityEngine;
using System.Collections;

public class PlatformInput : MonoBehaviour
{
    private static Joystick leftController;
    private static Joystick rightController;
    public static void Init()
    {
		GameObject obj = GameObject.FindGameObjectWithTag ("LeftJoystick");
		if (obj) leftController = obj.GetComponent<Joystick>() ;

		obj = GameObject.FindGameObjectWithTag ("RightJoystick");
		if (obj) rightController = GameObject.FindGameObjectWithTag("RightJoystick").GetComponent<Joystick>();
    }
    public static Vector3 GetMoveDirection() {
#if UNITY_ANDROID
       
        return leftController.position;
#else
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return new Vector3(x, z, 0);
#endif
    }

    public static Vector3 GetTargetPosition() {
		return new Vector3 (0, 0, 0);
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

using UnityEngine;
using System.Collections;

public class PlatformInput : MonoBehaviour
{
    public static float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    public static Vector3 GetTargetPosition()
    {
        return Input.mousePosition;
    }

    public static bool GetFire()
    {
        return Input.GetButton("Fire1");
    }
}

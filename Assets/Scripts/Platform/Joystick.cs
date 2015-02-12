using UnityEngine;
using UnityEngine.UI;
//[RequireComponent(typeof(GUITexture))]
public class Joystick : MonoBehaviour
{
    public Vector2 position;
    public int tapCount;

    private Vector2 restorePosition_;
    private Image image;
    private RectTransform rectTransform;

    private Vector2 positionDelta;
    private bool activate;
    private Camera mainCamera;
    private int fingerID;
    void Start() {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        restorePosition_ = rectTransform.anchoredPosition;
        print(rectTransform.anchoredPosition);
    }

    void RestoreJoystickPosition() {
        position = new Vector2(0, 0);
        fingerID = 0;
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, restorePosition_, 0.3f);
    }

    void CalcuateRelatePosition() {
        Vector2 v = rectTransform.anchoredPosition - restorePosition_;
        position = v.normalized;
    }

    bool IsTouched() {
        bool bActivate = false;
        if (RuntimePlatform.WindowsEditor == Application.platform) {
            bActivate = Input.GetButton("Fire1");
        } else {
            bActivate = Input.touchCount > 0;

        }
        return bActivate;
    }

    bool IsActivate() {
        bool bActivate = false;
        if (RuntimePlatform.WindowsEditor == Application.platform) {
            bActivate = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, mainCamera);
        } else {
            // 检查触控
            for (int idx = 0; idx < Input.touchCount; ++idx) {
                Touch touch = Input.touches[idx];
                bActivate = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position, mainCamera);
                if (bActivate) {
                    Debug.Log("Finger ID: " + touch.fingerId);
                    fingerID = touch.fingerId;
                    break;
                }
            }

        }

        return bActivate;
    }

    Vector2 GetFingerPosition() {
        Vector2 v = new Vector2(0, 0);
        if (RuntimePlatform.WindowsEditor == Application.platform) {
            v = Input.mousePosition;
        } else {
            // 检查触控
            for (int idx = 0; idx < Input.touchCount; ++idx) {
                Touch touch = Input.touches[idx];
                if (touch.fingerId == fingerID) {
                    v = touch.position;
                }
            }

        }
        return v;
    }

    void FixedUpdate() {
        if (IsTouched() && IsActivate() && !activate) {
            Debug.Log("press");
            Debug.Log(GetFingerPosition());
            positionDelta = GetFingerPosition() - rectTransform.anchoredPosition;
            activate = true;
        }

        if (!IsTouched() && activate) {
            Debug.Log("release");
            activate = false;
        }

        if (activate) {
            Debug.Log("position: " + GetFingerPosition());
            rectTransform.anchoredPosition = GetFingerPosition() + positionDelta;
            CalcuateRelatePosition();
        } else {
            RestoreJoystickPosition();
        }


    }
}
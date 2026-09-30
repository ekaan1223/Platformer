using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Hides and locks the mouse cursor so mouse-look works. Esc releases it, clicking re-locks it.
/// Put this on any object in the scene (e.g. the player).
/// </summary>
public class CursorLocker : MonoBehaviour
{
    [SerializeField] private bool lockOnStart = true;

    private void Start()
    {
        if (lockOnStart) SetLocked(true);
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;

        if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame) SetLocked(false);
        else if (mouse != null && mouse.leftButton.wasPressedThisFrame && Cursor.lockState != CursorLockMode.Locked)
        {
            SetLocked(true);
        }
    }

    private static void SetLocked(bool locked)
    {
        Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !locked;
    }
}

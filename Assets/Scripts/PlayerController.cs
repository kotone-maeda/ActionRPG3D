using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;   // 力の大きさ（Inspectorで調整可）
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 物理演算はFixedUpdateで処理
    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        Vector3 dir = Vector3.zero;

        if (Keyboard.current.wKey.isPressed) dir += Vector3.forward;
        if (Keyboard.current.sKey.isPressed) dir += Vector3.back;
        if (Keyboard.current.aKey.isPressed) dir += Vector3.left;
        if (Keyboard.current.dKey.isPressed) dir += Vector3.right;

        if (dir.sqrMagnitude > 1f)
            dir.Normalize();
        rb.AddForce(dir * moveForce, ForceMode.Acceleration);
    }
}

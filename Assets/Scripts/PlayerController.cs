using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveForce = 10f; // WASDで加える力の大きさ

    private Rigidbody rb;
    private Animator animator;

    // Updateで作った入力結果を物理用にバッファ
    private Vector3 heldDir = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // ---- 入力・アニメはフレーム更新で処理 ----
    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        // 押されている間の入力方向（ワールド前後左右）
        Vector3 dir = Vector3.zero;
        if (k.wKey.isPressed) dir += Vector3.forward;
        if (k.sKey.isPressed) dir += Vector3.back;
        if (k.dKey.isPressed) dir += Vector3.right;
        if (k.aKey.isPressed) dir += Vector3.left;
        if (dir.sqrMagnitude > 1f) dir.Normalize();
        heldDir = dir; // FixedUpdate用に保持

        // --- アニメーション（押下状態から算出） ---
        // 元コードの意図を踏襲：W/SでRun、AでRunLeft、DでRunRight
        bool run      = k.wKey.isPressed || k.sKey.isPressed;
        bool runLeft  = k.aKey.isPressed;
        bool runRight = k.dKey.isPressed;

        animator.SetBool("Run",      run);
        animator.SetBool("RunLeft",  runLeft);
        animator.SetBool("RunRight", runRight);

        // 参考：離した瞬間のログ（必要ならここでワンショット処理を）
        if (k.wKey.wasReleasedThisFrame)
        {
            Debug.Log("W Released");
            // 例）離した瞬間に減速/停止させたいならここでフラグを立てる
        }
    }

    // ---- 物理は固定タイミングで処理 ----
    void FixedUpdate()
    {
        if (heldDir.sqrMagnitude > 0f)
        {
            rb.AddForce(heldDir * moveForce, ForceMode.Acceleration);
        }
    }
}

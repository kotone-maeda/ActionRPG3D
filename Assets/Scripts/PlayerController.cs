using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    [Header("Move")]
    public float moveForce = 10f; // WASDで加える力の大きさ
    public TextMeshProUGUI HPText;
    [Header("Attack")]
    [SerializeField] float attackCooldown = 0.35f; // 連打抑制したいとき
    float nextAttackTime = 0f;
    private Rigidbody rb;
    private Animator animator;
    private int currentHP;

    // Updateで作った入力結果を物理用にバッファ
    private Vector3 heldDir = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentHP = playerStatusSO.HP;
        HPText.text = "HP: " + currentHP.ToString();
    }

    // ---- 入力・アニメはフレーム更新で処理 ----
    void Update()
    {
        HPText.text = "HP: " + currentHP.ToString();
        var k = Keyboard.current;
        var m = Mouse.current;
        if (k == null || m == null) return;

        // ---- 攻撃：右クリックの「押された瞬間」
        if (m.rightButton.wasPressedThisFrame && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");      // ← Trigger を使うのが楽
            nextAttackTime = Time.time + attackCooldown;
        }

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
        bool run = k.wKey.isPressed || k.sKey.isPressed;
        bool runLeft = k.aKey.isPressed;
        bool runRight = k.dKey.isPressed;

        animator.SetBool("Run", run);
        animator.SetBool("RunLeft", runLeft);
        animator.SetBool("RunRight", runRight);
    }

    // ---- 物理は固定タイミングで処理 ----
    void FixedUpdate()
    {
        if (heldDir.sqrMagnitude > 0f)
        {
            rb.AddForce(heldDir * moveForce, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        currentHP -= 10;
    }
}

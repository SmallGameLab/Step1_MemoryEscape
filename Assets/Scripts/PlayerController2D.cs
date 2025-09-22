/*
[スクリプト名] PlayerController2D.cs
役割: 見下ろし2Dの移動 + アニメ連動。入力した瞬間にWalkへ切り替わるよう最適化。
使い方: Playerにアタッチ。Rigidbody2D / BoxCollider2D / Animator（Player.controller）を設定。
*/
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.8f;

    Rigidbody2D rb;
    Animator anim;

    Vector2 uiInput;     // 仮想パッド用（未使用なら (0,0)）
    Vector2 keyInput;    // PCデバッグ用
    Vector2 lastDir = Vector2.down;
    Vector2 currentInput; // ★ 物理用に保持

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true;

        // ★ Animatorはフレームごとに更新（遅延を減らす）
        //   Inspectorの Animator → Update Mode が「Normal」になっているか確認。
    }

    public void SetMoveInput(Vector2 v) => uiInput = Vector2.ClampMagnitude(v, 1f);

    void Update()
    {
        // 入力を読む（1フレームごと）
        keyInput.x = Input.GetAxisRaw("Horizontal");
        keyInput.y = Input.GetAxisRaw("Vertical");

        Vector2 input = uiInput.sqrMagnitude > 0.01f ? uiInput : keyInput;
        if (input.sqrMagnitude > 1f) input.Normalize();

        // ★ このフレームで Animator に反映（遅延を無くす）
        float spd = input.magnitude;
        if (spd > 0.001f) // しきい値を小さく
        {
            lastDir = input.normalized;
            anim.SetFloat("moveX", lastDir.x);
            anim.SetFloat("moveY", lastDir.y);
        }
        anim.SetFloat("speed", spd);
        anim.SetFloat("lastX", lastDir.x);
        anim.SetFloat("lastY", lastDir.y);

        // ★ 物理用に保持（FixedUpdateで使う）
        currentInput = input;
    }

    void FixedUpdate()
    {
        // 物理は物理フレームで処理（見た目はUpdate側で即時反映済み）
        rb.velocity = currentInput * moveSpeed;
    }
}

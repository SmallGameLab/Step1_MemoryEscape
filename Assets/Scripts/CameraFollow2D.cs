/*
[スクリプト名] CameraFollow2D.cs
役割: カメラがプレイヤーを少し遅れて追いかける（見やすくする）。
使い方: Main Cameraにアタッチ。Inspectorの target に Player をドラッグして入れる。
初心者メモ:
- LateUpdate は「物が動いた後」に呼ばれるので、追いかけ表示が安定します。
- smoothTime は大きいほどゆっくり追いつきます。
*/
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [SerializeField] Transform target;   // 追いかける対象（Player）
    [SerializeField] float smoothTime = 0.12f; // 追いつく速さ（0.1〜0.2が無難）

    Vector3 velocity; // SmoothDamp用の内部データ

    void LateUpdate()
    {
        if (!target) return;

        // Zはカメラのまま（2DはZ=-10固定）
        Vector3 now = transform.position;
        Vector3 goal = new Vector3(target.position.x, target.position.y, now.z);

        // 少し遅れてふわっと追いつく
        transform.position = Vector3.SmoothDamp(now, goal, ref velocity, smoothTime);
    }
}

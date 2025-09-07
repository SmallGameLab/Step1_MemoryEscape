/*
[スクリプト名] BootLoader.cs
役割: アプリ起動時（Bootシーン）に、指定した最初のシーン（例: Title）へ移動する
使い方: Bootシーンの空のGameObjectにアタッチ。Inspectorの firstScene に遷移先のシーン名を入れる
初心者メモ:
- Awakeはシーンが読み込まれてすぐ1回だけ呼ばれる。ここで60fps固定などの初期設定をする
- StartはAwakeのあとに1回呼ばれる。ここでシーン遷移を実行する
- よくあるミス: Build Settings に遷移先シーンを入れ忘れると動かない
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootLoader : MonoBehaviour
{
    [SerializeField, Tooltip("起動後に最初に開くシーン名")]
    string firstScene = "Title";

    void Awake()
    {
        // 60fps固定。vSyncを切ってフレームレートをアプリ側で指定
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    void Start()
    {
        // 指定したシーンに切り替え
        SceneManager.LoadScene(firstScene);
    }
}

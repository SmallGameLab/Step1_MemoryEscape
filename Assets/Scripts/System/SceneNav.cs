/*
[スクリプト名] SceneNav.cs
役割: UIボタンからシーン遷移を簡単に呼び出す
使い方: Title/Stage1/Result などのCanvas（または空オブジェクト）にアタッチし、ButtonのOnClickで関数を選ぶ
初心者メモ:
- publicメソッドはButtonのOnClickに表示される
- シーン名はBuild Settingsに必ず追加しておく
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNav : MonoBehaviour
{
    // タイトルへ戻る
    public void LoadTitle() => SceneManager.LoadScene("Title");
    // ステージ1へ
    public void LoadStage1() => SceneManager.LoadScene("Stage1");
    // リザルトへ
    public void LoadResult() => SceneManager.LoadScene("Result");
}

/*
[スクリプト名] SaveSystem.cs
役割: PlayerPrefsを使った簡易セーブ。例として「視覚A取得の有無」を保存/読み込みする
使い方: どこからでも SaveSystem.VisualA = true; のように使える（staticクラス）
初心者メモ:
- PlayerPrefs はキーと数字/文字列を端末に保存する仕組み
- 後でJSON保存に置き換える前提の“仮”として使う
*/
using UnityEngine;

public static class SaveSystem
{
    const string KeyVisualA = "visual_A";  // キー名（被らないように英数で）

    // 視覚Aを取得済みか
    public static bool VisualA
    {
        get => PlayerPrefs.GetInt(KeyVisualA, 0) == 1;
        set { PlayerPrefs.SetInt(KeyVisualA, value ? 1 : 0); PlayerPrefs.Save(); }
    }

    // すべて初期化（開発中のやり直し用）
    public static void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}

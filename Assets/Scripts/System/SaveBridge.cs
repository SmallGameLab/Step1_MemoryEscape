/*
[スクリプト名] SaveBridge.cs
役割: staticメソッド（SaveSystem.ResetAll）をUIボタンから呼び出せる形にする
使い方: Titleシーンなどの空オブジェクトにアタッチ。ButtonのOnClickで ResetAll を指定
初心者メモ:
- Buttonは「コンポーネントのpublicメソッド」しか選べないため、staticを直接呼びにくい
- そのため中継ぎのコンポーネントを作って呼ぶ
*/
using UnityEngine;

public class SaveBridge : MonoBehaviour
{
    public void ResetAll() => SaveSystem.ResetAll();
}

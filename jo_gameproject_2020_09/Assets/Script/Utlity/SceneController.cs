using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> シーン切り替え用、便利系スクリプト
/// UIのボタンから使いたい場合そのままシーンに置いても問題ないです
/// </summary>
public class SceneController : MonoBehaviour
{
    private AsyncOperation operation;
    private string nextSceneName;

    /// <summary> ロードの進行度を返す (Unityの仕様で0.9が最大)
    /// </summary>
    public float Progress { get { return operation?.progress ?? 0; } }

    /// <summary> 同期シーン切り替え
    /// </summary>
    /// <param name="nextSceneName">次のシーン名</param>
    public void ChangeScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    /// <summary> 非同期で次のシーンをロード
    /// </summary>
    /// <param name="nextSceneName">次のシーン名</param>
    public void LoadScene(string nextSceneName)
    {
        this.nextSceneName = nextSceneName;
        StartCoroutine(AsyncLoading());
    }

    /// <summary> ロードしたシーンに切り替え
    /// </summary>
    public void ChangeSceneAsync()
    {
        //切り替えを許可する
        operation.allowSceneActivation = true;
    }

    // 非同期ロード処理
    private IEnumerator AsyncLoading()
    {
        //自動で切り替えない
        operation = SceneManager.LoadSceneAsync(nextSceneName);
        operation.allowSceneActivation = false;
        yield return operation;
    }


}

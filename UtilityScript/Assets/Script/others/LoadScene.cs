using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    private AsyncOperation async;

    [SerializeField]
    private GameObject gameObject;

    // Start is called before the first frame update
    public void NextScene(string scene)
    {
        //　コルーチンを開始
        StartCoroutine("LoadData", scene);
    }


    IEnumerator LoadData(string scenes)
    {// 非同期でロード開始
        async = SceneManager.LoadSceneAsync(scenes);
        gameObject.SetActive(false);

        // デフォルトはtrue。ロード完了したら勝手にシーンきりかえ発生しないよう設定。
        async.allowSceneActivation = false;

        // 非同期読み込み中の処理
        while (!async.isDone)
        {
            float progress = async.progress;
            Debug.Log(progress);

            if (progress == 0.9f)
            {
                Debug.Log("終了");
                gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    async.allowSceneActivation = true; yield break;
                }

               
            }

            yield return null;
        }
        yield break;
    }
}

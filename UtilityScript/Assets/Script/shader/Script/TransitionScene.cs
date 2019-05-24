using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TransitionScene :SingletonMonoBehaviour<TransitionScene>
{
    [SerializeField]
    private Material _transitionIn;//

    private void Awake()
    {
        if (this != Instance)
        {
            Destroy(this);

            Debug.LogError(
               "継承先のスクリプト名" +
                " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
                " アタッチされているGameObjectは " + Instance.gameObject.name + " です.");
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void TransitionSceneChange(string next)
    {
        StartCoroutine(BeginTransition(next));
    }
    IEnumerator BeginTransition(string NextScene)
    {
        yield return Animate(_transitionIn, 1,NextScene);
    }///

    /// <summary>
    /// time秒かけてトランジションを行う
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator Animate(Material material, float time,string NextScene)
    {
        GetComponent<Image>().material = material;
        float current = 0;
        while (current < time)
        {
            material.SetFloat("_Alpha", current / time);
            yield return new WaitForEndOfFrame();
            current += Time.deltaTime;
        }
        material.SetFloat("_Alpha", 1);
        SceneManager.LoadSceneAsync(NextScene);
        material.SetFloat("_Alpha", 0);
    }
}
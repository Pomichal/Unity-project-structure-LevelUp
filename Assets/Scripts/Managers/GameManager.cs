using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        App.gameManager = this;
        StartCoroutine(LoadSceneAsync("UIScene", new ShowScreenCommand<MenuScreen>()));
    }

    // load level X

    // unload level X


    IEnumerator LoadSceneAsync(string sceneName, ICommand afterSceneLoadedCommand = null)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loading.allowSceneActivation = false;
        while(!loading.isDone)
        {
            if(loading.progress >= 0.9f && !loading.allowSceneActivation)
            {
                loading.allowSceneActivation = true;
            }
            yield return null;
        }
        // loading done
        Debug.Log($"scene {sceneName} loaded");

        if(afterSceneLoadedCommand != null)
        {
            afterSceneLoadedCommand.Execute();
        }
    }
}

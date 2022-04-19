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
        StartCoroutine(LoadSceneAsync("UIScene",
                    new List<ICommand>{new ShowScreenCommand<MenuScreen>()}));
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadSceneAsync(name,
                    new List<ICommand>
                    {
                        new SetLevelCommand(name),
                        new ShowScreenCommand<InGameScreen>(),
                    }));
    }

    public void UnloadLevel(string name)
    {
        StartCoroutine(UnloadSceneAsync(name,
                    new List<ICommand>{new ShowScreenCommand<MenuScreen>()}));

    }

    IEnumerator LoadSceneAsync(string sceneName, List<ICommand> afterSceneLoadedCommands = null)
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

        if(afterSceneLoadedCommands != null)
        {
            foreach(ICommand command in afterSceneLoadedCommands)
            {
                command.Execute();
            }
        }
    }

    IEnumerator UnloadSceneAsync(string sceneName, List<ICommand> afterSceneUnloadedCommands = null)
    {
        AsyncOperation loading = SceneManager.UnloadSceneAsync(sceneName);
        while(!loading.isDone)
        {
            yield return null;
        }
        //
        // loading done
        Debug.Log($"scene {sceneName} unloaded");

        if(afterSceneUnloadedCommands != null)
        {
            foreach(ICommand command in afterSceneUnloadedCommands)
            {
                command.Execute();
            }
        }
    }
}

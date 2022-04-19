using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private string currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        App.levelManager = this;
    }

    public string GetLevel()
    {
        return currentLevel;
    }

    public void SetLevel(string level)
    {
        currentLevel = level;
    }

}

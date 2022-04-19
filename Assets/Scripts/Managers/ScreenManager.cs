using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    private ScreenBase[] screens;

    // Start is called before the first frame update
    void Start()
    {
        screens = GetComponentsInChildren<ScreenBase>(true);
        App.screenManager = this;
    }

    public void Show<T>()
    {
        foreach(ScreenBase screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Show();
            }
        }
    }

    public void Hide<T>()
    {
        foreach(ScreenBase screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Hide();
            }
        }
    }

}

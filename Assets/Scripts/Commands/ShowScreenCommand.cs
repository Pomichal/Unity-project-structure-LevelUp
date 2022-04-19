using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScreenCommand<T> : ICommand
{
    public void Execute()
    {
        App.screenManager.Show<T>();
    }
}

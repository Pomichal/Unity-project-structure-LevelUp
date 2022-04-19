using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameScreen : ScreenBase
{

    public TextMeshProUGUI levelNameText;

    public override void Show()
    {
        base.Show();
        levelNameText.text = "Level: " + App.levelManager.GetLevel();
    }

    public void ReturnToMenu()
    {
        App.gameManager.UnloadLevel(App.levelManager.GetLevel());
        Hide();
    }
}

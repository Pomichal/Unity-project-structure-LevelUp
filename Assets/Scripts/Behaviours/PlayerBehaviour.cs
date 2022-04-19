using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    private PlayerModel model;

    void Start()
    {
        model = new PlayerModel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            model.GetCoins();
            // get coin
        }
    }
}

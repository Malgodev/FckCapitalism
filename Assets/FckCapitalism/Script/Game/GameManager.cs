using Malgo.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public override void Init()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
    }
}

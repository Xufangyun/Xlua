using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLanch : Singleton<GameLanch>
{
    public override void Awake()
    {
        base.Awake();

        //TODO:初始化游戏框架
        gameObject.AddComponent<xLuaMgr>();
    }

    IEnumerator checkHotUpdate()
    {
        yield return 0;
    }

    IEnumerator GameStart()
    {
        yield return StartCoroutine(checkHotUpdate());

        //TODO:进入游戏，lua虚拟机，进入lua逻辑，跑起来；
        xLuaMgr.Instance.EnterGame();
    }

    private void Start()
    {
        StartCoroutine(GameStart());

        //end

        //进入游戏
        //end
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using XLua;

public class xLuaMgr : Singleton<xLuaMgr>
{
    LuaEnv env = null;

    private bool isGameStarted = false;

    public override void Awake()
    {
        base.Awake();
        InitLuaEnv();
    }

    private void InitLuaEnv()
    {
        env = new LuaEnv();
        isGameStarted = false;
    }

    public void EnterGame()
    {
        isGameStarted = true;
        //������Ϸ�߼�����lua����
        env.DoString("print (\"Hello worl\")");
    }
}

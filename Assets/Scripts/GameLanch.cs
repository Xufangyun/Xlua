using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLanch : Singleton<GameLanch>
{
    public override void Awake()
    {
        base.Awake();

        //TODO:��ʼ����Ϸ���
        gameObject.AddComponent<xLuaMgr>();
    }

    IEnumerator checkHotUpdate()
    {
        yield return 0;
    }

    IEnumerator GameStart()
    {
        yield return StartCoroutine(checkHotUpdate());

        //TODO:������Ϸ��lua�����������lua�߼�����������
        xLuaMgr.Instance.EnterGame();
    }

    private void Start()
    {
        StartCoroutine(GameStart());

        //end

        //������Ϸ
        //end
    }
}

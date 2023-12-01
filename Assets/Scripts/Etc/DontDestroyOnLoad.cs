using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // 파괴하지 않을 오브젝트 생성
        GuideDontDestroyOnLoad();
        SoundManagerDontDestroyOnLoad();
    }

    // DontDestroyOnLoad();
    // -> 유니티는 Scene에서 다른 Scene으로 넘어갈 때 기존 Scene에 있던 오브젝트는 모두 '파괴'함
    // -> 그래서 다른 Scene으로 넘어가도 파괴되지 않고 계속 남아있게 하는 코드가 필요함

    // Guide 오브젝트를 파괴하지 않게 함
    private void GuideDontDestroyOnLoad()
    {
        // 게임 오브젝트들 중에서 Guide 태그를 지닌 오브젝트를 찾음
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Guide");

        // 만약 해당 오브젝트의 개수가 1개면 (다른 중복 오브젝트가 없다면) 파괴하지 않게 함
        if (objs.Length == 1) { DontDestroyOnLoad(objs[0]); }
        else // 중복 오브젝트가 있으면
        {
            for (int index = 1; index < objs.Length; index++) { Destroy(objs[index]); } // 중복 오브젝트를 파괴함
        }
    }

    // SoundManager 오브젝트를 파괴하지 않게 함
    private void SoundManagerDontDestroyOnLoad()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");

        if (objs.Length == 1) { DontDestroyOnLoad(objs[0]); }
        else
        {
            for (int index = 1; index < objs.Length; index++)
            {
                Destroy(objs[index]);
            }
        }
    }
}

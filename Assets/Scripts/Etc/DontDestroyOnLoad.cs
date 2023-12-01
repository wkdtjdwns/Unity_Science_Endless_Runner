using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        // �ı����� ���� ������Ʈ ����
        GuideDontDestroyOnLoad();
        SoundManagerDontDestroyOnLoad();
    }

    // DontDestroyOnLoad();
    // -> ����Ƽ�� Scene���� �ٸ� Scene���� �Ѿ �� ���� Scene�� �ִ� ������Ʈ�� ��� '�ı�'��
    // -> �׷��� �ٸ� Scene���� �Ѿ�� �ı����� �ʰ� ��� �����ְ� �ϴ� �ڵ尡 �ʿ���

    // Guide ������Ʈ�� �ı����� �ʰ� ��
    private void GuideDontDestroyOnLoad()
    {
        // ���� ������Ʈ�� �߿��� Guide �±׸� ���� ������Ʈ�� ã��
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Guide");

        // ���� �ش� ������Ʈ�� ������ 1���� (�ٸ� �ߺ� ������Ʈ�� ���ٸ�) �ı����� �ʰ� ��
        if (objs.Length == 1) { DontDestroyOnLoad(objs[0]); }
        else // �ߺ� ������Ʈ�� ������
        {
            for (int index = 1; index < objs.Length; index++) { Destroy(objs[index]); } // �ߺ� ������Ʈ�� �ı���
        }
    }

    // SoundManager ������Ʈ�� �ı����� �ʰ� ��
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public bool[] solution_unlock_list;

    public bool is_btb;
    public bool is_methyl;

    private void Awake()
    {
        // bool ����Ʈ ���� �� bool ���� �ʱ�ȭ
        solution_unlock_list = new bool[3];

        is_btb = false;
        is_methyl = false;
    }

    public void Unlock()
    {
        // ������ ����ٴ� ��ȣ�� ������
        // � ����� �־��������� ���� (ExperimentButtonManager�� PutSolutions() �޼ҵ� ����)
        // ������ �������
        if (is_btb) { solution_unlock_list[0] = true; }
        else if (is_methyl) { solution_unlock_list[1] = true; }
        else { solution_unlock_list[2] = true; }
    }
}

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
        // bool 리스트 변수 및 bool 변수 초기화
        solution_unlock_list = new bool[3];

        is_btb = false;
        is_methyl = false;
    }

    public void Unlock()
    {
        // 정답을 맞췄다는 신호를 받으면
        // 어떤 용액을 넣었었는지에 따라서 (ExperimentButtonManager의 PutSolutions() 메소드 참고)
        // 도감을 언락해줌
        if (is_btb) { solution_unlock_list[0] = true; }
        else if (is_methyl) { solution_unlock_list[1] = true; }
        else { solution_unlock_list[2] = true; }
    }
}

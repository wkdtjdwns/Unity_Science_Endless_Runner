using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] item_prefabs;
    [SerializeField]
    private Transform[] spawn_points;

    private bool is_spawn;
    private GameObject cur_item;

    private void Awake() { is_spawn = false; }

    // 생성되고 있다는 신호가 없는 상태라면 아이템을 생성하는 Coroutine 함수를 실행함
    private void Update() { if (!is_spawn) { StartCoroutine("SpawnItem"); } }

    // 어떤 아이템을 생성할지 랜덤으로 결정하고
    // 결정된 아이템 오브젝트를 리턴함
    private GameObject DecideItem()
    {
        int ran_index = Random.Range(0, item_prefabs.Length);

        return item_prefabs[ran_index];
    }

    private IEnumerator SpawnItem()
    {
        // 생성되고 있다는 신호를 줌
        is_spawn = true;

        // 랜덤한 시간 동안 기다리게 한 후
        float ran_time = Random.Range(5f, 7.5f);

        yield return new WaitForSeconds(ran_time);

        // 랜덤한 위치를 설정하고
        int ran_index = Random.Range(0, spawn_points.Length);

        // 생성되고 있다는 신호를 끔
        is_spawn = false;

        // 리턴 받은 아이템 오브젝트를 위에서 결정한 위치에 생성함
        Instantiate(DecideItem(), spawn_points[ran_index].position, Quaternion.identity);
    }
}

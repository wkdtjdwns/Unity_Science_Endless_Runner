using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : GameManager
{
    [SerializeField]
    private Slider health_slider;

    RunningGameManager game_manager;
    RunningPlayer player;

    private void Awake()
    {
        // 플레이어 체력 슬라이더를 직접 건들여서 값을 바꿀 수 없게 설정함
        health_slider.interactable = false;

        game_manager = GameObject.Find("GameManager").gameObject.GetComponent<RunningGameManager>();
        player = GameObject.Find("Player").gameObject.GetComponent<RunningPlayer>();
    }

    private void OnEnable()
    {
        // 값을 초기화 함
        health_slider.maxValue = player.health;
        health_slider.value = health_slider.maxValue;
    }

    // 체력 슬라이더의 값을 플레이어의 체력 값으로 만듦
    private void Update() { health_slider.value = player.health; }

    void SliderUpdate() { health_slider.value = player.health; }
}

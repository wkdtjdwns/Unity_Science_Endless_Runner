using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // 다른 클래스에서도 쉽게 접근할 수 있도록 함
    public static SoundManager instance;

    [SerializeField]
    private AudioClip[] bgm_clips;
    [SerializeField]
    private AudioClip[] audio_clips;

    public float bgm_volume;
    public float sfx_volume;

    public AudioSource bgm_player;
    public AudioSource sfx_player;

    private void Awake()
    {
        instance = this;

        bgm_volume = 0.5f;
        sfx_volume = 0.5f;

        bgm_player = GameObject.Find("Bgm Player").gameObject.GetComponent<AudioSource>();
        sfx_player = GameObject.Find("Sfx Player").gameObject.GetComponent<AudioSource>();

        PlayBgm("start");
    }

    private void Update()
    {
        // 언제든지 볼륨을 조절할 수 있게함
        ChangeBgmSound();
        ChangeSfxSound();
    }

    public void PlaySound(string type)
    {
        int index = 0;

        // 타입에 따라서 다른 사운드를 플레이함
        switch (type)
        {
            case "button":  index = 0; break;
            case "get solution": index = 1; break;
            case "sell": index = 2; break;
            case "easter 3": index = 3; break;
            case "correct": index = 4; break;
            case "wrong": index = 5; break;
            case "purchase": index = 6; break;
            case "jump": index = 7; break;
            case "need": index = 8; break;
            case "talk": index = 9; break;
            case "sound hear": index = 10; break;
            case "mix solution": index = 11; break;
            case "put solution": index = 12; break;
            case "put goods": index = 13; break;
        }

        sfx_player.clip = audio_clips[index];

        // 1가지가 아닌 여러가지 사운드가 겹쳐도 모두 실행함
        sfx_player.PlayOneShot(sfx_player.clip);
    }

    public void PlayBgm(string type)
    {
        int index = 0;

        // 타입에 따라서 다른 사운드를 플레이함
        switch (type)
        {
            case "start": index = 0; break;
            case "home": index = 1; break;
            case "running": index = 2; break;
            case "experiment": index = 3; break;
        }

        bgm_player.clip = bgm_clips[index];

        // 여러가지 사운드가 겹치면 마지막에 나오는 사운드만 실행함
        bgm_player.Play();
    }

    // Option에서 조절한 사운드 값을 적용시킴
    private void ChangeBgmSound() { bgm_player.volume = bgm_volume * 0.15f; }

    private void ChangeSfxSound() { sfx_player.volume = sfx_volume; }
}

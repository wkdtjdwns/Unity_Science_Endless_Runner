using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private GameObject option;

    [SerializeField]
    private Slider bgm_slider;
    [SerializeField]
    private Slider sfx_slider;

    public bool is_option;

    private void Start()
    {
        bgm_slider.value = SoundManager.instance.bgm_volume;
        sfx_slider.value = SoundManager.instance.sfx_volume;

        is_option = false;

        // 각 슬라이더의 값이 바뀌었을 때 실행할 메소드 설정
        bgm_slider.onValueChanged.AddListener(ChangeBgmSound);
        sfx_slider.onValueChanged.AddListener(ChangeSfxSound);
    }

    private void Update() { if (Input.GetKeyDown(KeyCode.Escape)) { OptionOnOff(); } }
    
    // 옵션창을 껐다 켰다함
    public void OptionOnOff()
    {
        SoundManager.instance.PlaySound("button");

        is_option = !is_option;

        option.SetActive(is_option);

        Time.timeScale = is_option ? 0 : 1;
    }

    // bgm, sfx의 사운드 볼륨을 조절함
    private void ChangeBgmSound(float value) { SoundManager.instance.bgm_volume = value; }

    private void ChangeSfxSound(float value) { SoundManager.instance.sfx_volume = value; }
}

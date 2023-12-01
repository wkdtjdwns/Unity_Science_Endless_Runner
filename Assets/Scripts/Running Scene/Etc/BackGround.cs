using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // material을 이용한 무한 맵을 위한 클래스

    private float offset;
    [SerializeField]
    private float speed;

    private MeshRenderer render;

    private void Awake()
    {
        speed = 0.25f;

        render = GetComponent<MeshRenderer>();
    }

    private void Update() { BackGroundMove(); }

    void BackGroundMove()
    {
        offset += Time.deltaTime * speed;

        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

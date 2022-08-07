using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * <참고> 
 * 1. https://jrady.tistory.com/7
 * 2. https://ncube-studio.tistory.com/entry/%ED%8E%98%EC%9D%B4%EB%93%9C%EC%9D%B8Fade-In-%ED%8E%98%EC%9D%B4%EB%93%9C%EC%95%84%EC%9B%83Fade-Out-%ED%82%A4%EC%99%80-%EB%B2%84%ED%8A%BC%EC%9C%BC%EB%A1%9C-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%ED%88%AC%EB%AA%85%ED%95%98%EA%B2%8C-%EB%A7%8C%EB%93%A4%EA%B8%B0%EC%9C%A0%EB%8B%88%ED%8B%B0-2D%EA%B8%B0%EC%B4%88%EA%B0%95%EC%A2%8C-Unity-C-ScriptAlpha-Opacity
 * 
 */
public class SpiralStairsController : MonoBehaviour
{
    [SerializeField] float Delay = 5.0f;
    [SerializeField] float DelayNum = 10.0f; // 10번에 걸쳐서 점차 사리자게 설정함 : i 값을 조절해서 조절이 가능함
    SpriteRenderer sprite;
    PolygonCollider2D col;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<PolygonCollider2D>();
    }

    // FadeOut
    void FadeOut()
    {   
        while (DelayNum > 0.0f)
        {
            DelayNum -= 1.0f;
            float f = DelayNum / 10.0f;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            StartCoroutine(UpdateDelay());
        }
        col.enabled = false;
    }

    // FadeIn : FadeOut에서 역순으로 진행
    void FadeIn()
    {
        while (DelayNum < 10.0f)
        {
            DelayNum += 1.0f;
            float f = DelayNum / 10.0f;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            StartCoroutine(UpdateDelay());
        }
        col.enabled = true;
    }

    IEnumerator UpdateDelay()
    {
        yield return new WaitForSeconds(Delay);
    }

    void Start()
    {
        FadeIn();

        FadeOut();
    }
}

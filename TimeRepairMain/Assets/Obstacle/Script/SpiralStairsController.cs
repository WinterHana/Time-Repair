using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * <참고> 
 * 1. https://jrady.tistory.com/7
 * 2. https://ncube-studio.tistory.com/entry/%ED%8E%98%EC%9D%B4%EB%93%9C%EC%9D%B8Fade-In-%ED%8E%98%EC%9D%B4%EB%93%9C%EC%95%84%EC%9B%83Fade-Out-%ED%82%A4%EC%99%80-%EB%B2%84%ED%8A%BC%EC%9C%BC%EB%A1%9C-%EC%98%A4%EB%B8%8C%EC%A0%9D%ED%8A%B8-%ED%88%AC%EB%AA%85%ED%95%98%EA%B2%8C-%EB%A7%8C%EB%93%A4%EA%B8%B0%EC%9C%A0%EB%8B%88%ED%8B%B0-2D%EA%B8%B0%EC%B4%88%EA%B0%95%EC%A2%8C-Unity-C-ScriptAlpha-Opacity
 */
public class SpiralStairsController : MonoBehaviour
{
    [SerializeField] float Delay = 5.0f;
    SpriteRenderer sprite;
    PolygonCollider2D col;

    float time;

    void Awake()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<PolygonCollider2D>();
    }

    // FadeOut
    IEnumerator FadeOut()
    {
        float i = 10.0f;
        while (i >= 0.0f)
        {
            i -= 1.0f;
            float f = i / Delay;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.9f);
        }
        col.enabled = false;
    }

    // FadeIn : FadeOut에서 역순으로 진행
    IEnumerator FadeIn()
    {
        float i = 0.0f;
        while (i <= 10.0f)
        {
            i -= 1.0f;
            float f = i / Delay;
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(0.9f);
        }
        
    }

    // FadeInOut를 합친 Coroutine
    IEnumerator FadeInOut()
    {
        // FadeIn
        if (col.enabled == false)
        {
            float i = 0.0f;
            while (i <= 10.0f)
            {
                i += 1.0f;
                float f = i / Delay;
                Color c = sprite.material.color;
                c.a = f;
                sprite.material.color = c;
                yield return new WaitForSeconds(0.9f);
            }
            col.enabled = true;
        }

        // FadeOut
        else if (col.enabled == true)
        {
            float i = 10.0f;
            while (i >= 0.0f)
            {
                i -= 1.0f;
                float f = i / Delay;
                Color c = sprite.material.color;
                c.a = f;
                sprite.material.color = c;
                yield return new WaitForSeconds(0.9f);
            }
            col.enabled = false;
        }
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time >= Delay)
        {
            StartCoroutine(FadeInOut());
            time = 0.0f;
        }
    }
}

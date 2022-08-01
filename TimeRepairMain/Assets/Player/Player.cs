using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float power;
    bool isGround;
    public Rigidbody2D rigid;
    public Transform foot;
    float checkRadius = 0.35f;
    int jumpCnt;
    public int jCount;
    public LayerMask islayer;


    // Start is called before the first frame update
    void Start()
    {
        jumpCnt = jCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 180, 0); 
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        isGround = Physics2D.OverlapCircle(foot.position, checkRadius, islayer);

        if (isGround && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            rigid.velocity = Vector2.up * power;
            // EffectMamager.instance.effectSounds[0].source.Play();
        }
        if (!isGround && Input.GetKeyDown(KeyCode.Space) && jumpCnt > 0)
        {
            rigid.velocity = Vector2.up * power;
            // EffectMamager.instance.effectSounds[0].source.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = jCount;
        }

    }

}

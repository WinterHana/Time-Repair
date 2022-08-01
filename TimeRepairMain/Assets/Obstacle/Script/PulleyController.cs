using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyController : MonoBehaviour
{
    GameObject left, right; 
    GameObject wheel;
    Rigidbody2D LeftRigid, RightRigid;
    internal Collider2D LeftCollider, RightCollider;

    internal bool Stop = true;

    [SerializeField] float speed = 100.0f;
    public bool MovingLeftDown = true;      // �¿� �ö󰡴°� �˷��ִ� flag

    void Awake()
    {
        // ��, ���� ���� ��������
        left = transform.GetChild(0).gameObject;
        right = transform.GetChild(1).gameObject;

        LeftRigid = left.GetComponent<Rigidbody2D>();
        RightRigid = right.GetComponent<Rigidbody2D>();

        LeftCollider = left.GetComponent<Collider2D>(); 
        RightCollider = right.GetComponent<Collider2D>();

        // ��Ϲ��� ��������
        wheel = transform.GetChild(3).gameObject;
    }

    void FixedUpdate()
    {
        // 1. ����
        if (Stop)
        {
            StopMoving();
        }

        // 1. ���� �Ʒ��� �̵�
        else if (MovingLeftDown == true)
        {
            LeftDown();
        }

        // 2. ������ �Ʒ��� �̵�
        else if (MovingLeftDown == false)
        {
            RightDown();
        }
    }

    // 1. �������� ������
    internal void RightDown()
    {
        LeftRigid.velocity = Vector2.up * speed * Time.deltaTime;
        RightRigid.velocity = Vector2.down * speed * Time.deltaTime; 
        wheel.transform.Rotate(new Vector3(0, 0, -1), speed * Time.deltaTime);
    }

    // 2. ������ ������
    internal void LeftDown()
    {
        RightRigid.velocity = Vector2.up * speed * Time.deltaTime;
        LeftRigid.velocity = Vector2.down * speed * Time.deltaTime;
        wheel.transform.Rotate(new Vector3(0, 0, 1), speed * Time.deltaTime);
    }

    // 3. ���� : internal�� �����ؼ� ���� ������Ʈ���� �����Ӱ� ���
    internal void StopMoving()
    {
        LeftRigid.velocity = Vector2.zero;
        RightRigid.velocity = Vector2.zero;
        wheel.transform.Rotate(new Vector3(0, 0, 0), 0.0f);
    }
}

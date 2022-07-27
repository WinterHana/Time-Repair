using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Vector2 CheckGround_pos;

    GameObject CheckGround;
    
    Rigidbody2D rigid2D;

    [SerializeField] float JumpForce = 7.0f, speed = 5.0f;       // ������ �� �ִ� ��
    [SerializeField] int JumpLimit = 2;
    int JumpCount = 0;
    bool isJumpDelay = false;

    int reverse = 1;

    Animator animator;

    public bool Interaction;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // CheckGround = transform.GetChild(0).gameObject;
        // CheckGround_pos = CheckGround.transform.position;  
    }


    void Update()
    {
        MoveX();
        Jump();
        // InteractionObject();
    }

    void MoveX()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        rigid2D.velocity = new Vector2(x, rigid2D.velocity.y);

        // ȭ�� ��ȯ
        if (x > 0) reverse = 1;
        else if (x < 0) reverse = -1;
        transform.localScale = new Vector3(reverse, 1, 1);

        if (x != 0) animator.SetBool("PlayerWalk", true);
        else animator.SetBool("PlayerWalk", false);
    }

    void Jump() {
        // �ٴڿ� ������ �ʱ�ȭ
        if (isGround())
        {
            JumpCount = 0;
            animator.SetBool("PlayerJumpDown", false);
            animator.SetBool("PlayerJump", false);
        }

        // ���ǿ� �°� ��������� ������ ����
        if (isJumpDelay == false && JumpLimit > JumpCount && Input.GetKeyDown(KeyCode.Space))  {
            // �ִϸ��̼�
            animator.SetBool("PlayerJump", true);
            animator.SetBool("PlayerJumpDown", false);
            // ���� ���� �� �ִϸ��̼� ����
            if (rigid2D.velocity.y > 0)
            { 
                animator.SetBool("PlayerJumpDown", true);
            }
                
            // ���� ����
            isJumpDelay = true;
            JumpCount++;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, JumpForce);
            Debug.Log(JumpCount);
            StartCoroutine(JumpDelay());
        }
    }
    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.3f);
        isJumpDelay = false;
    }

    bool isGround() {
        if (rigid2D.velocity.y == 0)
            return true;
        else
            return false;
        // return Physics2D.OverlapCircle()...
    }

    /*
    public void InteractionObject()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Interaction = true;
            Debug.Log("��ȣ�ۿ� �߻�");
            StartCoroutine(InteractionDelay());
        }
    }

    IEnumerator InteractionDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Interaction = false;
        Debug.Log("��ȣ�ۿ� ��");
    }
    */
}
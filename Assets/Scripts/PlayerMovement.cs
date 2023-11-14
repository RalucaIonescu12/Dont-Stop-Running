using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    public static int CurrentTile = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();

    }

    private int Next_x_POS;
    private bool Left, Right;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
                animator.SetBool("Right", true);
            else
                Right = true;
            if(m_rigidbody.position.x >= -3 && m_rigidbody.position.x < -1)
            {
                Next_x_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_x_POS = 2;
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
                animator.SetBool("Left", true);
            else
                Left = true;
            if (m_rigidbody.position.x >= 1 && m_rigidbody.position.x < 3)
            {
                Next_x_POS = 0;
            }
            else if (m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_x_POS = -2;
            }
        }
    }

    private bool isJumpDown = false;

    void JumpDown()
    {
        isJumpDown = true;
    }

    private void OnAnimatorMove()
    {
        if (animator.GetBool("Jump"))
        {
            if (isJumpDown)
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 2) * animator.deltaPosition.magnitude);
            }
            else
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 1.5f, 2) * animator.deltaPosition.magnitude);
            }

        }
        else if (animator.GetBool("Right"))
        {
            if (m_rigidbody.position.x < Next_x_POS)
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(1, 0, 1.5f) * animator.deltaPosition.magnitude);
            }
            else
            {
                animator.SetBool("Right", false);
            }

        }
        else if (animator.GetBool("Left"))
        {
            if (m_rigidbody.position.x > Next_x_POS)
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-1, 0, 1.5f) * animator.deltaPosition.magnitude);
            }
            else
            {
                animator.SetBool("Left", false);
            }

        }
        else
        {
            m_rigidbody.MovePosition(m_rigidbody.position + Vector3.forward * animator.deltaPosition.magnitude);
        }

        if (Left)
        {
            if (m_rigidbody.position.x > Next_x_POS)
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(-1, 0, 0) * animator.deltaPosition.magnitude);
            }
            else
            {
                Left = false;
            }
        }
        else if (Right)
        {
            if (m_rigidbody.position.x < Next_x_POS)
            {
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(1, 0, 0) * animator.deltaPosition.magnitude);
            }
            else
            {
                Right = false;
            }
        }

    }


    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
        isJumpDown = false;
    }
}

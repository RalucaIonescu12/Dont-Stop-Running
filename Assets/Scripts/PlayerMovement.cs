using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    public static int CurrentTile = 0;
    public static bool IsFlying = false;
    [SerializeField] private GameObject Wings;
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
        if(IsFlying && !animator.GetBool("FLYING"))
        {
            animator.SetBool("FLYING", true);
            m_rigidbody.useGravity = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Run", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) && !animator.GetBool("FLYING"))
        {
            animator.SetBool("Slide", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) && !animator.GetBool("FLYING"))
        {
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
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
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide") && !animator.GetBool("FLYING"))
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

        if (animator.GetBool("FALL_DEAD"))
        {

            m_rigidbody.MovePosition(m_rigidbody.position + Vector3.down * animator.deltaPosition.magnitude);
        }
        else if (animator.GetBool("FLYING"))
        {
            if (!IsFlying)
            {
                if (m_rigidbody.position.y > 2)
                    m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, -1.5F, 1) * animator.deltaPosition.magnitude);
                else
                {
                    Wings.SetActive(false);
                    animator.SetBool("FLYING", false);
                }
            }
            else if (m_rigidbody.position.y < 10)
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 3, 3) * animator.deltaPosition.magnitude);
            else
                m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0, 0, 3) * animator.deltaPosition.magnitude);

        }

        else if (animator.GetBool("Jump"))
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
            m_rigidbody.MovePosition(m_rigidbody.position + new Vector3(0,0,1.5f) * animator.deltaPosition.magnitude);
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

    //TODO: VEZI CINE E OBS!!!! - VEZI BARK CAN
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.collider.CompareTag("OBS"))
        //{
        //    animator.SetBool("DEAD", true);
        //}

        if (collision.collider.CompareTag("FALL_DAMAGE"))
        {
            animator.SetBool("FALL_DEAD", true);
        }
    }

    [SerializeField] private GameObject Camera_obj;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("FALL_DAMAGE"))
        {
            Camera_obj.transform.parent = null;
            animator.SetBool("FALL_DEAD", true);
        }
        else if (other.CompareTag("DISABLE_FLY"))
        {
            IsFlying = false;
            m_rigidbody.useGravity = true;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player Variables

    public float jumpForce;
    public Transform head;
    public Transform weapon01;
    public Transform weapon02;

    public Sprite idleSprite;
    public Sprite duckingSprite;
    public Sprite jumpingSprite;
    public Sprite spinningSprite;

    private SpriteRenderer face;
    private Rigidbody rbody;

    #endregion
    private bool isJumping;
    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Jump"))
        {
            if(isJumping==false)
            {
                isJumping = true;
                SetExpression(jumpingSprite);
                rbody.AddForce(Vector3.up * jumpForce);
            }
           
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        SetExpression(idleSprite);
    }

    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
}

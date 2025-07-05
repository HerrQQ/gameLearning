using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRig;
        private float mGroundMoveSpeed = 5f;
        private float mJumpForce = 12f;
        private bool mShouldJump = false;

        private void Start()
        {
            mRig = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mShouldJump = true;
            }
        }

        private void FixedUpdate()
        {
            // Ë®Æ½ÒÆ¶¯
            float moveX = Input.GetAxisRaw("Horizontal");
            mRig.velocity = new Vector2(moveX * mGroundMoveSpeed, mRig.velocity.y);

            // ÌøÔ¾
            if (mShouldJump)
            {
                mRig.velocity = new Vector2(mRig.velocity.x, mJumpForce);
                mShouldJump = false;
            }
        }
    }
}
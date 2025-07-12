using PlatformShoot;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace platformShoot
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D mRig;
        private float mGroundMoveSpeed = 5f;
        private float mJumpForce = 12f;
        private bool mShouldJump = false;
        private bool mIsGrounded = false;
        private bool mCanDoubleJump = false;
        private int mJumpCount = 0;
        private const int MAX_JUMP_COUNT = 2;
        private float _lastRewardTime;
        private const float REWARD_COOLDOWN = 0.2f; // 至少0.2秒内不重复触发
        private MainPanel mMainPanel;
        private GameObject mGamePass;
        private int mFaceDir = 1;

        private void Start()
        {
            mRig = GetComponent<Rigidbody2D>();
            mGamePass = GameObject.Find("GamePass");
            mGamePass.SetActive(false);
            mMainPanel = GameObject.Find("MainPanel").GetComponent<MainPanel>();
        }

        private void Update()
        {
            CheckGround();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (mIsGrounded || (mCanDoubleJump && mJumpCount < MAX_JUMP_COUNT))
                {
                    mShouldJump = true;
                    mJumpCount++;

                    if (!mIsGrounded)
                    {
                        mCanDoubleJump = false;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                //var bullet = Resources.Load<GameObject>("Bullet");
                //bullet= GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
                //bullet.GetComponent<Bullet>().GetGamePass(mGamePass);
                //bullet.InitDir(mFaceDir);
                var obj = Resources.Load<GameObject>("Bullet");
                obj = GameObject.Instantiate(obj, transform.position, Quaternion.identity);
                Bullet bullet = obj.GetComponent<Bullet>();
                bullet.GetGamePass(mGamePass);
                bullet.InitDir(mFaceDir);

            }
        }

        private void FixedUpdate()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            mRig.velocity = new Vector2(moveX * mGroundMoveSpeed, mRig.velocity.y);

            if (mShouldJump)
            {
                mRig.velocity = new Vector2(mRig.velocity.x, mJumpForce);
                mShouldJump = false;
            }

            if (moveX!=0&& moveX!= mFaceDir)
            {
                mFaceDir = -1 * mFaceDir;
                transform.Rotate(0,180,0);
            }
        }

        void CheckGround()
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<Collider2D>().bounds.size, 0f, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
            mIsGrounded = hit.collider != null;

            if (mIsGrounded)
            {
                mJumpCount = 0;
                mCanDoubleJump = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Door"))
            {
                SceneManager.LoadScene("GamePassScene");
            }
            if (collision.gameObject.CompareTag("Heil"))
            {
                SceneManager.LoadScene("GameFailScene");
            }
            if (collision.CompareTag("Reward") && Time.time - _lastRewardTime > REWARD_COOLDOWN)
            {
                _lastRewardTime = Time.time;
                Destroy(collision.gameObject);
                mMainPanel.UpdateScoreTex(1);
            }
        }
    }
}
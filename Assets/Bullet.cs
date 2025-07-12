using UnityEngine;
namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        private LayerMask mLayerMask;
        private GameObject mGamePass;

        void Start()
        {
            GameObject.Destroy(this.gameObject, 3f);
            mLayerMask = LayerMask.GetMask("Ground", "Trigger");
        }

        public void GetGamePass(GameObject pass)
        {
            mGamePass = pass;
        }


        void Update()
        {
            transform.Translate(12 * Time.deltaTime, 0, 0);
        }

        private void FixedUpdate()
        {
            var coll = Physics2D.OverlapBox(transform.position, transform.localScale, 0, mLayerMask);
            if (coll)
            {
                if (coll.CompareTag("Trigger"))
                {
                    GameObject.Destroy(coll.gameObject);
                    mGamePass.SetActive(true);
                }
                GameObject.Destroy(gameObject);
            }
        }
    }
}


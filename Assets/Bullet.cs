using UnityEngine;
namespace PlatformShoot
{
    public class Bullet : MonoBehaviour
    {
        void Start()
        {
            GameObject.Destroy(this.gameObject, 3f);
        }
        void Update()
        {
            transform.Translate(12 * Time.deltaTime, 0, 0);
        }
    }
}


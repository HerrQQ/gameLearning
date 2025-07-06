using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class MainPanel : MonoBehaviour
    {
        private Text mScoreTex;
        // Start is called before the first frame update
        private void Start()
        {
            mScoreTex = transform.Find("ScoreTex").GetComponent<Text>();
        }

        public void UpdateScoreTex(int score)
        {
            int temp = int.Parse(mScoreTex.text);
            mScoreTex.text += (temp+score).ToString();
        }
    }
}

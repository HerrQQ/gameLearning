using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlatformShoot
{
    public class MainPanel : MonoBehaviour
    {
        private TextMeshProUGUI mScoreTex;
        // Start is called before the first frame update
        private void Start()
        {
            Transform scoreTexTransform = transform.Find("ScoreTex");
            if (scoreTexTransform != null)
            {
                mScoreTex = scoreTexTransform.GetComponent<TextMeshProUGUI>();
                if (mScoreTex == null)
                {
                    Debug.LogError("ScoreTex������δ�ҵ�TextMeshProUGUI�����");
                }
            }
            else
            {
                Debug.LogError("δ�ҵ�ScoreTex�Ӷ���");
            }
        }

        public void UpdateScoreTex(int score)
        {
            if (mScoreTex != null)
            {
                int currentScore;
                if (int.TryParse(mScoreTex.text, out currentScore))
                {
                    mScoreTex.text = (currentScore + score).ToString();
                }
                else
                {
                    Debug.LogError("�����ı���ʽ��Ч��");
                }
            }
        }
    }
}

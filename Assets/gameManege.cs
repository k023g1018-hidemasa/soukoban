using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManege : MonoBehaviour
{

    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        //�z��̎��Ԃ̍쐬�Ə�����
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        //�ǉ�������̐錾�Ə�����
        string debugtext = "";
        for (int i = 0; i < map.Length; i++)


        {
            debugtext += map[i].ToString() + ",";
            //�v�f������o��
            Debug.Log(debugtext);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //1 ����������L�q
            //������Ȃ������Ƃ��̂��߂�-1�ŏ�����
            int playerIndex = -1;

            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;

                }

            }
            /*
             * playerIndex+�̃C���f�b�N�X�̂��̂ƌ�������̂�
             * playerIndex-��肳��ɏ������C���f�b�N�X�̎�
             * �̂݌����������s��
             */

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;

            }
            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);


            Debug.Log("->");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = -1;
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;

                }

            }

            if (playerIndex > 0)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;

            }
            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);


            Debug.Log("<-");
        }



    }


}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManege : MonoBehaviour
{

    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        //配列の実態の作成と初期化
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        //追加文字列の宣言と初期化
        string debugtext = "";
        for (int i = 0; i < map.Length; i++)


        {
            debugtext += map[i].ToString() + ",";
            //要素を一つずつ出力
            Debug.Log(debugtext);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //1 をここから記述
            //見つからなかったときのために-1で初期化
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
             * playerIndex+のインデックスのものと交換するので
             * playerIndex-よりさらに小さいインデックスの時
             * のみ交換処理を行う
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


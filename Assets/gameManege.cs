using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    public GameObject storePrefab;
    public GameObject clearText;
    public GameObject fens;
    int[,] map;
    GameObject[,] field;
    //GameObject instance;


    bool IsCleard()
    {
        //vector2int型の可変長配列の作成
        List<Vector2Int> goals = new List<Vector2Int>();

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                //格納場所か否かを判断
                if (map[y, x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }//格納場所の場合
            }
        }

        //格納場所に箱があるか調べる
        for (int i = 0; i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];//ゴールの座標に何があるかとってくる
            if (f == null || f.tag != "Box")
            {
                //一つでも箱がなかったら条件未達
                return false;
            }
        }
        //条件未達でなっければ条件達成
        return true;
    }
    /// <summary>
    /// 与えられた数字をマップ上で移動させる
    /// </summary>
    /// <param name="number">移動させる数字</param>
    /// <param name="moveFrom">元の位置</param>
    /// <param name="moveTo">移動先の位置</param>
    /// <returns>移動可能な時 true</returns>
    bool MoveNumber(Vector2Int movefrom, Vector2Int moveto)
    {


        // 動けないときはファルス
        //if (moveto.y < 0 || moveto.y >= field.GetLength(0))
        //    return false;

        //if (moveto.x < 0 || moveto.x >= field.GetLength(1))
        //    return false;
        if (moveto.y = )

        if (field[moveto.y, moveto.x]?.tag == "Box")
        {
            var offset = moveto - movefrom;  // 箱の行先を決めるための差分
            bool result = MoveNumber(moveto, moveto + offset);

            if (!result)
                return false;
        }   // 行先に箱がある時

        // field[movefrom.y, movefrom.x].transform.position =
        //   new Vector3(moveto.x, -1 * moveto.y, 0);    // シーン上のオブジェクトを動かす
        // field のデータを動かす
        field[moveto.y, moveto.x] = field[movefrom.y, movefrom.x];
        field[movefrom.y, movefrom.x] = null;

        Move move = field[moveto.y, moveto.x].GetComponent<Move>();
        move.MoveTo(new Vector3(moveto.x, -1 * moveto.y, 0));
        //       Vector3 moveToPosition = new Vector3(moveto.x, map.GetLength(0) - moveto.y, 0);
        //       field[movefrom.y, movefrom.x].GetComponent<move>().MoveTo(moveToPosition);
        return true;

    }

    Vector2Int GetPlayerIndex()//プレイヤーの座標を調べて取得
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                GameObject obj = field[y, x];

                if (obj != null && obj.tag == "Player")
                {
                    return new Vector2Int(x, y);
                }   // プレイヤーを見つけた
            }
        }

        return new Vector2Int(-1, -1);  // 見つからなかった
    }



    void Start()
    {
        clearText.SetActive(false);
        map = new int[,]
        {
            { 4, 4, 4, 4, 4, 4, 4, 3, 2 },
            { 4, 1, 0, 0, 0, 0, 0, 0, 2 },
            { 4, 0, 2, 0, 0, 0, 2, 0, 4 },
            { 4, 2, 2, 2, 0, 0, 0, 0, 4 },
            { 4, 3, 3, 3, 0, 0, 0, 3, 4 },
            { 4, 4, 4, 4, 4, 4, 4, 4, 4 }
        };

        //  PrintArray();

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];//mapの行列と同じマス目の配列をもう一つ作った

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    GameObject instance =
                           Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;//プレイヤーを保存しておく
                                           //  break;//プレイヤーは一つなので抜ける
                }   // プレイヤーを出す
                else if (map[y, x] == 2)
                {
                    GameObject instance =
                         Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;//箱の保存
                }
                else if (map[y, x] == 3)// 箱を見つけた
                {
                    GameObject instance =
                        Instantiate(storePrefab,
                        new Vector3(x, -1 * y, 0),
                        Quaternion.identity);
                    // 格納場所を出す   // 箱を見つけた
                }else if (map[y, x] == 4)
                {
                    GameObject instance=
                        Instantiate(fens,new Vector3(x,-1*y, 0), Quaternion.identity);
                    //フェンスを出す
                }
            }
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.right);
            // PrintArray();
            if (IsCleard())
            {
                //  Debug.Log("clear");
                clearText.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.left);
            // PrintArray();
            if (IsCleard())
            {
                //  Debug.Log("clear");
                clearText.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.up);
            //PrintArray();
            if (IsCleard())
            {
                //  Debug.Log("clear");
                clearText.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.down);
            //PrintArray();
            if (IsCleard())
            {
                //  Debug.Log("clear");
                clearText.SetActive(true);
            }
        }

    }
}

/*
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UIElements;




public class gameManege : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;//変更二次元配列で宣言
               //クラスの中、メソッドの外に書くことに注意//メソッドてどれやねん
    GameObject[,] field;
    GameObject instance;

    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }

        if (field[moveTo.y, moveTo.x]?.tag == "Box")
        {
            var offset = moveTo - moveFrom;  // 箱の行先を決めるための差分
            bool result = MoveNumber(moveTo, moveTo + offset);

            if (!result)
                return false;
        }   // 行先に箱がある時




        field[moveFrom.y, moveFrom.x].transform.position =//シーン上のオブジェクトを動かす
            new Vector3(moveTo.x, -1 * moveTo.y, 0);
        //fieldのデータを動かす
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveTo.x] = null;
        return true;
    }//右移動と左移動のまとめ




     //      //移動先に２がいたら
     //  if (map[moveTo] == 2)
     //  {
     //      //どの方向へ移動するかを算出
     //      int velocity = moveTo - moveFrom;
     //      //プレイヤーの移動先から、さらに先へ2を移動させる。
     //      //箱の移動処理。MoveNumberメソッド内でMoveNumberメソッドを
     //      //予備、処理が再起している、移動可能不可をboolデ記録
     //      bool success = MoveNumber(2, moveTo, moveTo + velocity);
     //      //もし箱が移動失敗したら、プレイヤーの移動も失敗
     //      if (!success) { return false; } 
     //  }
     //  //プレイヤー箱変わらずの移動処理
     //  map[moveTo] = number;
     //  map[moveFrom] = 0;
     //  return true;
     ////クラスの中、メソッドの外に書くことに注意
     ////返り血の型に注意
     //int GetPlayerIndex()
     //{
     //    for (int i = 0; i < map.Length; i++)
     //    {
     //        if (map[i] == 1)
     //        {
     //            return i;
     //        }
     //    }
     //    return -1;
     //}
    


    // Start is called before the first frame update
    //public GameObject playerprefab;
    //    //配列の実態の作成と初期化
    //    int[,] map;//レベルデザイン用の配列
    //    GameObject[,] field;//ゲーム管理用の配列
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                GameObject obj = field[y, x];

                if (obj != null && obj.tag == "Player")
                {
                    return new Vector2Int(x, y);
                }   // プレイヤーを見つけた
                    //先生版
                // if (field[y, x].tag == "Player")
                 //{
                 //    return new Vector2Int(x, y);//プレイヤーが見つかった
                // }
                
            }
        }

        return new Vector2Int(-1, -1);
    }

    void PrintArray()
    {
        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ",";
            }

            debugText += "\n";
        }

        Debug.Log(debugText);
    }

    void Start()
    {
        
        //GameObject instance = Instantiate(//その後に色々したいときはインスタンスを入れる
        //    playerPrefab,//こいつを
        //    new Vector3(0, 0, 0),//原点に
        //    Quaternion.identity//回転をせずに
        //    );
        
        map = new int[,]
     {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 2, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 2, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 2, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 2, 0, 0, 2, 0 }
     };

        PrintArray();

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    instance =
                        Instantiate(playerPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                    break;
                }   // プレイヤーを見つけた
                else if (map[y, x] == 2)
                {
                    instance =
                        Instantiate(boxPrefab, new Vector3(x, -1 * y, 0), Quaternion.identity);
                    field[y, x] = instance;
                }   // 箱を見つけた
            }
        }

        ////追加文字列の宣言と初期化
        //string debugtext = "";
        ////変更。二重for文で二次元配列の情報を出力
        //for (int y = 0; y < map.GetLength(0); y++)
        //{
        //    for (int x = 0; x < map.GetLength(1); x++)
        //    {
        //        if (map[y,x] == 1)
        //        {
        //            GameObject instane = Instantiate(
        //                playerPrefab,
        //               new Vector3(x,map.GetLength(0)- y,0),
        //               Quaternion.identity
        //               ) ;

        //        debugtext += map[y,x].ToString() + ",";
        //        }//いf分
        //    }//ふぉｒ
        //    //要素を一つずつ出力
        //    debugtext += "\n";//改行
        //}//ふぉｒ

        //Debug.Log(debugtext);




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.right);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion + Vector2Int.left);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.up);
            PrintArray();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            var playerPostion = GetPlayerIndex();
            MoveNumber(playerPostion, playerPostion - Vector2Int.down);
            PrintArray();

        }
    }


}
*/

//if (Input.GetKeyDown(KeyCode.RightArrow))
//{
//    //1 をここから記述
//    //見つからなかったときのために-1で初期化
//    int playerIndex = -1;

//    //for (int i = 0; i < map.Length; i++)
//    //{
//    //    if (map[i] == 1)
//    //    {
//    //        playerIndex = i;
//    //        break;

//    //    }

//    //}

//     * playerIndex+のインデックスのものと交換するので
//     * playerIndex-よりさらに小さいインデックスの時
//     * のみ交換処理を行う

//    //メソッド化した処理を使用
//    int plauerIndex = GetPlayerIndex();//ここが上の配置？するやつ
//    //移動の処理の関数
//    MoveNumber(1, playerIndex, playerIndex + 1);

//    PrintArray();//ここであってんの
//                 //左移送は省略

//    //    if (playerIndex < map.Length - 1)
//    //    {
//    //        map[playerIndex + 1] = 1;
//    //        map[playerIndex] = 0;
//    //    }
//    //    string debugText = "";
//    //    for (int i = 0; i < map.Length; i++)
//    //    {
//    //        debugText += map[i].ToString() + ",";
//    //    }
//    //    Debug.Log(debugText);
//    //    Debug.Log("->");
//    //}
//    if (Input.GetKeyDown(KeyCode.LeftArrow))
//    {
//        MoveNumber(1, playerIndex, playerIndex + 1);
//        PrintArray();
//    }//左の終わり
//}//右の終わり









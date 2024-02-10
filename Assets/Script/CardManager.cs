using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    // カードを入れる用の配列　0,木　1,水　2,火
    [SerializeField] GameObject[] P1Cards;
    [SerializeField] GameObject[] P2Cards;
    [SerializeField] GameObject battlecamera;
    [SerializeField] GameObject skillcamera;
    
    // 現在のカードの状態を保存する変数
    private int P1CardNum;
    private int P2CardNum;
    // 現在のプレイヤーを保持する変数
    private int CurrentPlayer = 1;

    // プレイヤーの体力
    [SerializeField] int P1HP = 10;
    [SerializeField] int P2HP = 10;

    [SerializeField] TMP_Text P1HP_Text;
    [SerializeField] TMP_Text P2HP_Text;
    [SerializeField] TMP_Text CurrentPLayerText;

    private void Start()
    {
        battlecamera.SetActive(true);
        skillcamera.SetActive(false);
        P1CardNum = Random.Range(0,P1Cards.Length);
        P2CardNum = Random.Range(0,P2Cards.Length);
        Debug.Log("P1: " + P1CardNum + "P2: " + P2CardNum);
    }

    private void Update()
    {
        // カードの位置を制御
        for ( int i = 0; i < P1Cards.Length; i++)
        {
            Vector3 pos = P1Cards[i].transform.localPosition;
            if (i==P1CardNum)
                pos.y = 100;
            else pos.y = 0;
            P1Cards[i].transform.localPosition = pos;
        } 
        for ( int i = 0; i < P2Cards.Length; i++)
        {
            Vector3 pos = P2Cards[i].transform.localPosition;
            if (i==P2CardNum)
                pos.y = -100;
            else pos.y = 0;
            P2Cards[i].transform.localPosition = pos;
        }
        CurrentPLayerText.text = "CurrentPlayer : P" +  CurrentPlayer;
        //現在のプレイヤーを表示させるテキスト
        P1HP_Text.text = "P1: " + P1HP;
        P2HP_Text.text = "P2: " + P2HP;       
    }

    public void ShuffleCard()
    {
        //現在のプレイヤーに応じてシャッフル
        if (CurrentPlayer == 1)
        {
            int pre = P1CardNum;
            while(pre == P1CardNum) P1CardNum = Random.Range(0,P1Cards.Length);
        }
        if (CurrentPlayer == 2)
        {
            int pre = P2CardNum;
            while(pre == P2CardNum) P2CardNum = Random.Range(0,P2Cards.Length);
        }
        Debug.Log("P1: " + P1CardNum + "P2 " + P2CardNum);
    }

    public void moveTurn() //ターン性の切り替え
    {
        CurrentPlayer = CurrentPlayer + 1;
        if (CurrentPlayer > 2)
        {
            CurrentPlayer = 1; 
        }
    }

    public void attack() //　0,木　1,水　2,火
    {
        battlecamera.SetActive(false);
        skillcamera.SetActive(true);
        /*if (CurrentPlayer == 1)//P1の攻撃
        {
            if (P1CardNum == P2CardNum) P2HP -= 3;
            else if (P1CardNum == 2)
            {
                if ((P1CardNum - P2CardNum) % 2 == 0)
                {
                    P2HP -= 5;
                }
                else P2HP -= 1;
            }
            else if (P1CardNum == 1)
            {
                if ((P1CardNum -P2CardNum) < 0)
                {
                    P2HP -= 5;
                }
                else P2HP -= 1;
            }
            else
            {
                if((P1CardNum - P2CardNum) % 2 == 1)
                {
                    P2HP -= 5;
                }
                else P2HP -= 1;
            }
        }
        if (CurrentPlayer == 2) //P2の攻撃
        {
            if (P2CardNum == P1CardNum) P1HP -= 3;
            else if (P2CardNum == 2)
            {
                if ((P2CardNum - P1CardNum) % 2 == 0)
                {
                    P1HP -= 5;
                }
                else P1HP -= 1;
            }
            else if (P2CardNum == 1)
            {
                if ((P2CardNum - P1CardNum) < 0)
                {
                    P1HP -= 5;
                }
                else P1HP -= 1;
            }
            else
            {
                if((P2CardNum - P1CardNum) % 2 == 1)
                {
                    P1HP -= 5;
                }
                else P1HP -= 1;
            }
        }*/
    }

    public void back()
    {
        battlecamera.SetActive(true);
        skillcamera.SetActive(false);
    }
}

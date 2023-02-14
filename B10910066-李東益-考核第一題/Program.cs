using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B10910066_李東益_考核第一題
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("歡迎來到 1A2B 猜數字的遊戲～");
            int ancerA = 0;
            int ancerB;
            int playerNum;
            int roundNum;
            Random dice= new Random(); //19~36行讓電腦產生4個各自不同的亂數
            int firstNum = dice.Next(1,10);
            int secondNum = dice.Next(1,10);
            while (firstNum == secondNum) 
            { 
                secondNum = dice.Next(1,10);
            }
            int thirdNum = dice.Next(1,10);
            while(thirdNum == secondNum || thirdNum == firstNum)
            {
                thirdNum= dice.Next(1,10);
            }
            int fourthNum = dice.Next(1,10);
            while(fourthNum == thirdNum || fourthNum == secondNum || fourthNum == firstNum)
            {
                fourthNum= dice.Next(1,10);
            }
            int[] computerNum= {firstNum , secondNum, thirdNum , fourthNum};
            //Console.WriteLine($"{firstNum}{secondNum}{thirdNum}{fourthNum}");//暫時測試是否能讓電腦輸出4個各自不同的亂數
            while(ancerA != 4)//如果沒有達成遊戲勝利要求,將會使遊戲繼續
            {
                Console.WriteLine("------");
                Console.Write("請輸入 4 個數字：");
                playerNum = Convert.ToInt32(Console.ReadLine());
                if(playerNum / 1000 < 1 || playerNum / 1000 >= 10)//防止有人輸入非4個數字的防呆系統
                {
                    Console.WriteLine("請輸入剛好4個數字!不可多不可少!請重新輸入!");
                }
                else
                {
                    roundNum = 3;
                    ancerA= 0;
                    ancerB= 0;
                    for(int i = playerNum; i != 0;)//52~74行利用迴圈來對照遊戲規則來比對玩家分數為幾A幾B
                    {
                        if(i % 10 == computerNum[0] || i % 10 == computerNum[1] || i % 10 == computerNum[2] || i % 10 == computerNum[3]) 
                        {
                            if(i % 10 == computerNum[roundNum])
                            {
                                ancerA++;
                                roundNum--;
                                i /= 10;
                            }
                            else
                            {
                                ancerB++;
                                roundNum--;
                                i /= 10;
                            }
                        }
                        else
                        {
                            roundNum--;
                            i /= 10;
                        }
                    }
                    Console.WriteLine($"判定結果是 {ancerA}A{ancerB}B");
                }
            }
            Console.WriteLine("恭喜你！猜對了！！\r\n");
            Console.WriteLine("------");
            Console.WriteLine("你要繼續玩嗎？(y/n): n");
            Console.WriteLine("遊戲結束，下次再來玩喔～");
        }
    }
}


using System;
using static CUR_CSHARP.WildRiftConsole;

namespace CUR_CSHARP
{
    internal class ShopInterface : UserInterface
    {
        protected override void Init()
        {
            this.ExplainText = "상점에 오신 것을 환영합니다.!\n 1. 단검 구매 2. 천갑옷 구매 3. 도란링 구매  4. 나가기";
        }

        private void ShopInterfaceSAAA()
        {

        }

        protected override void ProcessResultByInput(int inSelectedInput)
        {
            // 부모
            // base - 내가 상속받은 베이스 클래스                        

            if(selectInput == 1)
            {
                // 단검 ?
                Console.WriteLine("유저가 단검을 착용하여 공격력이 증가하였습니다. +10");
                WildRiftUser user = new WildRiftUser();
                user.Atk += 10;
            }
        }

        protected override bool IsInputAvailable()
        {
            if (selectInput != 1 && selectInput != 2 && selectInput != 3 && selectInput != 4)
                return false;

            return true;
        }
    }
}
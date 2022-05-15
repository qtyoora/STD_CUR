using System;
using static CUR_CSHARP.WildRiftConsole;

namespace CUR_CSHARP
{
    // 캐릭터를 선택창을 만듦!
    public class CharacterSelectInterface : UserInterface
    {
        WildRiftUser cachedUser;

        protected override void Init()
        {
            ExplainText = "캐릭터를 선택해 주세요.\n1.가렌, 2.베인\n";
        }

        protected override bool IsInputAvailable()
        {
            if (selectInput != 1 && selectInput != 2)
                return false;

            return true;
        }

        protected override void ProcessResultByInput(int inSelectedInput)
        {
            // 가렌
            if(selectInput == 1 )
            {
                cachedUser.Atk = 20;
                cachedUser.HP = 200;
                cachedUser.Speed = 10;
                cachedUser.CharacterName = "가렌";
            }
            // 베인
            else if(selectInput == 2)
            {
                cachedUser.Atk = 15;
                cachedUser.HP = 150;
                cachedUser.Speed = 20;
                cachedUser.CharacterName = "베인";
            }

            Console.WriteLine("---- User Ability ----");
            Console.WriteLine("Name : " + cachedUser.CharacterName);
            Console.WriteLine("Atk : " + cachedUser.Atk);
            Console.WriteLine("HP : " + cachedUser.HP);
            Console.WriteLine("Speed : " + cachedUser.Speed);
        }

        public void SetUser(WildRiftConsole wildRiftConsole)
        {
            wildRiftConsole.activeUser = new WildRiftUser();
            cachedUser = wildRiftConsole.activeUser;
        }
    }
}
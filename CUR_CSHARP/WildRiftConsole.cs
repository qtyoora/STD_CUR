using System;

namespace CUR_CSHARP
{
    public class WildRiftConsole
    {
        // 유저에게 안내문구 보여주고, 실패시 해당 안내문구를 반복해서 선택하도록 한다.
        public abstract class UserInterface // 개념
        {
            protected string ExplainText = "예시 안내 문구 입니다.";
            protected int selectInput = 1;
            public int GetSelectedInput => selectInput;

            protected abstract bool IsInputAvailable(); // bool true, false, Is___
            protected abstract void Init(); // 반드시 초기화, Run Interface 이전에 호출
            public void RunInterface() // 함수는 동사로 한다.
            {
                this.Init();
                bool isInputAvailable = false;
                do
                {
                    isInputAvailable = false;
                    Console.WriteLine(ExplainText);
                    selectInput = int.Parse(Console.ReadLine());

                    isInputAvailable = IsInputAvailable(); // 인풋이 true, 리트라이는 false,                                                           
                } while (!isInputAvailable);                
            }

            
        }

        // 캐릭터를 선택창을 만듦!
        public class CharacterSelectInterface : UserInterface
        {
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
        }


        public void Run()
        {
            // 절차지향 - 설계없음 그냥 위에서 아래로 짜 내려감

            // 와일드리프트
            // 미니언을 잡고 레벨업을 하고 골드를 얻고,
            // 상점에서 롱소드를 사서, 데미지를 증가시키고, 미니언을 더 잡는 게임

            // 입력이 존재한다.
            // 입력이 실패하게 되면 반복한다.
            // 화면에 유저인터페이스가 존재한다. - 안내문구, 유저의 선택지를 제공한다.

            Console.WriteLine("와일드 리프트에 오신 것을 환영합니다.\n");

            // 캐릭터 선택
            CharacterSelectInterface characterSelectInterface = new CharacterSelectInterface();
            characterSelectInterface.RunInterface(); // Run

            // 맵 선택
            MapSelectInterface mapSelectInterface = new MapSelectInterface();
            mapSelectInterface.RunInterface();

            // 이거 나중에 씬 셀렉트로 바꿔야함. -> 씬매니징 개념 추가
            if (mapSelectInterface.GetSelectedInput == 1)
            {
                // 상점 선택시
                ShopInterface shopInterface = new ShopInterface();
                shopInterface.RunInterface();
            }
            else
            {
                // 던전 User Interface를 만들어주세요!
                DungeonInterface dungeonInterface = new DungeonInterface();
                dungeonInterface.RunInterface();
            }


        }

    }


}
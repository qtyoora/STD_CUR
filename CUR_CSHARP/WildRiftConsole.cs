using System;

namespace CUR_CSHARP
{
    // 와일드 리프트 게임을 주관한다.
    public class WildRiftConsole
    {
        public WildRiftUser activeUser = null;

        // 유저에게 안내문구 보여주고, 실패시 해당 안내문구를 반복해서 선택하도록 한다.
        public abstract class UserInterface // 개념
        {
            protected string ExplainText = "예시 안내 문구 입니다.";
            protected int selectInput = 1;
            public int GetSelectedInput => selectInput;

            protected abstract bool IsInputAvailable(); // bool true, false, Is___
            protected abstract void Init(); // 반드시 초기화, Run Interface 이전에 호출

            protected virtual void ProcessResultByInput(int inSelectedInput)
            {
                // 있어도 되고, 없으면 부모꺼 호출한다.
                Console.WriteLine("Default ProcssResult By Input Called");
            }

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

                // 가능한 입력이 들어왔다면? 입력을 처리해야한다. 각자의 인터페이스에서!
                if (isInputAvailable)
                    ProcessResultByInput(selectInput);
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
            characterSelectInterface.SetUser(this);
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
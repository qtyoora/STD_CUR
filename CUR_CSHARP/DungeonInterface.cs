using static CUR_CSHARP.WildRiftConsole;

namespace CUR_CSHARP
{
    internal class DungeonInterface : UserInterface
    {
        protected override void Init()
        {
            ExplainText = "던전에 오신것을 환영합니다.";// 기획에 따라 선택지 제공
        }

        protected override void ProcessResultByInput(int inSelectedInput)
        {
            base.ProcessResultByInput(inSelectedInput);
        }

        protected override bool IsInputAvailable()
        {
            if (selectInput != 1 && selectInput != 2)
                return false;

            return true;
        }
    }
}
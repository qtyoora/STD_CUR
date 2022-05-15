using static CUR_CSHARP.WildRiftConsole;

namespace CUR_CSHARP
{
    public class MapSelectInterface : UserInterface
    {
        protected override void Init()
        {
            this.ExplainText = "어디로 갈 것인가?\n 1. 상점 2. 타워\n";
        }

        protected override bool IsInputAvailable()
        {
            if (selectInput != 1 && selectInput != 2)
                return false;

            return true;
        }
    }
}
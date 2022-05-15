
using static CUR_CSHARP.WildRiftConsole;

namespace CUR_CSHARP
{
    internal class ShopInterface : UserInterface
    {
        protected override void Init()
        {
            this.ExplainText = "상점에 오신 것을 환영합니다.!\n 1. 단검 구매 2. 천갑옷 구매 3. 도란링 구매";
        }

        protected override bool IsInputAvailable()
        {
            if (selectInput != 1 && selectInput != 2 && selectInput != 3)
                return false;

            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;

namespace CUR_CSHARP_TETRIS
{
    class Program
    {
        // 테트리스가 눈 앞에 존재함

        // 1. 구성요소를 나열
        //  정사각형 다양한 모양의 도형들 - 다양한 종류의 블럭
        //  색깔이 다양하다.
        //  내려오는 속도가 똑같다. - 내려오는 속도가 존재한다.
        //  블럭들이 겹치지 않는다.
        //  3D이다
        //  한줄이 완성이되면 삭제된다.

        //  가로줄이 몇줄인가, 세로줄이 몇줄인가

        // 2. 추상화를 진행 - 행위, 상태
        //  명사 - 주체가 되는 단어
        //  블럭
        //      내련 온다.
        //      속도를 갖고 있음.
        //      겹치지 않는다.
        //      3D 이다.(x) 2D 이다. 보여진다. 박스가

        //  게임 룰
        //      한줄이 완성되면 삭제 된다.
        //      가로줄 갯수,
        //      세로줄 갯수,

        //      블럭은, 하나씩 위에서 생성된다.

        public class GameManager
        {
            public int cntX = 5;
            public int cntY = 12;

            public int totalCnt => gameManager.cntX * gameManager.cntY;
            public int activatedID = -1;
            public List<Block> blocks = new List<Block>();

            public void TryMakeFullBlock()
            {
                if (activatedID == -1)
                {
                    // cntX/2 == 2 숫자
                    // first id
                    var firstID = cntX / 2;
                    activatedID = firstID;

                    var activateBlock = blocks[activatedID];
                    activateBlock.state = Block.State.Active;
                }
            }

            // 매 주기마다 데이터를 갱신한다.
            public void Update()
            {
                TryMakeFullBlock();

                // 엑티베이트 된게 있다면,
                if (activatedID != -1)
                {
                    var activateBlock = blocks[activatedID];
                    activateBlock.DownMove();

                    activatedID = activatedID + gameManager.cntX;
                }
            }
        }


        public class Block
        {
            public int id = 0;
            public float Speed = 0;
            public State state = State.Empty;

            // 블럭의 상태
            public enum State
            {
                Empty, // 비어 있음.
                Full, // 채워져 있는 상태
                Active, // 방금 생성 된
            }

            public Block(int inID)
            {
                id = inID;
            }

            public void DownMove()
            {
                var currentBlock = gameManager.blocks[id];
                var nextBlock = gameManager.blocks[id + gameManager.cntX];

                nextBlock.state = State.Active;
                currentBlock.state = State.Empty;
            }

            // 겹쳐있는지 체크하겠습니다. 행위
            public void TryCheckOverlap()
            {

            }

            public void Draw()
            {
                if (state == State.Empty)
                    Console.Write("[ ]");
                else
                    Console.Write("[X]");
            }
        }
        static GameManager gameManager = new GameManager();
        static void MainTetris(string[] args)
        {
            // 초기화 하는 부분
            // Init Part
            for (int i = 0; i < gameManager.totalCnt; ++i)
            {
                gameManager.blocks.Add(new Block(i));
            }

            while (true)
            {
                // Update (갱신) 하는 부분
                gameManager.Update();

                Console.Clear();

                // 그리는 부분
                // Draw Part
                int x = 0;
                for (int i = 0; i < gameManager.totalCnt; ++i)
                {
                    x++;
                    var block = gameManager.blocks[i];
                    block.Draw();
                    if (x == gameManager.cntX)
                    {
                        Console.WriteLine();
                        x = 0;
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
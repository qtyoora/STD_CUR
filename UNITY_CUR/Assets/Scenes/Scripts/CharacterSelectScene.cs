using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectScene : MonoBehaviour
{
    [SerializeField]
    GameObject Garen;

    [SerializeField]
    GameObject Vein;

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    float height = 1f;

    [SerializeField]
    float bottom = 0.22f;

    Vector3 moveDirection = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // 엄청 짧으 시간에 호출 됨
    {
        // dt = 시간의 미분값, 매우 짧은 시간
        // 가렌의 위치중 y 값이, 1보다 크면, 이동하는 방향이 아래가 된다.
        // 가렌의 위치 중 y 값이, 0.22보다 아래라면 이동하는 방향이 위로 변경된다.
        if(Garen.transform.position.y >= height)
        {
            moveDirection = Vector3.down;
        }
        if (Garen.transform.position.y <= bottom)
        {
            moveDirection = Vector3.up;
        }


        Garen.transform.position += moveDirection * speed * Time.deltaTime;
        Vein.transform.position += moveDirection * speed * Time.deltaTime;
    }
}

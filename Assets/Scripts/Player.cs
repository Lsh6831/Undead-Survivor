using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;


public class Player : MonoBehaviour 
{
    // 방향 키 입력 받는 백터( x= 좌우,y = 상하)
    public Vector2 inputVec;

    // 이동 속고
    public float speed;
    
    // 객체가 가진 물리 컴포넌트
    Rigidbody2D rigid;
    // 스프라이트 랜더러 컴포넌트
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    
    // FixedUpdate : 물리 이동은 이곳에서
    private void FixedUpdate()
    {
        //
        Vector2 nexVec = inputVec.normalized*(speed*Time.fixedDeltaTime);
        // 현재 위치+이동량
        rigid.MovePosition(rigid.position + nexVec);
    }
    
    // LateUpdate : 모든 업데이트가 끝난 뒤 실행. 방향 반전 같은 것은 후처리에 적합
    void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            spriteRenderer.flipX = inputVec.x < 0;
        }
    }
        

    void OnMove(InputValue value)   
    {
        inputVec = value.Get<Vector2>();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 300, 20), inputVec.ToString());  
    }
}

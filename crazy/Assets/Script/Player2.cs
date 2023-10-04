using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed;
    public int power;
    public int count; // 물풍선 횟수
    public int remeberCount; // count 저장 변수
    public GameObject WaterBalloon1; // 물풍선 1
    public GameObject WaterBalloon2; // 물풍선 2
    public GameObject WaterBalloon3; // 물풍선 3
    public GameObject WaterBalloon4; // 물풍선 4
    public GameObject WaterBalloon5; // 물풍선 5
    public GameObject WaterBalloon6; // 물풍선 6
    public GameObject WaterBalloon7; // 물풍선 7

    float hAxis;
    float vAxis;
    bool isHorizonMove; // 대각선 이동 제한
    bool sDown; // 스페이스 바 다운

    Rigidbody2D rigid;


    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {

        Move();
        Skill();

    }
    
    void FixedUpdate() {

        // 대각선 이동 제한
        Vector2 moveVec = isHorizonMove ? new Vector2(hAxis, 0) : new Vector2(0, vAxis);
        rigid.velocity = moveVec * speed;
    }

    void Move()
    {
        // 이동
        hAxis = Input.GetAxisRaw("2PH");
        vAxis = Input.GetAxisRaw("2PV");

        bool hDown = Input.GetButtonDown("2PH");
        bool vDown = Input.GetButtonDown("2PV");
        bool hUp = Input.GetButtonUp("2PH");
        bool vUp = Input.GetButtonUp("2PV");


        if (vDown)
        {
            isHorizonMove = false;
        }
        else if (hDown)
        {
            isHorizonMove = true;
        }
        else if (vUp || hUp)
        {
            isHorizonMove = hAxis != 0;
        }
    }
    void Skill()
    {
        // 물풍선
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (power)
            {
                case 1:
                    if (!WaterBalloon1.activeInHierarchy)
                    {
                        WaterBalloon1.SetActive(true);
                        WaterBalloon1.transform.position = transform.position;
                    }
                    break;
                case 2:
                    if (!WaterBalloon2.activeInHierarchy)
                    {
                        WaterBalloon2.SetActive(true);
                        WaterBalloon2.transform.position = transform.position;
                    }
                    break;
                case 3:
                    if (!WaterBalloon3.activeInHierarchy)
                    {
                        WaterBalloon3.SetActive(true);
                        WaterBalloon3.transform.position = transform.position;
                    }
                    break;
                case 4:
                    if (!WaterBalloon4.activeInHierarchy)
                    {
                        WaterBalloon4.SetActive(true);
                        WaterBalloon4.transform.position = transform.position;
                    }
                    break;
                case 5:
                    if (!WaterBalloon5.activeInHierarchy)
                    {
                        WaterBalloon5.SetActive(true);
                        WaterBalloon5.transform.position = transform.position;
                    }
                    break;
                case 6:
                    if (!WaterBalloon6.activeInHierarchy)
                    {
                        WaterBalloon6.SetActive(true);
                        WaterBalloon6.transform.position = transform.position;
                    }
                    break;
                case 7:
                    if (!WaterBalloon7.activeInHierarchy)
                    {
                        WaterBalloon7.SetActive(true);
                        WaterBalloon7.transform.position = transform.position;
                    }
                    break;
            }
        }
        if (Input.GetButtonDown("Leftctrl2"))
        {
            Debug.Log("아이템 사용");
        }
    }

    void FinishBoom() {
        WaterBalloon1.SetActive(false);
        WaterBalloon2.SetActive(false);
        WaterBalloon3.SetActive(false);
        WaterBalloon4.SetActive(false);
        WaterBalloon5.SetActive(false);
    }
}

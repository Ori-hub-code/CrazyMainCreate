using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player player;

    //슈퍼맨용 저장할 능력치
    private int previousBombPower;
    private int previousBombRange;
    private float previousPlayerSpeed;
    private bool isSupermanActive = false;

    public GameObject[] speedItem;
    public GameObject[] bombItem;
    public GameObject[] rangeItem;
    public GameObject[] Activeitem;

    CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }




    //네임으로 구분해둔것
    //파워
    public void PowerAdd(string name)
    {
        if(name.Contains("basicBubble"))
        {
            player.bombPower++;
            Debug.Log("기본풍선 : 갯수 증가");
        }
        
    }
    //스피드
    public void SpeedAdd(string name)
    {
            if (name.Contains("roller"))
            {
                Debug.Log("롤러 : 스피드 증가");
                player.playerSpeed++ ;
               
            } 
            else if(name.Contains("redDevil"))
            {
                Debug.Log("붉은악마 : 이속 최대치");
                player.playerSpeed = player.playerSpeedMax;
            }
        


    }
    //사거리
    public void RangeAdd(string name)
    {
        if(name.Contains("basicFluid"))
        {
            player.bombRange++;
            Debug.Log("기본 물줄기 : 사거리 증가");
        }
        else if(name.Contains("ultraFluid"))
        {
            player.bombRange = player.bombRangeMax;
            Debug.Log("울트라 물줄기 : 사거리 최대치");
        }
    }

    //능력치 불러오기
    public void LoadState()
    {
        player.bombPower = previousBombPower;
        player.bombRange = previousBombRange;
        player.playerSpeed = previousPlayerSpeed; 
    }


    //슈퍼맨
    public void SuperMan(string name)
    {
        if (name.Contains("superMan") && !isSupermanActive)
        {
            // 슈퍼맨 아이템이 이미 활성화 중임을 표시
            isSupermanActive = true;

            // 현재 능력치 저장
            previousBombPower = player.bombPower;
            previousBombRange = player.bombRange;
            previousPlayerSpeed = player.playerSpeed;

            // 원하는 능력치로 설정
            player.bombPower = player.bombPowerMax;
            player.bombRange = player.bombRangeMax;
            player.playerSpeed = player.playerSpeedMax;

            // 5초 동안 대기 후 복구
            StartCoroutine(RestoreAbilitiesAfterDelay(5f));
        }
    }


    // 아이템을 Activeitem 배열에 추가하는 함수 (아이템 획득 시 호출)
    public void AddActiveItem(GameObject item, int index)
    {
        if (index >= 0 && index < Activeitem.Length)
        {
            Activeitem[index] = item;
        }
    }

    //액티브 아이템 사용 코드
    public void ActiveUseItem(string name)
    {
        if (Activeitem[0].name.Contains("niddle"))
        {
            Debug.Log("플레이어가 바늘 아이템을 사용해 회복");
            player.playerHealth = 0f;
        }
        else if (Activeitem[0].name.Contains("shield"))
        {
            Debug.Log("플레이어가 쉴드 아이템을 사용");
            
        }


        // 아이템 사용 후, 사용한 아이템을 Activeitem 배열에서 제거
        for (int i = 0; i < Activeitem.Length; i++)
        {
            if (Activeitem[i] != null && Activeitem[i].name == name)
            {
                Activeitem[i] = null;
                break;
            }
        }
    }


    private IEnumerator RestoreAbilitiesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 5초 후에 저장된 능력치로 복구
        player.bombPower = previousBombPower;
        player.bombRange = previousBombRange;
        player.playerSpeed = previousPlayerSpeed;

        // 슈퍼맨 아이템 비활성화
        isSupermanActive = false;
    }
}

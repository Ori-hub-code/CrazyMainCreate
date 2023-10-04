using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject player;
    Player playerLogic;
    Balloon balloonLogic;

    // 프리펩
    public GameObject waterBalloon1Prefab;
    public GameObject waterBalloon2Prefab;
    public GameObject waterBalloon3Prefab;
    public GameObject waterBalloon4Prefab;
    public GameObject waterBalloon5Prefab;
    public GameObject waterBalloon6Prefab;
    public GameObject waterBalloon7Prefab;

    public GameObject bubbleItemPrefab;
    public GameObject fluidItemPrefab;
    public GameObject rollerItemPrefab;

    GameObject[] waterBalloon1;
    GameObject[] waterBalloon2;
    GameObject[] waterBalloon3;
    GameObject[] waterBalloon4;
    GameObject[] waterBalloon5;
    GameObject[] waterBalloon6;
    GameObject[] waterBalloon7;



    GameObject[] bubbleItem;
    GameObject[] fluidItem;
    GameObject[] rollerItem;

    GameObject[] targetPool; // switch 문을 통해 생성될 오브젝트 배열을 용도

    void Awake()
    {
        playerLogic = player.GetComponent<Player>();
        balloonLogic.playerLogic = playerLogic;

        // 첫 로딩 시간 = 장면 배치 + 오브젝트 풀 생성

        // 한번에 등장할 개수를 고려하여 배열 길이 할당
        waterBalloon1 = new GameObject[20];
        waterBalloon2 = new GameObject[20];
        waterBalloon3 = new GameObject[20];
        waterBalloon4 = new GameObject[20];
        waterBalloon5 = new GameObject[20];
        waterBalloon6 = new GameObject[20];
        waterBalloon7 = new GameObject[20];

        //bubbleItem = new GameObject[15];
        //fluidItem = new GameObject[10];
        //rollerItem = new GameObject[10];

        Generate();

    }

    // Instantiate() 로 생성한 프레펩을 인스턴스를 배열에 저장
    void Generate()
    {
        // WaterBalloon
        for (int index = 0; index < waterBalloon1.Length; index++)
        {
            waterBalloon1[index] = Instantiate(waterBalloon1Prefab);
            waterBalloon1[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon2.Length; index++)
        {
            waterBalloon2[index] = Instantiate(waterBalloon2Prefab);
            waterBalloon2[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon3.Length; index++)
        {
            waterBalloon3[index] = Instantiate(waterBalloon3Prefab);
            waterBalloon3[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon4.Length; index++)
        {
            waterBalloon4[index] = Instantiate(waterBalloon4Prefab);
            waterBalloon4[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon5.Length; index++)
        {
            waterBalloon5[index] = Instantiate(waterBalloon5Prefab);
            waterBalloon5[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon6.Length; index++)
        {
            waterBalloon6[index] = Instantiate(waterBalloon6Prefab);
            waterBalloon6[index].SetActive(false);
        }
        for (int index = 0; index < waterBalloon7.Length; index++)
        {
            waterBalloon7[index] = Instantiate(waterBalloon7Prefab);
            waterBalloon7[index].SetActive(false);
        }

        // Item
        //for(int index = 0; index < bubbleItem.Length; index++) {
        //    bubbleItem[index] = Instantiate(bubbleItemPrefab);
        //    bubbleItem[index].SetActive(false);
        //}
        //for(int index = 0; index < fluidItem.Length; index++) {
        //    fluidItem[index] = Instantiate(fluidItemPrefab);
        //    fluidItem[index].SetActive(false);
        //}
        //for(int index = 0; index < rollerItem.Length; index++) {
        //    rollerItem[index] = Instantiate(rollerItemPrefab);
        //    rollerItem[index].SetActive(false);
        //}

    }

    // 풀 활용 -> 오브젝트 풀에 접근할 수 있는 함수 생성
    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "WaterBalloon1":
                targetPool = waterBalloon1;
                break;
            case "WaterBalloon2":
                targetPool = waterBalloon2;
                break;
            case "WaterBalloon3":
                targetPool = waterBalloon3;
                break;
            case "WaterBalloon4":
                targetPool = waterBalloon4;
                break;
            case "WaterBalloon5":
                targetPool = waterBalloon5;
                break;
            case "WaterBalloon6":
                targetPool = waterBalloon6;
                break;
            case "WaterBalloon7":
                targetPool = waterBalloon7;
                break;
                //case "BubbleItem":
                //    targetPool = bubbleItem;
                //    break;
                //case "FluidItem":
                //    targetPool = fluidItem;
                //    break;
                //case "RollerItem":
                //    targetPool = rollerItem;
                //    break;
        }
        for (int index = 0; index < targetPool.Length; index++)
        {
            // 비활성화 된 오브젝트에 접근하여 활성화 후, 반환
            if (!targetPool[index].activeSelf)
            { // activeSelf : 오브젝트 활성화
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }
        // 풀(Pool)에 더 이상 활성화되지 않은 오브젝트가 남아있지 않을 때 null 값을 return 해줌
        // 오브젝트가 모두 사용 중인 경우에는 targetPool[index].SetActive(true);에 도달하지 않게 됨
        return null;
    }

    // 지정한 오브젝트 풀을 가져오는 함수 추가
    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "WaterBalloon1":
                targetPool = waterBalloon1;
                break;
            case "WaterBalloon2":
                targetPool = waterBalloon2;
                break;
            case "WaterBalloon3":
                targetPool = waterBalloon3;
                break;
            case "WaterBalloon4":
                targetPool = waterBalloon4;
                break;
            case "WaterBalloon5":
                targetPool = waterBalloon5;
                break;
            case "WaterBalloon6":
                targetPool = waterBalloon6;
                break;
            case "WaterBalloon7":
                targetPool = waterBalloon7;
                break;
                //case "BubbleItem":
                //    targetPool = bubbleItem;
                //    break;
                //case "FluidItem":
                //    targetPool = fluidItem;
                //    break;
                //case "RollerItem":
                //    targetPool = rollerItem;
                //    break;
        }

        return targetPool;
    }
}

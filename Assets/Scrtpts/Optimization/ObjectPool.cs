using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private class PoolItem
    {
        public bool isActive; // "GameObject"의 활성화/비활성화 정보
        public GameObject Prefabs; // 화면에 보이는 실제 게임오브젝트
    }

    int increasCount = 5; // 오브젝트가 부족할 때 Instantiate()로 추가 생성하는 오브젝트 수
    int maxCount; // 현재 리스트에 등록되어 있는 오브젝트 수
    int activeCount; // 현재 게임에 사용되고 있는 오브젝트 수

    private GameObject poolobject; // 오브젝트 풀링에서 관리하는 게임 오브젝트 프리팹;
    private List<PoolItem> poolItemList; // 관리되는 모든 오브젝트를 저장하는 리스트

    private void OnEnable()
    {
        ActivatePoolItem();
        DeactivatePoolItem(poolobject);
    }

    // 클래스 이름과 같은 이름의 함수는 생성자로 해당 클래스로 변수를 선언하고,
    // 메모리가 할당될 때 자동으로 호출됩니다.
    public ObjectPool(GameObject poolObject)
    {
        maxCount = 0;
        activeCount = 0;
        this.poolobject = poolObject;

        poolItemList = new List<PoolItem>();

        InstantiateObject();
    }

    public void InstantiateObject() // increaseCount 단위로 오브젝트를 생성하는 함수
    {
        maxCount += increasCount;

        for(int i = 0; i < increasCount; ++i)
        {
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.Prefabs = GameObject.Instantiate(poolobject);
            poolItem.Prefabs.SetActive(false);

            poolItemList.Add(poolItem);
        }
    }

    public void Destoryobject() // 현재 관리중인 모든 오브젝트를 삭제하는 함수
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;

        for (int i = 0; i < count; ++i)
        {
            GameObject.Destroy(poolItemList[i].Prefabs);
        }

        poolItemList.Clear();
    }

    public GameObject ActivatePoolItem() // poolItemList에 저장되어 있는 오브젝트를 활성화해서 사용하는 함수
    {
        if (poolItemList == null) return null;

        // 현재 생성에서 관리하는 모든 오브젝트 개수와 현재 활성화 상태인 오브젝트 개수 비교
        // 모든 오브젝트가 활성화 상태이면 새로운 오브젝트 필요
        if (maxCount == activeCount)
        {
            InstantiateObject();
        }

        int count = poolItemList.Count;

        for(int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.isActive == false)
            {
                activeCount++;

                poolItem.isActive = true;
                poolItem.Prefabs.SetActive(true);
                poolItem.Prefabs.transform.position = Vector3.zero;

                return poolItem.Prefabs;
            }
        }

        return null; // 현재 모든 오브젝트가 사용중이면 InstantiateObjects()로 추가 생성
    }

    public void DeactivatePoolItem(GameObject removeObject) // 현재 사용이 완료된 오브젝트를 비활성화 상태로 설정하는 함수 
    {
        if (poolItemList == null || removeObject == null) return;

        int count = poolItemList.Count;

        for(int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if(poolItem.Prefabs == removeObject)
            {
                activeCount--;

                poolItem.isActive = false;
                poolItem.Prefabs.SetActive(false);
                poolItem.Prefabs.transform.position = Vector3.zero;

                return;
            }     
        }
    }
}

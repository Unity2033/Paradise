using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingDish : MonoBehaviour
{
    private Dictionary<int, Dish> dishs;

    private int dummyDish;
    private Dish beforeDish;
    private Dish afterDish;

    public List<int> rightDishPosition;
    public List<int> myDishPosition;

    void Start()
    {
        //   Á¤´ä
        // ³ë¶û »¡°­ ÆÄ¶û
        // ºÐÈ« °ËÁ¤ Èò»ö
        // ³²»ö ÃÊ·Ï ÁÖÈ²

        rightDishPosition = new List<int> { 9, 8, 4, 7, 5, 6, 3, 2, 1 };
        myDishPosition = new List<int>();

        dishs = new Dictionary<int, Dish>();
        beforeDish = new Dish();
        afterDish = new Dish();

        for (int i = 0; i < transform.childCount; i++)
        {
            var dish = transform.GetChild(i);

            var dishID = dish.GetComponent<Dish>();

            dishID.id = i;

            dishs.Add(i, dishID);
        }
    }
    public void OnMouseDownDish(Dish dish)
    {
        ChoiceDish(dish);
    }

    private void ChoiceDish(Dish dish)
    {
        if (beforeDish == null)
        {
            beforeDish = dish;
            beforeDish.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (beforeDish.id == dish.id)
            {
                CancelDish();

                return;
            }

            afterDish = dish;

            ChangingDish();
        }
    }

    private void CancelDish()
    {
        beforeDish.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);

        beforeDish = null;
    }

    private void ChangingDish()
    {
        dummyDish = beforeDish.transform.GetSiblingIndex();
        beforeDish.transform.SetSiblingIndex(afterDish.transform.GetSiblingIndex());
        afterDish.transform.SetSiblingIndex(dummyDish);

        CancelDish();
        afterDish = null;
        dummyDish = new int();

        CheckDish();
    }

    private void CheckDish()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var dish = transform.GetChild(i);

            var dishID = dish.GetComponent<Dish>().id;

            myDishPosition.Add(dishID + 1);
        }

        if(Enumerable.SequenceEqual(rightDishPosition, myDishPosition))
            Success();
        else
            myDishPosition.Clear();
    }

    private void Success()
    {
        Debug.Log("¼º°ø");
    }
}

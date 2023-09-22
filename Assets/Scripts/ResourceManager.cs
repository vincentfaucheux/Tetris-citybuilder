using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{

    [field: SerializeField]
    public int goldAmount { get; private set; } = 100;
    public int peopleAmount { get; private set; } = 0;
    public int foodAmount { get; private set; } = 0;
    

    public event Action onGoldChange;
    public event Action onPeopleChange;
    public event Action onFoodChange;

    public void AddGold(int amount)
    {
        goldAmount += amount;
        if (onGoldChange != null)
        {
            onGoldChange();
        }
    }

    public void AddPeople(int amount)
    {
        peopleAmount += amount;
        if (onPeopleChange != null)
        {
            onPeopleChange();
        }
    }

    public void AddFood(int amount)
    {
        foodAmount += amount;
        if (onFoodChange != null)
        {
            onFoodChange();
        }
    }

    public bool CanAfford(Cost cost)
    {
        return (cost.gold <= goldAmount && cost.food <= foodAmount && cost.people <= peopleAmount);
    }

    public void Substract(Cost cost)
    {
        AddGold(-cost.gold);
        AddFood(-cost.food);
        AddPeople(-cost.people);
    }
}



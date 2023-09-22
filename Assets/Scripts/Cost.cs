using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cost 
{
    public int gold;
    public int food;
    public int people;

    public Cost(int gold = 0, int food = 0,  int people = 0)
    {
        this.gold = gold;
        this.food = food;   
        this.people = people;
    }

    public static Cost operator +(Cost cost1, Cost cost2)
    {
        Cost cost = new Cost(
            cost1.gold + cost2.gold,
            cost1.food + cost2.food,
            cost1.people + cost2.people
        );
        return cost;
    }

    public override string ToString()
    {
        return $"Gold: {gold}, Food: {food}, People: {people}";
    }
}

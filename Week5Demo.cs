using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int Level;
    protected int Health;
    private int Mana;

    public void AddHealth(int amount)
    {
        Health += amount;
    }
}

public class Week5Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character char1 = new Character(); 
        char1.Level = 100;
        char1.AddHealth(20);

        Character char2 = char1; // char2 is being referred to as char1
        char2.Level = 10; //sets char2 level to 10

        Debug.Log("Chat 1 level is " + char1.Level);

        int value1 = 56;

        int value2 = value1;

        value2 = 5000;

        Debug.Log("Value1 is " + value1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

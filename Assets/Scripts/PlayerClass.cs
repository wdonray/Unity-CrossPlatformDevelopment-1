using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int intel;
    public int dex;
    public int chr;
    public int vit;
    public string name;

    private int randomintel = Random.Range(1, 11);
    private int randomdex = Random.Range(1, 11);
    private int randomchr = Random.Range(1, 11);
    private int randomvit = Random.Range(10, 51);

    public List<string> names = new List<string>(); //= ( "Snake", "Roy", "Kirby", "Mew" );
    //private Dictionary<string, int> dic = new Dictionary<string, int>()
    //{
    //    {names[0], 1};
    //};
 
    public PlayerClass()
    {
        intel = randomintel;
        dex = randomdex;
        chr = randomchr;
        vit = randomvit;
        names.Add("Snake");
        names.Add("Roy");
    }

}

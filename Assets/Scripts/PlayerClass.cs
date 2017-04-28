using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public int Intel_stat;
    public int Dex_Stat;
    public int Char_Stat;
    public int Vit_Stat;
    public string Player_Name;

    private int Rnd_Intel = Random.Range(1, 11);
    private int Rnd_Dex = Random.Range(1, 11);
    private int Rnd_Char = Random.Range(1, 11);
    private int Rnd_Vit = Random.Range(10, 51);

    public List<string> List_Names = new List<string>(); 
 
    public PlayerClass()
    {
        Intel_stat = Rnd_Intel;
        Dex_Stat = Rnd_Dex;
        Char_Stat = Rnd_Char;
        Vit_Stat = Rnd_Vit;
        List_Names.Add("Lich King");
        List_Names.Add("Necromorphs");
        List_Names.Add("Eve");
        List_Names.Add("M. Bison");
        List_Names.Add("Albert Wesker");
        List_Names.Add("GLaDOS");
        List_Names.Add("Dr. Wily");
        List_Names.Add("King Pig");
        Player_Name = "";
    }

}

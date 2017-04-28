using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBehaviour : MonoBehaviour
{
    public Text Intel_Text, Dex_Text, Charisma_Text, Vit_Text, Log_Text, Name_Text;
    public Slider HP_Slider;
    public Button Attack_Button;
    public PlayerClass Player;

    private float timer = 1.0f;
    private int DMG_Dealt;
    private void Start()
    {
        Player = new PlayerClass();
        Player.Player_Name = Player.List_Names[Random.Range(0, Player.List_Names.Count)];
        DMG_Dealt = 0;
        HP_Slider.maxValue = Player.Vit_Stat;
        HP_Slider.value = Player.Vit_Stat;
        Populate_Text();
        Button btn = Attack_Button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {

        if (timer > 3)
        {
            DMG_Dealt = Random.Range(5, 11);
            Player.Vit_Stat -= DMG_Dealt;
            timer = 1.0f;
        }
        timer += Time.deltaTime;
        if (Player.Vit_Stat > 0)
        {
            Populate_Text();
            HP_Slider.value = Player.Vit_Stat;
        }
        else
        {
            Player = null;
            Player = new PlayerClass();
            HP_Slider.maxValue = Player.Vit_Stat;
            HP_Slider.value = Player.Vit_Stat;
            Player.Player_Name = Player.List_Names[Random.Range(0, Player.List_Names.Count)];
        }
    }
    public void Populate_Text()
    {
        Intel_Text.text = "Intellegince = " + Player.Intel_stat;
        Dex_Text.text = "Dexterity = " + Player.Dex_Stat;
        Charisma_Text.text = "Charisma = " + Player.Char_Stat;
        Vit_Text.text = "Vitality = " + Player.Vit_Stat;
        Log_Text.text = "Damage Dealt: " + DMG_Dealt;
        Name_Text.text = Player.Player_Name;
    }
    void TaskOnClick()
    {
        Player.Vit_Stat -= DMG_Dealt;
    }
}

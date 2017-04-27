using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBehaviour : MonoBehaviour
{
    public Text intel, dex, charisma, vit, Log_Text;
    public Slider slider;
    public Button attack;
    public PlayerClass Player;

    private float timer = 1.0f;
    private int damage;
    private void Start()
    {
        Player = new PlayerClass();
        //Player.name = Player.names[Random.Range(0, Player.name.Length)];
        damage = 0;
        slider.maxValue = Player.vit;
        slider.value = Player.vit;
        Populate_Text();
        Button btn = attack.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {

        if (timer > 3)
        {
            damage = Random.Range(5, 11);
            Player.vit -= damage;
            timer = 1.0f;
        }
        timer += Time.deltaTime;
        if (Player.vit > 0)
        {
            Populate_Text();
            slider.value = Player.vit;
        }
        else
        {
            Player = null;
            Player = new PlayerClass();
            slider.maxValue = Player.vit;
            slider.value = Player.vit;
            //Player.name = Player.names[Random.Range(0, Player.name.Length)];
        }
    }
    public void Populate_Text()
    {
        intel.text = "Intellegince = " + Player.intel;
        dex.text = "Dexterity = " + Player.dex;
        charisma.text = "Charisma = " + Player.chr;
        vit.text = "Vitality = " + Player.vit;
        Log_Text.text = "Damage Dealt: " + damage;
       //Name_Text.text = Player.name;
    }
    void TaskOnClick()
    {
        Player.vit -= damage;
    }
}

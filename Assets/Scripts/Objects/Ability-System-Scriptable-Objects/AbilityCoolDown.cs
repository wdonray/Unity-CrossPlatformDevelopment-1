using UnityEngine;
using UnityEngine.UI;

public class AbilityCoolDown : MonoBehaviour
{
    [SerializeField] private Ability ability;

    public string abilityButtonAxisName = "Fire1";
    private AudioSource abilitySource;
    private float coolDownDuration;
    public Text coolDownTextDisplay;
    private float coolDownTimeLeft;
    public Image darkMask;
    private Image myButtonImage;
    private float nextReadyTime;

    [SerializeField] private GameObject weaponHolder;


    private void Start()
    {
        Initialize(ability, weaponHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        coolDownDuration = ability.aBaseCoolDown;
        ability.Initialize(weaponHolder);
        AbilityReady();
    }

    // Update is called once per frame
    private void Update()
    {
        var coolDownComplete = Time.time > nextReadyTime;
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown(abilityButtonAxisName))
                ButtonTriggered();
        }
        else
        {
            CoolDown();
        }
    }

    private void AbilityReady()
    {
        coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        var roundedCd = Mathf.Round(coolDownTimeLeft);
        coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = coolDownTimeLeft / coolDownDuration;
    }

    private void ButtonTriggered()
    {
        nextReadyTime = coolDownDuration + Time.time;
        coolDownTimeLeft = coolDownDuration;
        darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        abilitySource.clip = ability.aSound;
        abilitySource.Play();
        ability.TriggerAbility();
    }
}
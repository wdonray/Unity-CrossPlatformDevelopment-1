using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EncounterBehaviour : MonoBehaviour
{
    public Encounter encounter;

    //use this for initialization
    private void Start()
    {
        encounter.Initialize(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            encounter.EncounterStart();
            encounter.EncounterStart(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            encounter.EncounterUnderway();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (encounter.Contained)
            {
                encounter.EncounterEnd();
            }
        }
    }
}
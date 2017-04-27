using UnityEngine;

public class KinematicFixBehaviour : MonoBehaviour
{
    public GameBehaviour GameBehaviour;

    private void Start()
    {
        GameBehaviour = GetComponent<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKeyDown(KeyCode.F))
            return;

        GameBehaviour.Boxes.ForEach(box => box.GetComponent<Rigidbody>().isKinematic = false);

    }
}
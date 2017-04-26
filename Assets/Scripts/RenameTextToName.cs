using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenameTextToName : MonoBehaviour {

	// Use this for initialization
	[ContextMenu("Rename")]
    void Rename()
    {
        GetComponent<Text>().text = name;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flicker : MonoBehaviour
{

    TextMeshProUGUI _title;


    // Start is called before the first frame update
    void Start()
    {
        _title = GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    IEnumerator FlickerTitle()
    {
        _title.enabled = !_title.enabled;


        yield return null;
        
    }
}

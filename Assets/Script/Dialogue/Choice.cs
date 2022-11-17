using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
  
public class Choice : MonoBehaviour
{
    public Dialogue dialogue;
    public int choiceIndex;
    public TextMeshProUGUI nameChoice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select() {
        dialogue.Select(choiceIndex);
    }



}

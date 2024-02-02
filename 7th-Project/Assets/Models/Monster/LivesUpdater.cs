using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LivesUpdater : MonoBehaviour
{
    public Object player;
    public TextMeshProUGUI liveText;

    // Start is called before the first frame update
    void Start()
    {
        liveText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = player.GetComponent<PlayerMove>().lives.ToString();
    }
}

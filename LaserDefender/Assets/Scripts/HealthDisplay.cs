using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        //this is done instead of dragging ScoreText and GameSession object from hierarchy to their respective scripts
        //done in c# instead of unity
        healthText = GetComponent<Text>(); //checks for components of type Text
        player = FindObjectOfType<Player>(); //checks hierarchy for object of type Player
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}

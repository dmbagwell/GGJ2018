﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Player {Disease, Doctor};

public class TurnManager : MonoBehaviour {
	
	public GameObject passTurnScreen;
	public GameObject passTurnScreenText;

	public CityManager cityManager;
    public GameObject resetButton;

    public Player currentPlayer = Player.Disease;
    public int turnCounter;
    public int maxTurns;

    // Use this for initialization
    void Start () {
        turnCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        turnCounter = 0;
        currentPlayer = Player.Disease;
        passTurnScreen.SetActive(false);
        resetButton.SetActive(false);
    }
    public void ReportWinner()
    {
        passTurnScreen.SetActive(true);
        Image image = passTurnScreen.GetComponent<Image>();
        Text text = passTurnScreenText.GetComponent<Text>();
        image.color = Color.magenta;
        resetButton.SetActive(true);

        if (turnCounter > maxTurns)
        {
            text.text = "Doctors win. Everybody lives.";
        }
        else
        {
            text.text = "The world is dead. It's the disease's planet now.";
        }
    }

    public void EndTurnButtonPressed () {
		ToggleCurrentPlayer();
        passTurnScreen.SetActive(true);
	}

    public bool CheckIfExceededTurnCount()
    {
        return (turnCounter > maxTurns) && (currentPlayer == Player.Disease);
    }

    public void StartTurnButtonPressed () {
		cityManager.ResetLines(currentPlayer);
		passTurnScreen.SetActive(false);
	}

	void ToggleCurrentPlayer () {
		Image image = passTurnScreen.GetComponent<Image>();
		Text text = passTurnScreenText.GetComponent<Text>();

		switch (currentPlayer) {
		case Player.Disease: 
			image.color = Color.green;
			text.text = "Doctor's Turn";
			currentPlayer = Player.Doctor;
            cityManager.StartDoctorTurn();
            break;

		case Player.Doctor: 
			image.color = Color.red;
			text.text = "Disease's Turn";
			currentPlayer = Player.Disease;
            turnCounter++;
            cityManager.StartDiseaseTurn();
            break;
		}
	}
}

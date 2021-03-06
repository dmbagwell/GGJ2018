﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityManager : MonoBehaviour {
    public List<GameObject> cityDirectory;
//    public List<GameObject> diseasedCities;
//    public List<GameObject> deadCities;
//    public List<GameObject> cleanCities;
    public Sprite cleanCity;
    public Sprite diseasedCity;
    public Sprite deadCity;

    public int outbreakLimit = 5;

	// Use this for initialization
	void Start ()
    {
        //cityDirectory = new List<GameObject>();
//        cleanCities = new List<GameObject>();
//        diseasedCities = new List<GameObject>();
//        deadCities = new List<GameObject>();

        Sprite tempSprite;
        for(int i = 0;i<cityDirectory.Count;i++)
        {
            cityDirectory[i].GetComponent<Image>().sprite = cleanCity;
//            cleanCities.Add(cityDirectory[i]);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void StartDiseaseTurn()
    {
        int i;
        City tempCity;
        // Increase outbreak levels
        for (i = 0; i < cityDirectory.Count; i++)
        {
            tempCity = cityDirectory[i].GetComponent<City>();
           // if (tempCity.DoIHaveAllCures())
            {
                IncreaseOutbreak(cityDirectory[i]);
            }
        }
    }

    public void StartDoctorTurn()
    {
        //
    }


    public void InfectCity(GameObject city/*, Disease strain */)
    {
        int i;
        bool found = false;
        Disease strain = new Disease();
        strain.StrainID = 2;

        City tempCity = city.GetComponent<City>();
        tempCity.AddDisease(strain);

        for (i = 0; i < cityDirectory.Count; i++)
        {
            if (cityDirectory[i] == city)
            {
                found = true;
                break;
            }
        }

        if (found)
        {
            city.GetComponent<Image>().sprite = diseasedCity;
            //cleanCities.RemoveAt(i);
            //diseasedCities.Add(city);
        }
    }

    public void IncreaseOutbreak(GameObject city)
    {
        int i;
        bool found = false;

        City tempCity = city.GetComponent<City>();
        tempCity.IncreaseOutbreakLevel();

        if (tempCity.GetOutbreakLevel() > outbreakLimit)
        {
            for (i = 0; i < cityDirectory.Count; i++)
            {
                if (cityDirectory[i] == city)
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                city.GetComponent<Image>().sprite = deadCity;
                //diseasedCities.RemoveAt(i);
                //deadCities.Add(city);
            }
        }
    }

}

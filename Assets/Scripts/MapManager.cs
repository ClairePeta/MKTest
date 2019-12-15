﻿using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MKTest/Map Manager")]
public class MapManager : ScriptableObject
{
    public List<MapSection> sections; //The list of sections to choose from after starting
    public GameObject startSection;  //initial map section - this is the same every game
    public List<MapSection> activeSections; //The list of sections that have been placed on the map (and not removed)
    MapSection lastSection; //Which map-section was most recently added?
    public float startX; //The x-position of the current start of the track
    float endX; //The x-position of the current end of the track
    public int minConns = 1; // this was implemented incase i made the designs larger and harder, which would require say two or more connections

    public void init()
    {
        Globals.paused = false;
        startX = 0;
        endX = 0;

        activeSections = new List<MapSection>();
        addSection(startSection.GetComponent<MapSection>());

        checkForward();
    }

    public void reset()
    {
        for(int i = activeSections.Count-1; i >=0; i--)
        {
            activeSections[i].destroySection();
            activeSections.RemoveAt(i);
        }
    }

    void chooseNextSection()
    {
        //First, we determine which sections are valid 
        List<MapSection> validSections = new List<MapSection>();
        int count = -1;

        foreach (MapSection section in sections)
        {
            count++;
            if (section == null)
            {
                continue;
            }

            if (checkSegments(section))
            {
                //If a segment is a valid continuation of the current most-recent segment, add it to the list
                validSections.Add(section);
            }
        }

        //Having generated our list, we choose a random segment from it
        int selectedIndex = Random.Range(0, validSections.Count);

        MapSection nextSection = validSections[selectedIndex];
        addSection(nextSection);
    }

    void addSection(MapSection section)
    {
        //Instantiate new section at x = endX
        Vector3 pos = new Vector3(endX, 0.0f, 0.0f);
        GameObject newSection = (GameObject)Instantiate(section.gameObject, pos, Quaternion.identity);

        MapSection newSectionScript = newSection.GetComponent<MapSection>();

        newSection.name = newSectionScript.name;
        activeSections.Add(newSectionScript);
        lastSection = newSectionScript;

        endX += newSectionScript.length;
    }

    bool checkSegments(MapSection second)
    {
        return checkSegments(this.lastSection, second);
    }

    bool checkSegments(MapSection first, MapSection second)
    {
        int connections = 0;

        foreach (int exit in first.pathExit)
        {
            foreach (int entry in second.pathEnterance)
            {
                if (checkConnection(exit, entry))
                {
                    connections++;
                }
            }
        }
        return (connections >= minConns);
    }

    bool checkConnection(float exit, float entry)
    {
        //this was set up incase i had harder map sections that didnt have the initial flat ground at -4
        //If the squares being checked don't line up, the connection is invalid
        if (exit != entry)
        {
            return false;
        }
        return true;
    }

    //Check whether it's time to extend the track forward
    void checkForward()
    {
        //We check if the end of the last section of track is in sight
        if (endX < Globals.playerPositionX + 10)
        {
            chooseNextSection();
            checkForward();
        }
    }

    //Check whether it's time to delete the oldest section of active track
    void checkBack()
    {
        //We check if the end of the first section of track is still in sight
        float firstSectionEnd = startX + activeSections[0].length; //Get the middle of the end of the first track section

        //If it's not, then we remove it
        if (firstSectionEnd < Globals.playerPositionX - 10)
        {
            startX += activeSections[0].length;
            activeSections[0].destroySection();
            activeSections.RemoveAt(0);
        }
    }

    //Checks in both directions for sections needing to be added or removed
    public void checkTrack()
    {
        checkForward();
        checkBack();
    }
}

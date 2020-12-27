﻿using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class Main : MonoBehaviour
{
    public const int CARD_TYPES = 4;
    public const int CARD_COUNT = 13;
    
    public CardType[] CardTypes;
    public static Main Instance { get; private set; }
    
    public Client Client { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Initialize();
        DontDestroyOnLoad(gameObject);
    }

    private void Initialize()
    {
        CardTypes = Resources.LoadAll<CardType>("CardTypes");
        Client = new Client();
    }
}

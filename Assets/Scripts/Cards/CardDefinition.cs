using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardDefinition
{
    public int id;
    public string cardName;
    public Sprite cardArtwork;
    [TextArea(1, 3)]
    public string cardBiography;
    public string[] cardEffects;
    public string cardElement;
    public Sprite cardElementArtwork;
    public string cardStatus;
    public string cardType;
    public AudioSource cardVoiceClip;
    public int cost;
    public int attack;
    public int defense;
    public Sprite cardClassArtwork;

    public enum CardClass
    {
        Psion,
        Evoker,
        Enchanter,
        Diviner,
        Druid,
        Artificer
    }

    public CardClass cardClass;

    public void Card()
    {

    }

    public void Card(
        int Id, string CardName, Sprite CardArtwork, string CardBiography, string[] CardEffects, 
        string CardElement, Sprite CardElementArtwork, CardClass CardClass, string CardStatus,
        string CardType, AudioSource CardVoiceClip, int Cost, int Attack, int Defense, Sprite CardClassArtwork
    ) 
    {
        id = Id;
        cardName = CardName;
        cardArtwork = CardArtwork;
        cardBiography = CardBiography;
        cardEffects = CardEffects;
        cardElement = CardElement;
        cardElementArtwork = CardElementArtwork;
        cardClass = CardClass;
        cardStatus = CardStatus;
        cardType = CardType;
        cardVoiceClip = CardVoiceClip;
        cost = Cost;
        attack = Attack;
        defense = Defense;
        cardClassArtwork = CardClassArtwork;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName="Scriptable Objects/Card")]
public class Card: ScriptableObject
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{

    public static List<CardDefinition> cardList = new List<CardDefinition>();


    void Awake()
    {
        // Card Definition
        // int Id, string CardName, Sprite CardArtwork, string CardBiography,
        // string[] CardEffects, string CardElement, Sprite CardElementArtwork, CardClass CardClass,
        // string CardStatus, string CardType, AudioSource CardVoiceClip, int Cost, int Attack, int Defense
        
        // cardList.Add(new CardDefinition(0, "Test0", Artwork.Cards.artwork.Load <Sprite>("0"), "Test0 Desc", new string[] {"No Effect"}, "Water", , CardClass.Druidic, "Available", "unit", , 0, 0, 0, ));
        // cardList.Add(new CardDefinition(1, "Test1", Artwork.Cards.artwork.Load <Sprite>("1"), "Test1 Desc", new string[] {"No Effect"}, "Fire", , CardClass.Psionic, "Available", "unit", , 1, 1, 1, ));
        // cardList.Add(new CardDefinition(2, "Test2", Artwork.Cards.artwork.Load <Sprite>("2"), "Test2 Desc", new string[] {"No Effect"}, "Earth", , CardClass.Artificer, "Available", "unit", , 2, 2, 2, ));
        // cardList.Add(new CardDefinition(3, "Test3", Artwork.Cards.artwork.Load <Sprite>("3"), "Test3 Desc", new string[] {"No Effect"}, "Wind", , CardClass.Enchanter, "Available", "unit", , 3, 4, 2, ));
        // cardList.Add(new CardDefinition(4, "Test4", Artwork.Cards.artwork.Load <Sprite>("4"), "Test4 Desc", new string[] {"No Effect"}, "Water", , CardClass.Evoker, "Available", "unit", , 4, 4, 4, ));
        // cardList.Add(new CardDefinition(5, "Test5", Artwork.Cards.artwork.Load <Sprite>("5"), "Test5 Desc", new string[] {"No Effect"}, "Fire", , CardClass.Theurge, "Available", "unit", , 5, 5, 5, ));
    }
}

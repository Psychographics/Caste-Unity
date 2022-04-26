using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{

    public static List<PlayingCard> cardList = new List<PlayingCard>();

    void Awake()
    {
        // PlayingCard Definition
        // int Id, string CardName, Sprite CardArtwork, string CardBiography, string[] CardEffects, string CardElement,
        // Sprite CardElementArtwork, CardClass CardClass, string CardStatus, string CardType, AudioSource CardVoiceClip,
        // int Cost, int Attack, int Defense, Sprite CardClassArtwork, Sprite CardBackArtwork

        cardList.Add(new PlayingCard(0, "Test 0", Resources.Load<Sprite>("Cards/artwork/1"), "Test 0 Desc", new string[] {"No Effect"}, "Wind", Resources.Load<Sprite>("Cards/elements/wind"), PlayingCard.CardClass.Druid, "Available", "unit", null, 0, 0, 0, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
        cardList.Add(new PlayingCard(1, "Test 1", Resources.Load<Sprite>("Cards/artwork/2"), "Test 1 Desc", new string[] {"No Effect"}, "Earth", Resources.Load<Sprite>("Cards/elements/earth"), PlayingCard.CardClass.Psion, "Available", "unit", null, 1, 1, 1, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
        cardList.Add(new PlayingCard(2, "Test 2", Resources.Load<Sprite>("Cards/artwork/3"), "Test 2 Desc", new string[] {"No Effect"}, "Fire", Resources.Load<Sprite>("Cards/elements/fire"), PlayingCard.CardClass.Artificer, "Available", "unit", null, 2, 2, 2, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
        cardList.Add(new PlayingCard(3, "Test 3", Resources.Load<Sprite>("Cards/artwork/4"), "Test 3 Desc", new string[] {"No Effect"}, "Water", Resources.Load<Sprite>("Cards/elements/water"), PlayingCard.CardClass.Enchanter, "Available", "unit", null, 3, 4, 2, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
        cardList.Add(new PlayingCard(4, "Test 4", Resources.Load<Sprite>("Cards/artwork/4"), "Test 4 Desc", new string[] {"No Effect"}, "Water", Resources.Load<Sprite>("Cards/elements/water"), PlayingCard.CardClass.Evoker, "Available", "unit", null, 4, 4, 4, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
        cardList.Add(new PlayingCard(5, "Test 5", Resources.Load<Sprite>("Cards/artwork/5"), "Test 5 Desc", new string[] {"No Effect"}, "Water", Resources.Load<Sprite>("Cards/elements/water"), PlayingCard.CardClass.Diviner, "Available", "unit", null, 5, 5, 5, Resources.Load<Sprite>("Caste/small/open_book_small"), Resources.Load<Sprite>("Assets/Artwork/Cards/artwork/5")));
    }
}

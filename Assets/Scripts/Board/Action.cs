using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public enum Action
    {
        //Obowi�zkowe akcje
        COMMON_ROOM_CHOICE,             //jedna dowolna karta lub wymiana jednego przedmiotu
        FIGHT_FIELD,                    //wszystkie pola z pojedynkiem
        GET_ONE_BOOK,                   //dzia� ksi�g zakazanych, wszystkie pola z ksi��k�
        GET_ONE_ELIXIR,                 //wszystkie pola z eliksirem
        GET_ONE_EVENT,                  //wszystkie pola z wydarzeniem
        GET_ONE_EXERCISE,               //wszystkie pola ze sprawowaniem
        GET_ONE_SPELL,                  //klasy: "zakl�cia i uroki", "transmutacja", "obrona przed czarn� magi�", wszystkie pola z zakl�ciem
        GET_ONE_SPELL_AND_ONE_ELIXIR,   //chatka Hagrida        
        GET_TWO_BOOKS,                  //Esy i floresy
        GET_TWO_ELIXIRS,                //klasy: "eliksiry", "zielarstwo", "opieka nad magicznymi stworzeniami", gabinet Snape'a, biblioteka
        GET_TWO_SPELLS,                 //gabinet Dumbledore'a, Sklep z kot�ami Madame Potage
        GET_QUIDDITCH_CARD,             //Markowy sprz�t do Quidditcha

        //Warunkowe i nieobowi�zkowe 
        ADD_TWO_LIVES,                  //dziurawy kocio� 
        ADD_THREE_LIVES,                //kuchnia 
        ADD_FOUR_LIVES,                 //pola +4� (ko�o zielarstwa, ko�o jeziora) 
        ADD_FIVE_LIVES,                 //pola +5� (ko�o jeziora)
        ADD_SIX_LIVES,                  //skrzyd�o szpitalne
        CAN_MAKE_MISSION,               //wszystkie pola z misj�
        CAN_PASS_EXAMS,                 //klasy
        CAN_USE_FIUU,                   //wie�a zamkowa
        CAN_USE_PORTKEY,                //boisko do quidditcha

        //Mo�liwe, ale nieobowi�zkowe akcje
        CAN_GET_THING,                  //wszystkie pola z gwiazdk�
        CAN_START_QUIDDITCH,            //boisko do Quidditch
        CAN_TELEPORT                    //wszystkie pola portalowe
    }

    public static class ActionText
    {
        public static string GetActionText(Action action, List<int> missionNumbers)
        {
            SpecialPower power = GameManager.GetMyPlayer().SpecialPower;

            switch (action)
            {
                case Action.COMMON_ROOM_CHOICE:
                    return "We� jedn� dowoln� kart� lub zaproponuj wymian� przedmiotu pozosta�ym graczom.";
                case Action.FIGHT_FIELD:
                    return "Pobierz kart� z pojedynkiem i przeprowad� walk�.";
                case Action.GET_ONE_BOOK:
                    if (power == SpecialPower.GetOneMoreBook)
                        return "We� dwie karty ksi�gi.";
                    else
                        return "We� jedn� kart� ksi�gi.";
                case Action.GET_ONE_ELIXIR:
                    if (power == SpecialPower.GetOneMoreElixir)
                        return "We� dwie karty eliksiru.";
                    else
                        return "We� jedn� kart� eliksiru.";
                case Action.GET_ONE_EVENT:
                    return "We� jedn� kart� wydarzenia.";
                case Action.GET_ONE_EXERCISE:
                    return "We� jedn� kart� sprawowania.";
                case Action.GET_ONE_SPELL:
                    if (power == SpecialPower.GetOneMoreSpell)
                        return "We� dwie karty zakl�cia.";
                    else
                        return "We� jedn� kart� zakl�cia.";
                case Action.GET_TWO_BOOKS:
                    return "We� dwie karty ksi�gi.";
                case Action.GET_TWO_ELIXIRS:
                    return "We� dwie karty eliksiru.";
                case Action.GET_TWO_SPELLS:
                    return "We� dwie karty zakl�cia.";
                case Action.GET_QUIDDITCH_CARD:
                    return "We� jedn� kart� quidditcha.";
                case Action.ADD_TWO_LIVES: 
                    return "Je�li masz miejsce, dobierz 2 �ycia.";
                case Action.ADD_THREE_LIVES:
                    return "Je�li masz miejsce, dobierz 3 �ycia.";
                case Action.ADD_FOUR_LIVES:
                    return "Je�li masz miejsce, dobierz 4 �ycia.";
                case Action.ADD_FIVE_LIVES:
                    return "Je�li masz miejsce, dobierz 5 �y�.";
                case Action.ADD_SIX_LIVES:
                    return "Je�li masz miejsce, dobierz 6 �y�.";
                case Action.CAN_MAKE_MISSION:
                    string result = "Je�eli spe�niasz wszystkie warunki odpowiedniej misji (nr ";
                    for (int i = 0; i < missionNumbers.Count; i++)
                    {
                        result += $"{missionNumbers[i]}";
                        if (i < missionNumbers.Count - 1) result += ", ";
                    }
                    result += "), mo�esz j� wykona�.";
                    return result;
                case Action.CAN_PASS_EXAMS:
                    return "Mo�esz zda� egzaminy, je�li posiadasz karty ksi�gi powi�zane z t� klas�.";
                case Action.CAN_USE_FIUU:
                    return "Mo�esz transportowa� si� za pomoc� proszka fiuu na 1 z 7 p�l na planszy 2 (z wyj�tkiem \"Cmentarza w Little Hangleton\"). " +
                        "Na koniec tury wr�� do miejsca, z kt�rego si� przenios�e�.";
                case Action.CAN_USE_PORTKEY:
                    return "Mo�esz za pomoc� �wistoklika przenie�� si� na pole \"Cmentarz w Little Hangleton\".";
                case Action.CAN_GET_THING:
                    return "Je�eli na polu znajduje si� przedmiot, mo�esz go podnie��. " +
                        "Mo�na posiada� maksymalnie 6 przedmiot�w, a podczas jednego ruchu mo�na podnie�� tylko 2 przedmioty. " + 
                        "Gracz ma mo�liwo�� wymiany przedmiotu.";
                case Action.CAN_START_QUIDDITCH:
                    return "Mo�esz wyzwa� dowolnego gracza do meczu Quidditcha.";
                case Action.CAN_TELEPORT:
                    return "Z tego pola mo�esz si� teleportowa� (za darmo) na odpowiednio po��czone z nim pole.";
            }

            return "";
        }

        public static string GetActionShortText(Action action, List<int> missionNumbers)
        {
            SpecialPower power = GameManager.GetMyPlayer().SpecialPower;

            switch (action)
            {
                case Action.COMMON_ROOM_CHOICE:
                    return "We� jedn� dowoln� kart� lub zaproponuj wymian� przedmiotu pozosta�ym graczom.";
                case Action.FIGHT_FIELD:
                    return "Pobierz kart� z pojedynkiem i przeprowad� walk�.";
                case Action.GET_ONE_BOOK:
                    if (power == SpecialPower.GetOneMoreBook)
                        return "We� dwie karty ksi�gi.";
                    else
                        return "We� jedn� kart� ksi�gi.";
                case Action.GET_ONE_ELIXIR:
                    if (power == SpecialPower.GetOneMoreElixir)
                        return "We� dwie karty eliksiru.";
                    else
                        return "We� jedn� kart� eliksiru.";
                case Action.GET_ONE_EVENT:
                    return "We� jedn� kart� wydarzenia.";
                case Action.GET_ONE_EXERCISE:
                    return "We� jedn� kart� sprawowania.";
                case Action.GET_ONE_SPELL:
                    if (power == SpecialPower.GetOneMoreSpell)
                        return "We� dwie karty zakl�cia.";
                    else
                        return "We� jedn� kart� zakl�cia.";
                case Action.GET_TWO_BOOKS:
                    return "We� dwie karty ksi�gi.";
                case Action.GET_TWO_ELIXIRS:
                    return "We� dwie karty eliksiru.";
                case Action.GET_TWO_SPELLS:
                    return "We� dwie karty zakl�cia.";
                case Action.GET_QUIDDITCH_CARD:
                    return "We� jedn� kart� quidditcha.";
                case Action.ADD_TWO_LIVES:
                    return "Je�li masz miejsce, dobierz 2 �ycia.";
                case Action.ADD_THREE_LIVES:
                    return "Je�li masz miejsce, dobierz 3 �ycia.";
                case Action.ADD_FOUR_LIVES:
                    return "Je�li masz miejsce, dobierz 4 �ycia.";
                case Action.ADD_FIVE_LIVES:
                    return "Je�li masz miejsce, dobierz 5 �y�.";
                case Action.ADD_SIX_LIVES:
                    return "Je�li masz miejsce, dobierz 6 �y�.";
                case Action.CAN_MAKE_MISSION:
                    string result = "Je�eli spe�niasz wszystkie warunki odpowiedniej misji (nr ";
                    for (int i = 0; i < missionNumbers.Count; i++)
                    {
                        result += $"{missionNumbers[i]}";
                        if (i < missionNumbers.Count - 1) result += ", ";
                    }
                    result += "), mo�esz j� wykona�.";
                    return result;
                case Action.CAN_PASS_EXAMS:
                    return "Mo�esz zda� egzaminy, je�li posiadasz karty ksi�gi powi�zane z t� klas�.";
                case Action.CAN_USE_FIUU:
                    return "Mo�esz transportowa� si� za pomoc� proszka fiuu plansz� 2.";
                case Action.CAN_USE_PORTKEY:
                    return "Mo�esz za pomoc� �wistoklika przenie�� si� na pole \"Cmentarz w Little Hangleton\".";
                case Action.CAN_GET_THING:
                    return "Mo�esz podnie�� przedmiot, kt�ry znajduje si� na tym polu.";
                case Action.CAN_START_QUIDDITCH:
                    return "Mo�esz wyzwa� dowolnego gracza do meczu Quidditcha.";
                case Action.CAN_TELEPORT:
                    return "Z tego pola mo�esz si� teleportowa� (za darmo) na odpowiednio po��czone z nim pole.";
            }

            return "";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Instruction
    {
        public Dictionary<InstructionInfo, string> instructions;

        public enum InstructionInfo
        {
            GameDuration,                       //wszystkie pola
            GamePreparation,
            PlayerMove,                         //wszystkie pola
            MissionCompleting,                  //misje
            SpecialItems,                       //wszystkie pola
            FightWithPlayer,                    //wszystkie pola
            FightOnFightField,                  //pole walki
            MissionFight,                       //misje
            QuidditchPreparation,               //boisko do quidditcha
            QuidditchRound1, 
            QuidditchRound1_Actions1, 
            QuidditchRound1_Actions2, 
            QuidditchRound2
        }

        public Instruction()
        {
            InitializeInstruction();
        }

        public string GetInstructionInfoString(InstructionInfo info)
        {
            switch (info)
            {
                case InstructionInfo.GameDuration:
                    return "Czas trwania gry";
                case InstructionInfo.GamePreparation:
                    return "Przygotowanie gry";
                case InstructionInfo.PlayerMove:
                    return "Ruch gracza";
                case InstructionInfo.MissionCompleting:
                    return "Wype�nianie misji";
                case InstructionInfo.SpecialItems:
                    return "Przedmioty specjalne";
                case InstructionInfo.FightWithPlayer:
                    return "Pojedynek\nz innym graczem";
                case InstructionInfo.FightOnFightField:
                    return "Pojedynek\nna polu pojedynku";
                case InstructionInfo.MissionFight:
                    return "Pojedynek\npodczas misji";
                case InstructionInfo.QuidditchPreparation:
                    return "Przygotowanie\nmeczu quidditcha";
                case InstructionInfo.QuidditchRound1:
                    return "Runda 1\nmeczu quidditcha";
                case InstructionInfo.QuidditchRound1_Actions1:
                    return "Runda 1\nAkcje (1)";
                case InstructionInfo.QuidditchRound1_Actions2:
                    return "Runda 1\nAkcje (2)";
                case InstructionInfo.QuidditchRound2:
                    return "Runda 2\nmeczu quidditcha";
                default:
                    return "";
            }
        }

        private void InitializeInstruction()
        {
            instructions = new();

            instructions[InstructionInfo.GameDuration] = 
                "Gracz ma mo�liwo�� wybrania warunk�w zwyci�stwa:\n\n" +
                "1. szybka rozgrywka: wykonanie 1 misji i zdobycie 210 punkt�w\n\n" +
                "2. klasyczna rozgrywka: wykonanie 2 misji i zdobycie 260 punkt�w\n\n" +
                "3. d�uga rozgrywka: wykonanie 3 misji i zdobycie 320 punkt�w";

            instructions[InstructionInfo.GamePreparation] =
                "1. Umieszczenie przedmiot�w (��cznie 30) na polach z gwiazdk�.\n\n" +
                "2. Ka�dy gracz wybiera 1 z 9 planszetek z dost�pnymi postaciami.\n\n" +
                "3. Ka�dy gracz dostaje 2 �etony proszka fiuu, 1 �wistoklik, odpowiedni� liczb� �y� oraz karty okre�lone na planszetce.\n\n" +
                "4. Ka�dy losuje 5 kart misji (je�eli w grze bierze udzia� wi�cej ni� 6 graczy, losuj� po 3).\n\n" +
                "5. Wszyscy gracze zaczynaj� na polu \"Start\".";

            instructions[InstructionInfo.PlayerMove] =
                "Gracz, przed ka�dym rzutem ko��mi, powinien zczyta� pozycj� gracza, " +
                "a nast�pnie wybra� jedno z pod�wietlonych p�l planszy i przesun�� na nie znacznik. \n\n" + 
                "Dodatkowo gracz powinien zatrzyma� si� na polu, na kt�rym stoi inny gracz, " +
                "gdy mija go w swoim ruchu (nie obowi�zuje go wtedy akcja powi�zana z danym polem).\n\n" + 
                "Ka�de pole powi�zane jest z pewn� akcj�, kt�r� gracz powinien wykona�. " + 
                "Niezb�dne informacje o polach b�d� dost�pne po naklikni�ciu na pod�wietlenia. " + 
                "Dodatkowo wy�wietlana b�dzie informacja o aktualnym polu, na kt�rym znajduje si� gracz.";

            instructions[InstructionInfo.MissionCompleting] =
                "Gracz mo�e spr�bowa� wykona� misj�, tylko gdy spe�nia warunki widoczne na karcie misji:\n" +
                "1) znajduje si� w odpowiednim miejscu na planszy\n" + 
                "2) posiada odpowiednie �etony lub karty (okre�lone dla wariantu �Niepe�noletni czarodziej�)\n\n" +
                "Punkty przypisane do misji otrzymuje dopiero wtedy, gdy pokona przeciwnika okre�lonego na karcie misji. " + 
                "Po wykorzystaniu przedmiot�w przy misji, nale�y umie�ci� je na dowolnym polu z gwiazdk� na planszy 2 " + 
                "(z niezapomnianymi miejscami ze �wiata HP).";

            instructions[InstructionInfo.SpecialItems] =
                "Po ich wykorzystaniu po�� je na 1 z 3 gwiazdek na ulicy Pok�tnej. S� to\n\n" +
                "1) Czarna r�d�ka: +1 ko�� ataku w czasie walki\n\n" +
                "2) Kamie� wskrzeszenia: +6P� podczas walki\n\n" +
                "3) Peleryna niewidka: ucieknij z miejsca walki na odleg�o�� 5 p�l\n\n" +
                "4) Miecz Gryffindora: +1 ko�� ataku w czasie walki\n\n" +
                "5) Zmieniacz czasu: rozegraj dodatkow� tur�\n\n" +
                "6) Hardodzi�b: udaj si� na dowolne pole na planszy 1 albo 2, a nast�pnie wr��";

            instructions[InstructionInfo.FightWithPlayer] =
                "Ka�dy gracz rzuca 1 ko�ci� - ten kto ma mniejsza liczb� oczek, traci 1 P�.\n" +
                "Podczas pojedynku nie mo�na u�y� ani zakl�cia ani eliksiru.\n" +
                "\nPrzegrana: utrata 2 P�\n" +
                "Wygrana: zabranie przegranemu �etonu przedmiotu, �wistoklika, proszka Fiuu lub zakrytej karty";

            instructions[InstructionInfo.FightOnFightField] =
                "Gracz nie mo�e gra� z postaci�, kt�r� sam jest - powinien wybra� inn� kart�. " +
                "Na karcie pojedynku okre�lona jest liczba �y� przeciwnika oraz jego spos�b obrony.\n" +
                "\nWalczy� mo�na na 2 sposoby:\n" +
                "1) ko��mi ataku (ich liczba widnieje na planszetce gracza): " + 
                "ka�da ko�� z wynikiem wi�kszym lub r�wnym odporno�ci przeciwnika, zabiera mu 1 P�\n" +
                "2) kartami zakl�� i eliksir�w (mo�na wykorzysta� w dowolnym momencie ruchu): u�ycie karty obrony pozbawia przeciwnika ruchu\n" +
                "\nPrzegrana (pozosta� 1 P�): gracz odrzuca 3 dowolne karty\n" +
                "Wygrana: gracz dobiera 1 zakl�cie, 1 eliksir i 1 ksi�g�";

            instructions[InstructionInfo.MissionFight] =
                "Ka�da karta misji wskazuje posta�, z kt�r� nale�y stoczy� pojedynek. Karta przeciwnika posiada informacje o nim.\n" +
                "\nGracz ma mo�liwo�� wykorzystania:\n" +
                " - karty obrony (powoduje brak kontrataku)\n" + 
                " - karty ataku\n" +
                " - ko�ci ataku: liczba oczek nie mniejsza od odporno�ci przeciwnika, odbiera mu 1 P�\n" + 
                "Gracz podczas jednej walki mo�e wykorzysta� maksymalnie 5 kart zakl�� i eliksir�w\n" +
                "Po �mierci przeciwnika, atakuje on gracza jeszcze raz swoj� zdolno�ci� specjaln�\n" +
                "\nWygrana (przeciwnik nie ma �y�): misja wype�niona, zdobycie okre�lonej na karcie misji liczby punkt�w domu\n" +
                "Przegrana (gracz ma 1 P�): gracz idzie do \"Dziurawego Kot�a\", zdobywa 6P� i odk�ada wszystkie karty eliksir�w i zakl��.";

            instructions[InstructionInfo.QuidditchPreparation] =
                "Na pocz�tku nale�y wybra� dru�yn� oraz rozstawi� graczy:\n" + 
                "- 1 szukaj�cy na linii startowej (wok� boiska)\n" + 
                "- 1 obro�ca na 1 z 3 p�l pola bramkowego\n" + 
                "- 2 pa�karzy na 2 z 5 p�l linii wok� pola bramkowego\n" + 
                "- 3 �cigaj�cych na 3 z 10 p�l dw�ch kolejnych linii\n" + 
                "\nKafel umieszcza si� na �rodku boiska, a t�uczki po jednym na ka�dej po�owie\n" + 
                "Mecz rozpoczyna gracz z wi�ksz� liczb� oczek po rzucie 2 ko��mi\n" + 
                "Sk�ada si� on z dw�ch rund: uzyskania 2 goli oraz zdobycia z�otego znicza\n\n" + 
                "Wygrana: 40 punkt�w domu";

            instructions[InstructionInfo.QuidditchRound1] =
                "Gdy wszyscy �cigaj�cy danego gracza s� wyeliminowani, przegrywa on automatycznie rund� 1.\n\n" + 
                "Gracze nie mog� wchodzi� na to samo pole co inni gracze, z wyj�tkiem sytuacji z przej�ciem kafla.\n\n" + 
                "Obro�cy nie mog� opu�ci� p�l bramkowych.\n\n" +
                "Ka�dy gracz na pocz�tku ruchu rzuca 2 ko��mi, kt�re okre�laj� liczb� akcji.";

            instructions[InstructionInfo.QuidditchRound1_Actions1] =
                "Ruchy kosztuj�ce 1 akcj�:\n" +
                "\n1) Ruch wzd�u� bia�ych kropkowanych linii.\n" +
                "\n2) Rzut trzymanym kaflem o 1 pole.\n" +
                "\n3) Przej�cie kafla (�cigaj�cy oraz kafel musz� by� na tym samym polu).\n" +
                "\n4) strzelenie gola przez �cigaj�cego znajduj�cego si� na linii wok� pola bramkowego. " +
                "Strza� odbywa si� za pomoc� rzutu ko�ci� - je�li rzucaj�cy ma wi�cej oczek ni� obro�ca, " +
                "nast�puje gol i zdobycie 1 karty quidditcha. Kafel trafia do obro�cy zar�wno po pr�bie, " +
                "jak i po golu. Je�li obro�ca zosta� wyeliminowany, kafel zostaje na losowym polu na linii wok� pola bramkowego.";

            instructions[InstructionInfo.QuidditchRound1_Actions2] =
                "Ruchy bez �adnego kosztu:\n" +
                "\n1) Podniesienie kafla/t�uczka odpowiednio przez �ciagaj�cego/pa�karza, b�d�cego na tym samym polu, co pi�ka.\n" +
                "\n2) Rzut trzymanym t�uczkiem przez pa�karza na odleg�o�� okre�lon� przez dodatkowy rzut ko�ci� " +
                "- mo�na zrobi� unik, ale je�li wyrzucona liczba oczek przez przeciwnika wynosi mniej ni� 4, posta� zostaje wyeliminowana.";

            instructions[InstructionInfo.QuidditchRound2] =
                "Wygrywa ten, kto pierwszy okr��y boisko.\n\n" +
                "Szukaj�cy rozpoczynaj� na polu startowym linii wok� boiska.\n\n" +
                "Rozpoczyna gracz, kt�ry wygra� rund� 1.\n\n" +
                "Ka�dy gracz rzuca w swojej turze 2 ko��mi oraz mo�e u�y� maksymalnie 1 karty quidditcha.";
        }
    }
}

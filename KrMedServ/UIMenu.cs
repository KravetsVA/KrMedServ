using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrMedServ
{
    internal enum CurrentMenu
    {        
        MainMenu,        
        MenuTreatmentRooms,
        MenuGuests,
        MenuMedCards
    }

    internal class UIMenu
    {        
        private bool flgExitMenu;
        private MainMenu selMainMenu;     // Selected MainMenu
        private MenuGuests selMenuGuests; // Selected MenuGuests
        private MenuTreatmentRooms selMenuTreatmentRooms; // Selected UIMenuTreatmentRooms
        private MenuMedCards selMenuMedCards; // Selected UIMenuMedCards
        private CurrentMenu curMenu; // current Menu

        public UIMenu()
        {
            this.curMenu = CurrentMenu.MainMenu;
            this.flgExitMenu = false;
            this.selMainMenu = MainMenu.Exit;
            this.selMenuGuests = MenuGuests.Exit;
            this.selMenuTreatmentRooms = MenuTreatmentRooms.Exit;
            this.selMenuMedCards = MenuMedCards.Exit;
        }

        public UIMenu(CurrentMenu curMenu) 
        {
            this.curMenu = curMenu;
            this.flgExitMenu = false;
            this.selMainMenu = MainMenu.Exit;
            this.selMenuGuests = MenuGuests.Exit;
            this.selMenuTreatmentRooms = MenuTreatmentRooms.Exit;
            this.selMenuMedCards = MenuMedCards.Exit;
        }

        public CurrentMenu CurMenu
        {
            get { return curMenu; }
            set {  this.curMenu = value; }  
        }

        public bool FlgExitMenu
        {
            get { return flgExitMenu; }
            set {  this.flgExitMenu = value; }  
        }

        public MainMenu SelMainMenu
        {
            get { return selMainMenu; }
            set { this.selMainMenu = value; }
        }
        public MenuGuests SelMenuGuests
        {
            get { return selMenuGuests; }
            set { this.selMenuGuests = value; }
        }
        public MenuTreatmentRooms SelMenuTreatmentRooms
        {
            get { return selMenuTreatmentRooms; }
            set { this.selMenuTreatmentRooms = value; }
        }
        public MenuMedCards SelMenuMedCards
        {
            get { return selMenuMedCards; }
            set { this.selMenuMedCards = value; }
        }

        public MainMenu ShowMainMenu()
        {
            CurMenu = CurrentMenu.MainMenu;
            return UIMainMenu.ShowMainMenu();
        }

        public void ShowCurrentMenu()
        {
            if(CurMenu == CurrentMenu.MainMenu)
            {
                SelMainMenu = UIMainMenu.ShowMainMenu();

                if (SelMainMenu == MainMenu.Exit)
                {
                    FlgExitMenu = true;                    
                }
                else
                {
                    FlgExitMenu = false;
                    switch (SelMainMenu)
                    {
                        case MainMenu.Guests:
                            CurMenu = CurrentMenu.MenuGuests;
                            break;
                        case MainMenu.TreatmentRooms:
                            CurMenu = CurrentMenu.MenuTreatmentRooms;
                            break;
                        case MainMenu.MedCards:
                            CurMenu = CurrentMenu.MenuMedCards;
                            break;
                        default:
                            break;
                    }                    
                }
            }
            else if(CurMenu == CurrentMenu.MenuGuests)
            {
                SelMenuGuests = UIMenuGuests.ShowMenuGuests();

                if (SelMenuGuests == MenuGuests.Exit)
                {
                    FlgExitMenu = false;
                    curMenu = CurrentMenu.MainMenu;
                }
                else
                {
                    FlgExitMenu = false;                    
                }
            }
            else if (CurMenu == CurrentMenu.MenuTreatmentRooms)
            {
                SelMenuTreatmentRooms = UIMenuTreatmentRoom.ShowMenuTreatmentRooms();

                if (SelMenuTreatmentRooms == MenuTreatmentRooms.Exit)
                {
                    FlgExitMenu = false;
                    curMenu = CurrentMenu.MainMenu;
                }
                else
                {
                    FlgExitMenu = false;
                }
            }
            else if (CurMenu == CurrentMenu.MenuMedCards)
            {
                SelMenuMedCards = UIMenuMedCards.ShowMenuMedCards();

                if (SelMenuMedCards == MenuMedCards.Exit)
                {
                    FlgExitMenu = false;
                    curMenu = CurrentMenu.MainMenu;
                }
                else
                {
                    FlgExitMenu = false;
                }
            }

        }

    }
}

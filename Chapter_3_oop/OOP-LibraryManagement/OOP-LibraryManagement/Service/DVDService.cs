using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Service
{
    public class DVDService : IDVDService
    {
        private List<DVD> DVDList;
        private readonly string ErrorMsg;

        public DVDService()
        {
            DVDList = new List<DVD>();
            ErrorMsg = "-> Invalid Input, Try Again";
        }
        public List<DVD> getDVDList()
        {
            return DVDList;
        }


        public void Add(DVD entity)
        {
            try
            {
                DVDList.Add(entity);
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "DVD", ex.Message));
            }
        }
        public void Display()
        {
            try
            {
                if (DVDList != null && DVDList.Count > 0)
                {
                    Console.WriteLine("DVD List");
                    foreach (var entity in DVDList)
                    {
                        entity.DisplayInfo();
                    }
                }
                else
                {
                    GlobalUltis.PrintError(GlobalUltis.ERROR_EMPTY_LIST);
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_DISPLAY_LIST, "DVD", ex.Message));
            }
        }

        public bool CheckIfIdExist(int id)
        {
            return DVDList.Any(dvd => dvd.Id == id);
        }

        public DVD SearchByTitle(string tilte)
        {
            foreach (var entity in DVDList)
            {
                if (entity.Title == tilte)
                {
                    return entity;
                }
            }
            return null;
        }

        public void AddDVD()
        {
            do
            {
                try
                {
                    int id;
                    do
                    {
                        id = GlobalUltis.GetInt("DVD Id", ErrorMsg);
                        if (CheckIfIdExist(id) == true)
                        {
                            GlobalUltis.PrintError("ID already exist.Please enter a different one");
                        }
                    } while (CheckIfIdExist(id));
                    string tilte = GlobalUltis.GetString("DVD Title", ErrorMsg);
                    DateTime publicationYear = ObjectUltis.ValidPulicationYear("Publication Year", "Invalid Date Format");
                    string director = GlobalUltis.GetString("DVD Director", ErrorMsg);
                    int runtime = GlobalUltis.GetInt("DVD Runtime", ErrorMsg);
                    int ageRating = GlobalUltis.GetInt("DVD Age Rating", ErrorMsg);
                    DVDList.Add(new DVD(id, tilte, publicationYear, director, runtime, ageRating));
                    GlobalUltis.PrintSuccessMessage("DVD add to list successfully");
                }
                catch (Exception ex)
                {
                    GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "Magazine", ex.Message));
                }

            } while (GlobalUltis.GetString("-> Do you want to continue adding DVD (Y/N)", ErrorMsg).Equals("Y"));
        }

        public void SearchDVDByTilte()
        {
            string tilte = GlobalUltis.GetString("Enter DVD tilte you want to search", ErrorMsg);
            DVD found = SearchByTitle(tilte);
            if (found != null)
            {
                GlobalUltis.PrintSuccessMessage("DVD Found");
                found.DisplayInfo();
            }
            else
            {
                GlobalUltis.PrintError("DVD not found");
            }
        }
    }
}

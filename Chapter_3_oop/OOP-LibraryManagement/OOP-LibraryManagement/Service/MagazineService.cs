using OOP_LibraryManagement.Model;
using OOP_LibraryManagement.Service.Interface;
using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Service
{
    public class MagazineService : IMagazineService
    {
        private List<Magazine> MagazineList;
        private readonly string ErrorMsg;

        public MagazineService()
        {
            MagazineList = new List<Magazine>();
            ErrorMsg = "-> Invalid Input, Try Again";
        }

        public List<Magazine> GetMagazineList()
        {
            return MagazineList;
        }

        public void Add(Magazine entity)
        {
            try
            {
                MagazineList.Add(entity);
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "Magazine", ex.Message));
            }
        }

        public void Display()
        {
            try
            {
                if (MagazineList != null && MagazineList.Count > 0)
                {
                    Console.WriteLine("Magazine List");
                    foreach (var entity in MagazineList)
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
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_DISPLAY_LIST, "Magazine", ex.Message));
            }
        }

        public bool CheckIfIdExist(int id)
        {
            return MagazineList.Any(magazine => magazine.Id == id);

        }

        public Magazine SearchByTitle(string tilte)
        {
            foreach (var entity in MagazineList)
            {
                if (entity.Title == tilte)
                {
                    return entity;
                }
            }
            return null;
        }
        public void AddMagazine()
        {
            do
            {
                try
                {
                    int id;
                    do
                    {
                        id = GlobalUltis.GetInt("Magazine Id", ErrorMsg);
                        if (CheckIfIdExist(id) == true)
                        {
                            GlobalUltis.PrintError("ID already exist.Please enter a different one");
                        }
                    } while (CheckIfIdExist(id));
                    string tilte = GlobalUltis.GetString("Magazine Title", ErrorMsg);
                    DateTime publicationYear = ObjectUltis.ValidPulicationYear("Publication Year", "Invalid Date Format");
                    string author = GlobalUltis.GetString("Magazine Author", ErrorMsg);
                    int issuesNumber = GlobalUltis.GetInt("Magazine Issue Number", ErrorMsg);
                    string publish = GlobalUltis.GetString("Magazine Publisher", ErrorMsg);
                    MagazineList.Add(new Magazine(id, tilte, publicationYear, issuesNumber, publish));
                    GlobalUltis.PrintSuccessMessage("Magazine add to list successfully");
                }
                catch (Exception ex)
                {
                    GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, "Magazine", ex.Message));
                }
            } while (GlobalUltis.GetString("-> Do you want to continue adding book (Y/N)", ErrorMsg).Equals("Y"));
        }

        public void SearchMagazineByTilte()
        {
            string tilte = GlobalUltis.GetString("Enter magazine tilte you want to search", ErrorMsg);
            Magazine found = SearchByTitle(tilte);
            if (found != null)
            {
                GlobalUltis.PrintSuccessMessage("Magazine Found");
                found.DisplayInfo();
            }
            else
            {
                GlobalUltis.PrintError("Magazine not found");
            }
        }
    }
}

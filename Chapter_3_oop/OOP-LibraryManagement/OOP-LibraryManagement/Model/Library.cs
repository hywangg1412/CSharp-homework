using OOP_LibraryManagement.Ultis;

namespace OOP_LibraryManagement.Model
{
    public class Library
    {
        private readonly List<LibraryItem> itemsList;

        public Library()
        {
            itemsList = new List<LibraryItem>();
        }

        public void AddItem(LibraryItem item)
        {
            try
            {
                itemsList.Add(item);
                GlobalUltis.PrintSuccessMessage("Add items to list succesfully");
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_ADDING_ITEM, item.Title, ex.Message));
            }

        }
        public void SearchByTitle(string itemTitle)
        {
            try
            {
                Console.WriteLine($"Search By Title");
                bool found = false;
                foreach (LibraryItem item in itemsList)
                {
                    if (item.Title.ToLower().Equals(itemTitle.Trim().ToLower()))
                    {
                        item.DisplayInfo();
                        found = true;
                    }
                }
                if (!found)
                {
                    GlobalUltis.PrintSuccessMessage($"No items found with title: {itemTitle}");
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_SEARCH_TITLE, ex.Message));
            }
        }
        public void DisplayAllItem()
        {
            try
            {
                if (itemsList != null && itemsList.Count > 0)
                {
                    foreach (LibraryItem item in itemsList)
                    {
                        item.DisplayInfo();
                    }
                }
                else
                {
                    GlobalUltis.PrintError(GlobalUltis.ERROR_EMPTY_LIST);
                }
            }
            catch (Exception ex)
            {
                GlobalUltis.PrintError(string.Format(GlobalUltis.ERROR_DISPLAY_ITEMS, ex.Message));
            }
        }
    }
}

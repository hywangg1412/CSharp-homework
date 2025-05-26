namespace OOP_LibraryManagement.Service.Interface
{
    public interface Service<T>
    {
        void Display();

        void Add(T entity);

        T SearchByTitle(string tilte);

        bool CheckIfIdExist(int id);
    }
}

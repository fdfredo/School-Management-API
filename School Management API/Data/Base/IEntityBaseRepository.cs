namespace School_Management_API.Data.Base
{
	public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<T> AddAsync(T entity);
		Task UpdateAsync(int id, T entity);
		Task DeleteAsync(int id);
	}
}

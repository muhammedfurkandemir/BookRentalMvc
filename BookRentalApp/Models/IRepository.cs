using System.Linq.Expressions;

namespace BookRentalApp.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Delete(T entity);

        void Add(T entity);

        void DeleteRange(IEnumerable<T> Entities);
    }

    /*expression sınıfı, bir lambda ifadesini temsil etmek için kullanılır. Bu ifadeler, çalışma zamanında bir işlemi temsil eden ve bu işlemi delege olarak saklayan yapılardır. expression sınıfı, bu lambda ifadelerini içeren bir ağaç yapısı oluşturur ve bu yapının içinde ifadenin yapısı, değişkenleri, operatörleri vb. gibi bilgiler saklanır. Bu yapı, bir lambda ifadesinin yapısını kod içinde manipüle etmenizi sağlar.

expression<Func<T, bool>> ise genellikle filtreleme amaçlı kullanılır. Bu ifade, bir fonksiyonu temsil eden bir Func delegesi alır ve bu fonksiyon bir generic tip olan T tipinde bir argüman alıp bool bir değer döndürür. Bu genellikle bir liste veya koleksiyondaki öğeleri filtrelemek için kullanılır. Örneğin, bir veri tabanındaki bir tabloyu sorgularken veya bir koleksiyondaki öğeleri belirli bir koşula göre seçerken kullanılabilir.
    */
}

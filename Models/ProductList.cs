namespace ProvaPub.Models
{
	public class ProductList : PropriedadesComunsLista<Product>
	{
        public List<Product> Products { get => Items; set => Items = value; }
    }
}

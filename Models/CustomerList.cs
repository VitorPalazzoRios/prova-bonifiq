namespace ProvaPub.Models
{
	public class CustomerList : PropriedadesComunsLista<Customer>
    {
        public List<Customer> Customers { get => Items; set => Items = value; }
    }
}

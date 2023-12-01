namespace TechTestMikeS.Classes
{
    public class Order
    {
        public int identifier;
        public List<Part> parts;
        public float total;
        public string status = "Pending";

        public Order(int identifier, List<Part> parts)
        {
            this.identifier = identifier;
            this.parts = parts;
            calculateTotal();
        }

        public void calculateTotal()
        {
            this.total = 0;
            foreach (Part part in this.parts)
            {
                total += (part.price * part.orderedQuantity);
            }
        }
    }
}

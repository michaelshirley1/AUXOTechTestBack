using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace TechTestMikeS.Classes
{
    public class Part
    {
        public int identifier;
        public string description;
        public float price;
        public int quantity;
        public int orderedQuantity;

        public Part(int identifier, Dictionary<string, string> data)
        {
            this.identifier = identifier;
            this.description = data["description"];
            this.price = float.Parse(data["price"]);
            this.quantity = int.Parse(data["quantity"]);
            if (data.ContainsKey("orderedQuantity")) {
                this.orderedQuantity = int.Parse(data["orderedQuantity"]);
            }
            else
            {
                this.orderedQuantity = 0;
            }
            
        }
    }
}

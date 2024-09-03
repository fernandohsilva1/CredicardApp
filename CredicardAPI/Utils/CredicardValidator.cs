namespace CrediCardAPI.Utils
{
    public static class CardValidator
    {
        public static bool IsValidCard(string cardNumber, string brand, string cvc)
        {
            bool isValidBrand = false;

            if (brand == "Visa" && cardNumber.StartsWith("4") && (cardNumber.Length == 13 || cardNumber.Length == 16))
            {
                isValidBrand = true;
            }
            else if (brand == "Mastercard" && cardNumber.StartsWith("5") && cardNumber.Length == 16)
            {
                isValidBrand = true;
            }

            return isValidBrand && cvc.Length == 3 && int.TryParse(cvc, out _);
        }
    }
}

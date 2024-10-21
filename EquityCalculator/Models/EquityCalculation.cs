// Models/EquityCalculation.cs
public class EquityCalculation
{
    public decimal SellingPrice { get; set; }
    public DateTime ReservationDate { get; set; }
    public int EquityTerm { get; set; }

    public List<PaymentInfo> CalculatePayments()
    {
        List<PaymentInfo> payments = new List<PaymentInfo>();
        decimal balance = SellingPrice;
        decimal monthlyAmount = SellingPrice / EquityTerm;

        for (int i = 1; i <= EquityTerm; i++)
        {
            DateTime dueDate = ReservationDate.AddMonths(i);
            decimal interest = balance * 0.05m; // 5% interest
            decimal insurance = monthlyAmount * 0.01m; // 1% insurance
            decimal total = monthlyAmount + interest + insurance;

            // Update the balance for the current payment
            balance -= monthlyAmount;

            // Ensure the balance doesn't go below zero
            if (balance < 0)
            {
                balance = 0;
            }

            payments.Add(new PaymentInfo
            {
                Month = $"{i} month",
                Amount = Math.Round(monthlyAmount, 2),
                Interest = Math.Round(interest, 2),
                Insurance = Math.Round(insurance, 2),
                Total = Math.Round(total, 2),
                DueDate = dueDate,
                Balance = Math.Round(balance, 2) // Round the balance to two decimal places
            });
        }
        return payments;
    }
}


public class PaymentInfo
{
    public string? Month { get; set; }
    public decimal Amount { get; set; }
    public decimal Interest { get; set; }
    public decimal Insurance { get; set; }
    public decimal Total { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Balance { get; set; }
}

public class Invoice
{
 public int InvoiceID { get; set; }
 public int CustomerID { get; set; }
 public DateTime InvoiceDate { get; set; }
 public decimal ProductTotal { get; set; }
 public decimal SalesTax { get; set; }
 public decimal Shipping { get; set; }
 public decimal InvoiceTotal { get; set; }
}










//int[] numbers = new int[] { 0, 1, 2, 3, 4 };
//var numberList = from number in numbers
//                 where number % 2 == 0
//                 orderby number ascending
//                 select number;
//string numberDisplay = "";


//foreach (var number in numberList)
// numberDisplay += number + " ";
////Console.WriteLine((numberDisplay, "Sorted Even Numbers"));


//decimal[] salesTotals =
//new decimal[] { 1286.45m, 2433.49m, 2893.85m,
//2094.53m };
//var salesList = from sales in salesTotals
//                select sales;
//decimal sum = 0;
//foreach (var sales in salesList)
// sum += sales;
//Console.WriteLine(sum);


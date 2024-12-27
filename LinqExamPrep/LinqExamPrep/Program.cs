





////SortedList<string, decimal> employeeSales = new()
////{
//// ["Anderson"] = 1286.45m,
//// ["Menendez"] = 2433.49m,
//// ["Thompson"] = 2893.85m,
//// ["Wilkinson"] = 2094.53m
////};

////var employeeList = from sales in employeeSales
////                   where sales.Value > 2000
////                   orderby sales.Value descending
////                   select sales.Key;
////string employeeDisplay = "";
////foreach (var employee in employeeList)
//// employeeDisplay += employee + "\t\t\t\n";
////Console.WriteLine (employeeDisplay,
////"Sorted Employees With Sales Over $2000");







//using System.Drawing;

//List<Invoice> invoiceList = new List<Invoice>
//{
//    new Invoice
//    {
//        InvoiceID = 1,
//        CustomerID = 101,
//        InvoiceDate = new DateTime(2023, 12, 1),
//        ProductTotal = 100.00m,
//        SalesTax = 10.00m,
//        Shipping = 5.00m,
//        InvoiceTotal = 115.00m
//    },
//    new Invoice
//    {
//        InvoiceID = 2,
//        CustomerID = 102,
//        InvoiceDate = new DateTime(2023, 12, 2),
//        ProductTotal = 200.00m,
//        SalesTax = 20.00m,
//        Shipping = 10.00m,
//        InvoiceTotal = 230.00m
//    },
//    new Invoice
//    {
//        InvoiceID = 3,
//        CustomerID = 103,
//        InvoiceDate = new DateTime(2023, 12, 3),
//        ProductTotal = 150.00m,
//        SalesTax = 15.00m,
//        Shipping = 7.50m,
//        InvoiceTotal = 172.50m
//    },
//    new Invoice
//    {
//        InvoiceID = 4,
//        CustomerID = 104,
//        InvoiceDate = new DateTime(2023, 12, 4),
//        ProductTotal = 50.00m,
//        SalesTax = 5.00m,
//        Shipping = 2.50m,
//        InvoiceTotal = 57.50m
//    },
//    new Invoice
//    {
//        InvoiceID = 5,
//        CustomerID = 105,
//        InvoiceDate = new DateTime(2023, 12, 5),
//        ProductTotal = 300.00m,
//        SalesTax = 30.00m,
//        Shipping = 15.00m,
//        InvoiceTotal = 345.00m
//    }
//};
//int invoiceCount = invoiceList
//.Where(i => i.InvoiceTotal > 150)
//.Count();

//decimal invoiceTotal = invoiceList
//.Where(i => i.InvoiceDate >=
//DateTime.Parse("01/01/2023")
//& i.InvoiceDate <=
//DateTime.Parse("06/30/2023"))
//.Sum(i => i.InvoiceTotal);


//int skipCount = 20;
//int takeCount = 10;
//var invoices = invoiceList
//.Skip(skipCount)
//.Take(takeCount);


////foreach (var invoice in invoices)
////{
//// if (invoice.Name != customerName)
//// {
////  lvInvoices.Items.Add(invoice.Name);
////  customerName = invoice.Name;
//// }
//// else
//// {
////  lvInvoices.Items.Add("");
//// }
//// lvInvoices.Items[i].SubItems.Add(
//// invoice.InvoiceID.ToString());
//// lvInvoices.Items[i].SubItems.Add(
//// Convert.ToDateTime(
//// invoice.InvoiceDate).ToShortDateString());
//// lvInvoices.Items[i].SubItems.Add(
//// invoice.InvoiceTotal.ToString("c"));
//// i += 1;
////}
////}

////private void frmCustomerInvoices_Load(
////object sender, EventArgs e)
////{
//// List<Customer> customerList =
//// CustomerDB.GetCustomers();
//// List<Invoice> invoiceList = InvoiceDB.GetInvoices();
//// var invoices = from invoice in invoiceList
////                join customer in customerList
////                on invoice.CustomerID
////                equals customer.CustomerID
////                orderby customer.Name,
////                invoice.InvoiceTotal descending
////                select new
////                {
////                 customer.Name,
////                 invoice.InvoiceID,
////                 invoice.InvoiceDate,
////                 invoice.InvoiceTotal
////                };
//// string customerName = "";
//// int i = 0;


// //protected override void ScaleControl(SizeF factor,
// //BoundsSpecified specified)
// //{
// // base.ScaleControl(factor, specified);
// // ScaleListViewColumns(lvInvoices, factor);
// //}
// //private void ScaleListViewColumns(
// //ListView listview, SizeF factor)
// //{
// // foreach (ColumnHeader column in listview.Columns)
// // {
// //  column.Width = (int)Math.Round(column.Width
// //  * factor.Width);
// // }
// //}

// //A method-based query that joins data
// //and selects fields
// //var invoices =
// //invoiceList.Join(customerList,
// //i => i.CustomerID,
// //c => c.CustomerID,
// //(i, c) => new
// //{
// // c.Name,
// // i.InvoiceDate,
// // i.InvoiceTotal
// //})
// //.Where(ci => ci.InvoiceTotal > 150)
// //.OrderBy(ci => ci.Name)
// //.ThenBy(ci => ci.InvoiceDate)
// //.Select(ci => new {
// // ci.Name,
// // ci.InvoiceTotal
// //});


// //A method-based query that joins data
// //from two data sources
// //var invoices =
// //invoiceList.Join(customerList,
// //i => i.CustomerID,
// //c => c.CustomerID,
// //(i, c) => new { c.Name, i.InvoiceTotal })
// //.Where(ci => ci.InvoiceTotal > 150)
// //.OrderBy(ci => ci.Name)
// //.ThenByDescending(ci => ci.InvoiceTotal);

// //A method-based query that filters
// //and sorts the results and selects fields
// //var invoices = invoiceList
// //.Where(i => i.InvoiceTotal > 150)
// //.OrderBy(i => i.CustomerID)
// //.ThenByDescending(i => i.InvoiceTotal)
// //.Select(i => new {
// // i.CustomerID,
// // i.InvoiceTotal
// //});

// //var invoices =
// //from invoice in invoiceList
// //join customer in customerList
// //on invoice.CustomerID equals
// //customer.CustomerID
// //where invoice.InvoiceTotal > 150
// //orderby customer.Name,
// //invoice.InvoiceTotal descending
// //select new { customer.Name, invoice.InvoiceTotal };
// //string invoiceDisplay =
// //"Customer Name\t\tInvoice amount\n";
// //foreach (var invoice in invoices)
// //{
// // invoiceDisplay += invoice.Name + "\t\t";
// // invoiceDisplay +=
// // invoice.InvoiceTotal.ToString("c") + "\n";
// //}
// //MessageBox.Show(invoiceDisplay,
// //"Joined Customer and Invoice Data");

//// var invoices = from invoice in invoiceList
////               where invoice.InvoiceTotal > 150
////               orderby invoice.CustomerID,
////               invoice.InvoiceTotal descending
////               select new
////               {
////                invoice.CustomerID,
////                invoice.InvoiceTotal
////               };
////string invoiceDisplay = "Cust ID\tInvoice amount\n";

//foreach (var invoice in invoices)
// invoiceDisplay += invoice.CustomerID + "\t"
// + invoice.InvoiceTotal.ToString("c")
// + "\n";

//Console.WriteLine(invoiceDisplay);

//Console.WriteLine();
////var invoices = from invoice in invoiceList
////               where invoice.InvoiceTotal > 150
////               orderby invoice.CustomerID,
////               invoice.InvoiceTotal descending
////               select invoice;
////string invoiceDisplay = "Cust ID\tInvoice amount\n";
////foreach (var invoice in invoices)
//// invoiceDisplay += invoice.CustomerID + "\t"
//// + invoice.InvoiceTotal.ToString("c")
//// + "\n";
////Console.WriteLine(invoiceDisplay,
////"Sorted Invoices Over $150");







//////var invoices = from invoice in invoiceList
//////               select invoice;

//////decimal sum = 0;
//////foreach (var invoice in invoices)
////// sum += invoice.InvoiceTotal;
//////Console.WriteLine(sum);


//////var invoices1 = from invoice in invoiceList
//////               where invoice.InvoiceTotal > 150
//////               select invoice;

//////string invoiceDisplay = "";
//////foreach (var invoice in invoices1)
////// invoiceDisplay +=
////// invoice.InvoiceTotal.ToString("c") + "\t\t\n";
//////Console.WriteLine( (invoiceDisplay, "Invoices Over $150"));








//////// Sample sales data4
//////List<decimal> salesTotals = new List<decimal> { 1500.00m, 2500.75m, 3200.00m, 1800.00m, 4000.50m };

//////// Query to get sales over $2000
//////var salesList = from sales in salesTotals
//////                where sales > 2000
//////                select sales;

//////// Execute the query and prepare the display string
//////string salesDisplay = "";
//////foreach (var sales in salesList)
//////{
////// salesDisplay += sales.ToString("c") + "\t\t\n"; // Format as currency
//////}

//////// Show the results in a MessageBox
//////Console.WriteLine(salesDisplay, "Sales Over 2000");









//////int[] numbers = new int[] { 0, 1, 2, 3, 4 };
//////var numberList = from number in numbers
//////                 where number % 2 == 0
//////                 orderby number ascending
//////                 select number;
//////string numberDisplay = "";


//////foreach (var number in numberList)
////// numberDisplay += number + " ";
////////Console.WriteLine((numberDisplay, "Sorted Even Numbers"));


//////decimal[] salesTotals =
//////new decimal[] { 1286.45m, 2433.49m, 2893.85m,
//////2094.53m };
//////var salesList = from sales in salesTotals
//////                select sales;
//////decimal sum = 0;
//////foreach (var sales in salesList)
////// sum += sales;
//////Console.WriteLine(sum);


using System;

// Contractor Class Created by Emmanuel Padron
public class Contractor {
    // Instance Variables / Attributes
    protected string contractorName;
    protected string contractorNumber;
    protected string contractorStartDate;

    // Constructor
    public Contractor(string na, string nu, string sD) {
        contractorName = na;
        contractorNumber = nu;
        contractorStartDate = sD;
    }

    // Accessor methods
    public string GetContractorName() {return contractorName;}
    public string GetContractorNumber() {return contractorNumber;}
    public string GetContractorStartDate() {return contractorStartDate;}

    // Mutator Methods
    public void SetContractorName(string n) {contractorName = n;}
    public void SetContractorNumber(string n) {contractorNumber = n;}
    public void SetContractorStartDate(string sD) {contractorStartDate = sD;}
}

// Subcontractor Child Class Created by Jacob Rosenthal and Andrew Redmond.
// Compute Pay method inside class created by Ederson Noel.
public class Subcontractor : Contractor {
    // Instance Variables / Attributes
    private int shift;
    private int hoursWorked;
    private double payRate;

    // Constructor
    public Subcontractor(string na, string nu, string sD, int sh, int hW, double pR) : base(na, nu, sD)
    {
        shift = sh;
        hoursWorked = hW;
        payRate = pR;
    }

    // Methods / Behavior

    // Compute Pay Method Created by Ederson Noel
    // Computes pay for each contractor based on shift worked, hourly pay, and hours worked.
    public float ComputePay()
    {
        if (shift == 2)
        {
            //Apply the 3% shift differential for night shift
            float shiftDifferential = (float) payRate * 0.03f;
            return (float) (payRate + shiftDifferential) * hoursWorked;
        }
        else
        {
            //Return base pay if dayshift 
            return (float) payRate * hoursWorked;
        }
    }
    
    // Accessors
    public int GetShift() {return shift;}
    public int GetHoursWorked() {return hoursWorked;}
    public double GetPayRate() {return payRate;}

    // Mutators 
    public void SetShift(int sh) {shift = sh;}
    public void SetPayRate(double pR) {payRate= pR;}
    public void SetHoursWorked(int hW) {hoursWorked = hW;}
}

// Subcontractor Objects and algorithm for user to create them created by Dhamyr Panier
public class Program {
    public static void Main() {
        // Creates a List of subcontractors that is empty
         List<Subcontractor> subcontractors = new List<Subcontractor>();
         bool flagVariable = true;

        // Control loop for user to add as many subcontractors as possible.
        while (flagVariable)
        {
            Console.Write("Enter subcontractor name: ");
            string name = Console.ReadLine();

            Console.Write("Enter subcontractor number: ");
            string number = Console.ReadLine();

            Console.Write("Enter subcontractor start date: ");
            string startDate = Console.ReadLine();

            Console.Write("Enter shift (1 for day, 2 for night): ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Enter hours worked: ");
            int hoursWorked = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter hourly pay rate: ");
            double hourlyPayRate = double.Parse(Console.ReadLine());

            Subcontractor subcontractor = new Subcontractor(name, number, startDate, shift, hoursWorked, hourlyPayRate);
            subcontractors.Add(subcontractor);

            // Asks user if they would like to add another subcontractor, if not, break loop.
            Console.Write("Do you want to add another subcontractor? (yes/no): ");
            string another = Console.ReadLine();
            if (another.ToLower() != "yes")
            {
                flagVariable = false;
            }
        }

        // Calculates pay for each contractor using compute pay method.
        foreach (Subcontractor subcontractor in subcontractors)
        {
            Console.WriteLine($"Contractor {subcontractor.GetContractorName()} has worked for {subcontractor.GetHoursWorked()} hours.");
            float pay = subcontractor.ComputePay();
            Console.WriteLine($"Pay for {subcontractor.GetContractorName()} is: ${pay:F2}");
        }

    }
}





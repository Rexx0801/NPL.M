namespace A006{
    internal class HourlyEmployee: Employee{
        public double Wage{ get;set;}
        public double WorkingHour{ get;set;}
        public HourlyEmployee(){ }
        public HourlyEmployee(string ssn, string firstName, string lastName, DateTime birthDate, string phone, string email, double wage, double workingHour) : base(ssn, firstName, lastName, birthDate, phone, email){
            this.Wage = wage;
            this.WorkingHour = workingHour;
        }

        public override string? ToString(){
            return string.Format("{0,-10} {1,-15} {2,-15} {3,-15} {4,-10} {5,-20} {6,-5} {7,-5}", Ssn, FirstName, LastName, BirthDate.ToString("dd/MM/yyyy"), Phone, Email, Wage, WorkingHour);
        }
    }
}
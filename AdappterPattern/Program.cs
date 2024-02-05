namespace AdappterPattern
{
    public  class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Name = "test";
            emp.BasicSalary = 1000;

            salaryCalculator calculator = new salaryCalculator();
           var salary =calculator.calcSalary(emp);
           Console.WriteLine(salary.ToString());
        }
    }
}
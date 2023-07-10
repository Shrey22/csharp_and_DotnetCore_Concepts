namespace Employees.classes;

public class Employee{
    //properties
    // public int empNo { get; set; }
    // public string? Name { get; set; }
    // public string? City { get; set; }

    //member variables
    public int EmpNo; 
    public string? Name;
    public string? City; 

    //Constructor
    public Employee()
    {
        
    }
    public Employee(int _empNo, string _Name, string _City)
    {
        EmpNo = _empNo;
        Name = _Name;
        City = _City;
        // empNo = _empNo;
        // Name = _Name;
        // City = _City;
    }

    //Member methods
    public string GetEmployees(){
        return EmpNo + Name + City;
        //return empNo + Name + City;
    }

    public void SetEmployees(){
        // TODO ==> set emp data
    }
}
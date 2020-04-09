using System;



public class Interventions
{
    public long id { get; set; }
    public long Author { get; set; }
    public long CustomerID  { get; set; }
    public long BuildingID { get; set; }
    public long BatteryID  { get; set; }
    public long ColumnID { get; set; }
    public long ElevatorID  { get; set; }
    public long EmployeeID  { get; set; }
    public DateTime? started_at {get; set;}
    public DateTime? ended_at {get; set;}
    public string Result {get; set;}
    public string Report {get; set;}
    public string Status {get; set;}
 


}
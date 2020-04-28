using System;



public class Addresses
{
    public long id { get; set; }
    public string address_type {get; set;}
    public string status {get; set;}
    public string entity {get; set;}
    public string street_number_name {get; set;}
    public string apartment_number {get; set;}
    public string city {get; set;}
    public string state_province {get; set;}
    public string zip_code {get; set;}
    public string country {get; set;}
    public string notes {get; set;}    
    public DateTime created_at {get; set;}
    public DateTime updated_at {get; set;}
    public float latitude { get; set; }
    public float longitude { get; set; }

}
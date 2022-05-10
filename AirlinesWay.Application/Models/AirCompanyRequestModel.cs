namespace AirlinesWay.Application.Models; 

public class AirCompanyRequestModel {
	public string Name { get; set; }
	public IEnumerable<int> AirLineIds { get; set; }
}
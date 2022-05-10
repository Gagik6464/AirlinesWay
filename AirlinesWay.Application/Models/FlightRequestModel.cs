using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Application.Models; 

public class FlightRequestModel {
	public string Name { get; set; }
	public string Code { get; set; }
	public DateTime StartDateTime { get; set; }
	public DateTime ExpectedFinishDateTime { get; set; }
	public DateTime TimeDuration { get; set; }
	public decimal Price { get; set; }

	public int AirCompanyId { get; set; }
	public int AirlineId { get; set; }

	public IEnumerable<SelectListItem> AirCompanies { get; set; }
}
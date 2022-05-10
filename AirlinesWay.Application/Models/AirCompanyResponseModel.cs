using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlinesWay.Application.Models; 

public class AirCompanyResponseModel {
	public string Name { get; set; }
	public IEnumerable<int> AirLineIds { get; set; }
	
	public IEnumerable<SelectListItem> Airlines { get; set; }
}